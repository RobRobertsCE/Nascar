using System.Timers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nascar.Models;
using Newtonsoft.Json;

namespace Nascar.Web
{
    public delegate void LiveFeedEventHandler(object sender, LiveFeedEventArgs e);
    public delegate void LiveFeedRawDataHandler(object sender, string rawData);
    public delegate void LiveFeedStartedHandler(object sender, EventArgs e);
    public delegate void LiveFeedStoppedHandler(object sender, EventArgs e);

    public class FeedManager: IDisposable 
    {
        #region events
        public event LiveFeedEventHandler LiveFeedEvent;
        protected virtual void OnLiveFeedEvent(LiveFeedModel model)
        {
            if (null != LiveFeedEvent)
            {
                LiveFeedEventArgs e = new LiveFeedEventArgs(model);
                LiveFeedEvent(this, e);
            }
        }

        public event LiveFeedRawDataHandler LiveFeedRawData;
        protected virtual void OnLiveFeedRawData(string feedData)
        {
            if (null != LiveFeedRawData)
            {
                LiveFeedRawData(this, feedData);
            }
        }

        public event LiveFeedStartedHandler LiveFeedStarted;
        protected virtual void OnLiveFeedStarted()
        {
            if (null != LiveFeedStarted)
            {
                LiveFeedStarted(this, EventArgs.Empty);
            }
        }

        public event LiveFeedStoppedHandler LiveFeedStopped;
        protected virtual void OnLiveFeedStopped()
        {
            if (null != LiveFeedStopped)
            {
                LiveFeedStopped(this, EventArgs.Empty);
            }
        } 
        #endregion

        #region consts
        const double DefaultTimerInterval = 10000; 
        #endregion

        #region fields
        Timer feedTimer = null; 
        IFeedClient feedClient = null;        
        #endregion

        #region props
        private double timerInterval = DefaultTimerInterval;
        public double TimerInterval
        {
            get
            {
                return timerInterval;
            }
            set
            {
                if (timerInterval == value) return;
                timerInterval = value;
                if (TimerIsRunning)
                {

                }
            }
        }

        protected internal bool TimerIsRunning
        {
            get
            {
                if (null == feedTimer || !feedTimer.Enabled)
                    return false;
                else
                    return true;
            }
        }

        public SeriesName Series { get; protected internal set; }

        public int race_id { get; protected internal set; }
        public int scheduled_event_id { get; set; }
        #endregion

        #region ctor/init
        public FeedManager(SeriesName series, int race_id)
        {
            this.Series = series;
            this.race_id = race_id;
            feedClient = new LiveFeedClient(this.Series, race_id);
        } 
        public FeedManager(SeriesName series)
        {
            this.Series = series;
            feedClient = new LiveFeedClient(this.Series);
        } 
        #endregion

        #region protected internal methods
        protected internal void InitializeTimer()
        {
            if (TimerIsRunning)
            {
                Stop();
                feedTimer.Dispose();
            }
            feedTimer = new Timer(TimerInterval);
            feedTimer.Elapsed += feedTimer_Elapsed;
        }

        protected internal void RestartTimer()
        {
            if (null == feedTimer)
            {
                InitializeTimer();
            }
            else if (TimerIsRunning)
            {
                Stop();
            }

            Start();
        } 
        #endregion

        #region public methods
        public void Start()
        {
            if (null == feedTimer)
            {
                InitializeTimer();
            }
            else if (TimerIsRunning)
                return;

            feedTimer.Start();

            OnLiveFeedStarted();

            BeginLiveFeedEvent();
        }

        public void Stop()
        {
            if (null != feedTimer && TimerIsRunning)
            {
                feedTimer.Stop();
            }

            OnLiveFeedStopped();
        } 
        #endregion

        #region timer elapsed
        protected internal void feedTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            BeginLiveFeedEvent();
        }
        protected internal void BeginLiveFeedEvent()
        {
            string rawFeed = feedClient.GetData();
            OnLiveFeedRawData(rawFeed);
            LiveFeedModel model = GetModel(rawFeed);
            OnLiveFeedEvent(model);
        }
        #endregion

        #region feedClient
        protected internal LiveFeedModel GetModel(string feedData)
        {
            return JsonConvert.DeserializeObject<LiveFeedModel>(feedData);
        }
        #endregion

        public void Dispose()
        {
            if (null != feedTimer)
            {
                feedTimer.Stop();
                feedTimer.Dispose();
            }
            if (feedClient!=null) feedClient.Dispose();
        }
    }
}
