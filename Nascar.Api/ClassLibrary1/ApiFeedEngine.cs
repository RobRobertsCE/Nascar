using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Timers;
using Nascar.Api.Models;
using Nascar.Data.Schedule;
using System.Data.Entity;

namespace Nascar.Api
{
    public class ApiFeedEngine : IApiFeedEngine
    {
        #region events
        public event EventFeedStartedDelegate EventFeedStarted;
        protected internal virtual void OnEventFeedStarted(int scheduled_event_id, int race_id)
        {
            if (null != EventFeedStarted)
                EventFeedStarted.Invoke(this, new EventStartedEventArgs() { scheduled_event_id = scheduled_event_id, race_id = race_id });
        }

        public event EventFeedStoppedDelegate EventFeedStopped;
        protected internal virtual void OnEventFeedStopped(int scheduled_event_id, int race_id)
        {
            if (null != EventFeedStopped)
                EventFeedStopped.Invoke(this, new EventStoppedEventArgs() { scheduled_event_id = scheduled_event_id, race_id = race_id });
        }

        public event ApiFeedEngineStartedDelegate LiveFeedEngineStarted;
        protected internal virtual void OnLiveFeedEngineStarted()
        {
            if (null != LiveFeedEngineStarted)
                LiveFeedEngineStarted.Invoke(this, EventArgs.Empty);
        }

        public event ApiFeedEngineStoppedDelegate LiveFeedEngineStopped;
        protected internal virtual void OnLiveFeedEngineStopped()
        {
            if (null != LiveFeedEngineStopped)
                LiveFeedEngineStopped.Invoke(this, EventArgs.Empty);
        }

        public event ApiFeedEngineErrorDelegate LiveFeedEngineError;
        protected internal virtual void OnLiveFeedEngineError(Exception ex)
        {
            if (null != LiveFeedEngineError)
                LiveFeedEngineError.Invoke(this, ex);
        }
        #endregion

        #region constants
        private const int UpdateTimerInterval = 10000;
        #endregion

        #region fields
        Timer updateTimer = null;

        IApiFeedProcessor harvester = null;

        IList<RaceEvent> eventSchedule = null;

        IList<FeedManager> managers = null;

        ApiEngineState state;
        #endregion

        #region properties
        public ApiEngineState State
        {
            get { return state; }
        }
        #endregion

        #region ctor
        public ApiFeedEngine()
            : this(UpdateTimerInterval)
        {
        }
        public ApiFeedEngine(int timerInterval)
        {
            managers = new List<FeedManager>();
            updateTimer = new Timer(timerInterval);
            updateTimer.Elapsed += updateTimer_Elapsed;
            SetStateReady();
        }
        #endregion

        #region error handler
        protected internal virtual void ErrorHandler(Exception ex)
        {
            WriteError(ex);
            OnLiveFeedEngineError(ex);
        }
        [Conditional("DEBUG")]
        void WriteError(Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        #endregion

        #region timer
        void StartTimer()
        {
            updateTimer.Start();
        }
        void StopTimer()
        {
            updateTimer.Stop();
        }
        void updateTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                UpdateSchedule();
            }
            catch (Exception ex)
            {
                this.ErrorHandler(ex);
            }
        }
        #endregion

        #region state
        void SetStateReady()
        {
            state = ApiEngineState.Ready;
        }
        void SetStateRunning()
        {
            state = ApiEngineState.Running;
        }
        void SetStatePaused()
        {
            state = ApiEngineState.Paused;
        }
        #endregion

        #region public methods
        public void Start()
        {
            try
            {
                if (state == ApiEngineState.Running)
                {
                    return;
                }
                else if (state == ApiEngineState.Ready)
                {
                    UpdateSchedule();
                    StartTimer();
                    SetStateRunning();
                    OnLiveFeedEngineStarted();
                }
                else if (state == ApiEngineState.Paused)
                {
                    StartTimer();
                }
            }
            catch (Exception ex)
            {
                this.ErrorHandler(ex);
            }
        }
        public void Stop()
        {
            try
            {
                StopTimer();
                StopAllEvents();
                SetStateReady();
                OnLiveFeedEngineStopped();
            }           
            catch (Exception ex)
            {
                this.ErrorHandler(ex);
            }
        }
        public void Pause()
        {
            try
            {
                StopTimer();
                SetStatePaused();
            }
            catch (Exception ex)
            {
                this.ErrorHandler(ex);
            }
        }
        #endregion

        #region update schedule
        void UpdateSchedule()
        {
            LoadEventSchedule();
            UpdateManagers();
        }
        #endregion

        #region update managers
        void UpdateManagers()
        {
            DateTime currentDateTime = DateTime.Now.AddMinutes(-10);

            foreach (RaceEvent evt in eventSchedule)
            {
                DateTime currentTimestamp = DateTime.Now.AddMinutes(5);

                if (evt.scheduled_event_start <= currentTimestamp && evt.scheduled_event_end > currentTimestamp && (evt.status == "Saved" || evt.status == "Stopped"))
                {
                    StartEvent(evt);
                    continue;

                }
                if (evt.scheduled_event_start <= currentTimestamp && (evt.status == "Running" || evt.status == "Stopped"))
                {
                    if (!managers.Any(m => m.scheduled_event_id == evt.scheduled_event_id))
                    {
                        StartEvent(evt);
                        continue;
                    }
                }
                if (evt.scheduled_event_start <= currentTimestamp && evt.scheduled_event_end <= currentTimestamp && evt.status == "Running")
                {
                    StopEvent(evt.scheduled_event_id);
                    continue;
                }
            }
        }
        #endregion

        #region event stop
        void StopAllEvents()
        {
            List<FeedManager> toBeRemoved = new List<FeedManager>();
            foreach (FeedManager manager in managers)
            {
                StopEvent(manager.scheduled_event_id);
                toBeRemoved.Add(manager);
            }
            foreach (FeedManager manager in toBeRemoved)
            {
                managers.Remove(manager);
            }
        }
        void StopEvent(int id)
        {
            UpdateEventStatus(id, "Stopped");

            FeedManager manager = managers.Where(m => m.scheduled_event_id == id).FirstOrDefault();
            if (null != manager)
                manager.Stop();
            Console.WriteLine("Stopped Event : " + id);
        }
        #endregion

        #region event start
        void StartEvent(RaceEvent evt)
        {
            if (!managers.Any(m => m.scheduled_event_id == evt.scheduled_event_id))
            {
                if (LaunchEventManager(evt))
                {
                    UpdateEventStatus(evt.scheduled_event_id, "Running");
                    Console.WriteLine("Started Event : " + evt.RaceSession.race_id);
                }
                else
                {
                    Console.WriteLine("Error Starting Event : " + evt.RaceSession.race_id);
                }
            }
        }
        bool LaunchEventManager(RaceEvent evt)
        {
            FeedManager manager = null;
            try
            {
                manager = InitializeManager((SeriesName)evt.RaceSession.Race.Series.series_id, evt.RaceSession.race_id);
                manager.scheduled_event_id = evt.scheduled_event_id;
                managers.Add(manager);
                manager.Start();
                return true;
            }
            catch (System.Net.WebException ex)
            {
                if (ex.Status == System.Net.WebExceptionStatus.ProtocolError)
                {
                    // 404 not found, probably wrong race_id. 
                    DisableEvent(evt.scheduled_event_id);
                    if (null!=manager)
                    {
                        managers.Remove(manager);
                        manager.Stop();
                    }
                    OnLiveFeedEngineError(ex);
                }
                else
                    this.ErrorHandler(ex); 
            }
            catch (Exception ex)
            {
                this.ErrorHandler(ex); 
            }

            return false;          
        }
        FeedManager InitializeManager(SeriesName SelectedSeries, int currentRaceId)
        {
            FeedManager manager = new FeedManager(SelectedSeries, currentRaceId);

            if (null != manager)
            {
                manager.Stop();
                manager.LiveFeedRawData -= manager_RawFeedEvent;
                manager.Dispose();
                if (null != manager) manager = null;
            }

            manager = new FeedManager(SelectedSeries, currentRaceId);
            manager.LiveFeedRawData += manager_RawFeedEvent;

            return manager;
        }
        #endregion

        #region api data received
        void manager_RawFeedEvent(object sender, string rawFeedData)
        {
            try
            {
                HarvestRawData(rawFeedData);
            }
            catch (Exception ex)
            {
                this.ErrorHandler(ex);
            }
        }
        void HarvestRawData(string rawData)
        {
            if (null == harvester)
                harvester = new LiveFeedHarvester();

            harvester.ProcessFeedData(rawData);
        }
        #endregion

        #region event data
        ScheduleDbContext GetContext()
        {
            return new ScheduleDbContext();
        }
        void UpdateEventStatus(int scheduled_event_id, string new_status)
        {
            using (var context = new ScheduleDbContext())
            {
                var eventInstance = context.RaceEvents.Include("RaceSession").Where(s => s.scheduled_event_id == scheduled_event_id).FirstOrDefault();
                string old_status = eventInstance.status;
                int race_id = eventInstance.RaceSession.race_id;
                eventInstance.status = new_status;

                context.SaveChanges();

                if (new_status == "Running")
                    this.OnEventFeedStarted(scheduled_event_id, race_id);
                else
                    this.OnEventFeedStopped(scheduled_event_id, race_id);
            }
        }
        void DisableEvent(int scheduled_event_id)
        {
            using (var context = new ScheduleDbContext())
            {
                var eventInstance = context.RaceEvents.Include("RaceSession").Where(s => s.scheduled_event_id == scheduled_event_id).FirstOrDefault();
                eventInstance.status = "Error";
                int race_id = eventInstance.RaceSession.race_id;
                eventInstance.enabled = false;

                context.SaveChanges();

                this.OnEventFeedStopped(scheduled_event_id, race_id);
            }
        }
        void LoadEventSchedule()
        {
            using (var context = GetContext())
            {
                DateTime today = DateTime.Now.Date;

                Expression<Func<RaceEvent, bool>> schedulePredicate = r => (
                    DbFunctions.TruncateTime(r.scheduled_event_start) >= today &&
                    DbFunctions.TruncateTime(r.scheduled_event_end) <= today &&
                    (r.status == "Saved" || r.status == "Running" || r.status == "Stopped") &&
                    r.enabled == true);

                eventSchedule = context.RaceEvents
                    .Include("RaceSession")
                    .Include("RaceSession.Race.Track")
                    .Include("RaceSession.Race.Series")
                    .Where(schedulePredicate).ToList();
                //s => s.enabled == true && s.scheduled_event_start >= today && (s.status == "Saved" || s.status == "Running")).ToList();
            }
        }
        #endregion
    }
}
