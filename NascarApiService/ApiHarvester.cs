﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Runtime.InteropServices;

namespace Nascar.Api.WinServices
{
    public partial class ApiHarvester : ServiceBase
    {
        private const string EventLogSource = "NascarApiWinServices";
        private const string EventLogName = "NascarApiReader";

        private IApiFeedEngine _engine = null;

        private int eventId = 0;

        public ApiHarvester()
        {
            InitializeComponent();
            this.AutoLog = false;
            apiHarvesterEventLog = new System.Diagnostics.EventLog();
            if (!System.Diagnostics.EventLog.SourceExists(EventLogSource))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    EventLogSource, EventLogName);
            }
            apiHarvesterEventLog.Source = EventLogSource;
            apiHarvesterEventLog.Log = EventLogName;          
        }
       
        protected override void OnStart(string[] args)
        {
            apiHarvesterEventLog.WriteEntry("In OnStart");
            try
            {
                InitializeFeedHarvester();
                StartFeedHarvester();
                apiHarvesterEventLog.WriteEntry("ApiFeedEngine Started.");
            }
            catch (Exception ex)
            {
                apiHarvesterEventLog.WriteEntry(ex.ToString(), EventLogEntryType.Error, eventId++);
            }   
        }

        void InitializeFeedHarvester()
        {
            _engine = new ApiFeedEngine();

            _engine.EventFeedStarted += _engine_EventFeedStarted;
            _engine.EventFeedStopped += _engine_EventFeedStopped;
            _engine.LiveFeedEngineError += _engine_LiveFeedEngineError;
            _engine.LiveFeedEngineStarted += _engine_LiveFeedEngineStarted;
            _engine.LiveFeedEngineStopped += _engine_LiveFeedEngineStopped;
        }

        void _engine_LiveFeedEngineStopped(object sender, EventArgs e)
        {
            apiHarvesterEventLog.WriteEntry("LiveFeed Engine Stopped.", EventLogEntryType.Information, eventId++);
        }

        void _engine_LiveFeedEngineStarted(object sender, EventArgs e)
        {
            apiHarvesterEventLog.WriteEntry("LiveFeed Engine Started.", EventLogEntryType.Information, eventId++);
        }

        void _engine_LiveFeedEngineError(object sender, Exception e)
        {
            apiHarvesterEventLog.WriteEntry(String.Format("LiveFeed Engine Error: {0}", e.ToString()), EventLogEntryType.Error, eventId++);
        }

        void _engine_EventFeedStopped(object sender, EventStoppedEventArgs e)
        {
            apiHarvesterEventLog.WriteEntry(String.Format("EventFeed Stopped: {0}:{1}",e.race_id, e.scheduled_event_id), EventLogEntryType.Information, eventId++);
        }

        void _engine_EventFeedStarted(object sender, EventStartedEventArgs e)
        {
            apiHarvesterEventLog.WriteEntry(String.Format("EventFeed Started: {0}:{1}", e.race_id, e.scheduled_event_id), EventLogEntryType.Information, eventId++);
        }

        void StartFeedHarvester()
        {
            if (null != _engine)
                _engine.Stop();
           
            _engine.Start();
        }

        void ContinueFeedHarvester()
        {
            if (null != _engine)
                _engine.Start();
        }

        void StopFeedHarvester()
        {
            if (null != _engine)
                _engine.Stop();
        }

        void PauseFeedHarvester()
        {
            if (null != _engine)
                _engine.Pause();
        }

        protected override void OnStop()
        {
            apiHarvesterEventLog.WriteEntry("ApiFeedEngine Stopped");
            StopFeedHarvester();
        }

        protected override void OnContinue()
        {
            apiHarvesterEventLog.WriteEntry("ApiFeedEngine Continued");
            ContinueFeedHarvester();
        }

        protected override void OnPause()
        {
            apiHarvesterEventLog.WriteEntry("IApiFeedEngine Paused");
            PauseFeedHarvester();
        }

        protected override void OnShutdown()
        {
            apiHarvesterEventLog.WriteEntry("ApiFeedEngine Shutdown");
            StopFeedHarvester();
        }  
    }
}
