using System;
using System.Collections.Generic;
using System.Linq;
using Nascar.Data;
using Nascar.Models;
using Nascar.ServiceScheduler.Data;
using Nascar.Web;

namespace Nascar.ServiceScheduler.Logic
{
    public class NascarLiveFeedEngine : Nascar.ServiceScheduler.Logic.INascarLiveFeedEngine
    {
        LiveFeedHarvester harvester = null;
        IList<ScheduledEvent> startSchedule = null;
        IList<ScheduledEvent> stopSchedule = null;
        IList<FeedManager> managers = new List<FeedManager>();
        IList<int> race_ids = new List<int>();
        System.Timers.Timer updateTimer = null;
        int counter = 0;

        public NascarLiveFeedEngine()
        {
            updateTimer = new System.Timers.Timer(10000);
            updateTimer.Elapsed += updateTimer_Elapsed;
        }

        void updateTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                counter++;
                if (counter % 3 == 0)
                {

                }
                LoadStartSchedule();
                LoadStopSchedule();
                CheckForStarts();
                CheckForStops();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void Stop()
        {
            updateTimer.Stop();
            // stop all managers 
            List<FeedManager> stopped = new List<FeedManager>();
            foreach (FeedManager manager in managers)
            {
                StopEvent(manager.scheduled_event_id);
                stopped.Add(manager);
            }
            foreach (FeedManager manager in stopped)
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

            race_ids.Remove(id);
            Console.WriteLine("Stopped event : " + id);
        }

        public void Start()
        {
            LoadStartSchedule();
            CheckForStarts();
            updateTimer.Start();
        }

        void LoadStartSchedule()
        {
            using (var context = new Data.ServiceSchedulerDbContext())
            {
                DateTime rightBookingNow = DateTime.Now.AddHours(-1);
                DateTime rightBookingThen = rightBookingNow.AddMinutes(1);
                startSchedule = context.ScheduledEvents.Where(s => s.scheduled_event_start >= rightBookingNow).ToList();
            }
        }
        void CheckForStarts()
        {
            DateTime rightBookingNow = DateTime.Now.AddHours(-1);
            DateTime rightBookingThen = DateTime.Now.AddMinutes(5);
            foreach (ScheduledEvent evt in startSchedule.Where(s => s.scheduled_event_start > rightBookingNow && s.scheduled_event_start < rightBookingThen && s.status != "Running" && s.enabled == true))
            {
                Console.WriteLine(("DateCheck " + (evt.scheduled_event_start > rightBookingNow).ToString()));
                StartEvent(evt);
            }
        }
        void LoadStopSchedule()
        {
            using (var context = new Data.ServiceSchedulerDbContext())
            {
                DateTime rightBookingNow = DateTime.Now.AddHours(-1);
                DateTime rightBookingThen = rightBookingNow.AddMinutes(1);
                stopSchedule = context.ScheduledEvents.Where(s => s.scheduled_event_end > rightBookingNow && s.status == "Running" && s.enabled == true).ToList();
            }
        }
        void CheckForStops()
        {
            DateTime rightBookingNow = DateTime.Now;
            foreach (ScheduledEvent evt in stopSchedule.Where(s => s.scheduled_event_end < rightBookingNow))
            {
                StopEvent(evt.scheduled_event_id);
            }
        }
        void StartEvent(ScheduledEvent evt)
        {
            Console.WriteLine("Starting event : " + evt.race_id);
            UpdateEventStatus(evt.scheduled_event_id, "Running");
            LaunchEventManager(evt);
        }
        void UpdateEventStatus(int id, string status)
        {
            using (var context = new Data.ServiceSchedulerDbContext())
            {
                var eventInstance = context.ScheduledEvents.Where(s => s.scheduled_event_id == id).FirstOrDefault();

                eventInstance.status = status;

                context.SaveChanges();
            }
        }
        void LaunchEventManager(ScheduledEvent evt)
        {
            FeedManager manager = InitializeManager((SeriesName)evt.series_id, evt.race_id);
            manager.scheduled_event_id = evt.scheduled_event_id;
            managers.Add(manager);
            race_ids.Add(evt.race_id);
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
        void manager_RawFeedEvent(object sender, string rawFeedData)
        {
            try
            {
                HarvestRawData(rawFeedData);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        void HarvestRawData(string rawData)
        {
            if (null == harvester)
                harvester = new LiveFeedHarvester();

            harvester.ProcessLiveFeed(rawData);
        }
    }
}
