using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using Nascar.Data;
using Nascar.Models;
using Nascar.Data.Schedule;
using Nascar.Api;

namespace Nascar.ServiceScheduler.Logic
{
    public class NascarLiveFeedEngine : Nascar.ServiceScheduler.Logic.INascarLiveFeedEngine
    {
        #region Constants
        private const int UpdateTimerInterval = 10000;
        #endregion

        #region Events
        public EventStatusChangedDelegate EventStatusChanged;
        protected internal virtual void OnEventStatusChanged(int scheduled_event_id, string new_status, string old_status)
        {
            if (null != EventStatusChanged)
                EventStatusChanged.Invoke(this, new EventStatusChangedEventArgs() { scheduled_event_id = scheduled_event_id, new_status = new_status, old_status = old_status });
        }

        public LiveFeedEngineStartedDelegate LiveFeedEngineStarted;
        protected internal virtual void OnLiveFeedEngineStarted()
        {
            if (null != LiveFeedEngineStarted)
                LiveFeedEngineStarted.Invoke(this, EventArgs.Empty);
        }

        public LiveFeedEngineStoppedDelegate LiveFeedEngineStopped;
        protected internal virtual void OnLiveFeedEngineStopped()
        {
            if (null != LiveFeedEngineStopped)
                LiveFeedEngineStopped.Invoke(this, EventArgs.Empty);
        }

        public LiveFeedEngineErrorDelegate LiveFeedEngineError;
        protected internal virtual void OnLiveFeedEngineError(Exception ex)
        {
            if (null != LiveFeedEngineError)
                LiveFeedEngineError.Invoke(this, ex);
        }
        #endregion

        #region Fields
        LiveFeedHarvester harvester = null;
        IList<RaceEvent> eventSchedule = null;
        IList<FeedManager> managers = null;
        System.Timers.Timer updateTimer = null; 
        #endregion

        #region Ctor
        public NascarLiveFeedEngine()
            :this(UpdateTimerInterval)
        {
        }

        public NascarLiveFeedEngine(int timerInterval)
        {
            managers = new List<FeedManager>();
            updateTimer = new System.Timers.Timer(timerInterval);
            updateTimer.Elapsed += updateTimer_Elapsed;
        }
        #endregion

        #region Error handler
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

        #region Update Timer
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

        #region Public Methods [start/stop] 
        public void Start()
        {
            try
            {
                UpdateSchedule();
                StartTimer();
                OnLiveFeedEngineStarted();
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
                OnLiveFeedEngineStopped();
            }
            catch (Exception ex)
            {
                this.ErrorHandler(ex);
            }              
        }
        #endregion

        #region Update Schedule & Managers
        void UpdateSchedule()
        {
            LoadEventSchedule();
            UpdateManagers();
        }
        void UpdateManagers()
        {
            DateTime currentDateTime = DateTime.Now;
            foreach (RaceEvent evt in eventSchedule.Where(s => s.scheduled_event_start >= currentDateTime && s.status == "Saved"))
            {
                StartEvent(evt);
            }
            foreach (RaceEvent evt in eventSchedule.Where(s => s.scheduled_event_start <= currentDateTime && s.status == "Running"))
            {
                if (!managers.Any(m => m.scheduled_event_id == evt.scheduled_event_id))
                {
                    StartEvent(evt);
                }
            }
            foreach (RaceEvent evt in eventSchedule.Where(s => s.scheduled_event_end < currentDateTime && s.status == "Running"))
            {
                StopEvent(evt.scheduled_event_id);
            }
        }
        #endregion

        #region Event Stop
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

        #region Event Start
        void StartEvent(RaceEvent evt)
        {
            if (managers.Any(m => m.scheduled_event_id != evt.scheduled_event_id))
            {
                LaunchEventManager(evt);
                UpdateEventStatus(evt.scheduled_event_id, "Running");
                Console.WriteLine("Started Event : " + evt.RaceSession.race_id);
            }
        }
        void LaunchEventManager(RaceEvent evt)
        {
            FeedManager manager = InitializeManager((SeriesName)evt.RaceSession.Race.Series.series_id, evt.RaceSession.race_id);
            manager.scheduled_event_id = evt.scheduled_event_id;
            managers.Add(manager);
            manager.Start();
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

        #region Event DataReceived
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

            harvester.ProcessLiveFeed(rawData);
        } 
        #endregion

        #region Event Data 
        ScheduleDbContext GetContext()
        {
            return new ScheduleDbContext();
        }
        void UpdateEventStatus(int scheduled_event_id, string new_status)
        {
            using (var context = new ScheduleDbContext())
            {
                var eventInstance = context.RaceEvents.Where(s => s.scheduled_event_id == scheduled_event_id).FirstOrDefault();
                string old_status = eventInstance.status;
                eventInstance.status = new_status;

                context.SaveChanges();

                OnEventStatusChanged(scheduled_event_id, new_status, old_status);
            }           
        }
        void LoadEventSchedule()
        {
            using (var context = GetContext())
            {
                DateTime today = DateTime.Now.Date;
                eventSchedule = context.RaceEvents.Where(s => s.enabled == true && s.scheduled_event_start.Date == today && (s.status == "Saved" || s.status == "Running")).ToList();
            }
        }
        #endregion
    }
}
