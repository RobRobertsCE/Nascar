using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NascarApi.Data;
using NascarApi.Models.LiveFeed;
using NascarApi.Processors;
using NascarApi.Readers;

namespace NascarApi
{
    public class EventFeedManager : IFeed
    {
        #region events
        public event ProcessingCompleteDelegate ProcessingComplete;
        protected virtual void OnProcessingComplete(object sender)
        {
            if (null != ProcessingComplete)
                ProcessingComplete.Invoke(sender, EventArgs.Empty);
        }
        void processor_ProcessingComplete(object sender, EventArgs e)
        {
            this.OnProcessingComplete(sender);
        }

        public event ProcessingErrorDelegate ProcessingError;
        protected virtual void OnProcessingError(object sender, Exception ex)
        {
            if (null != ProcessingError)
                ProcessingError.Invoke(sender, ex);
        }
        void processor_ProcessingError(object sender, Exception ex)
        {
            this.OnProcessingError(sender, ex);
        }

        public event ArchivingCompleteDelegate ArchivingComplete;
        protected virtual void OnArchivingComplete(object sender)
        {
            if (null != ArchivingComplete)
                ArchivingComplete.Invoke(sender, EventArgs.Empty);
        }
        void processor_ArchivingComplete(object sender, EventArgs e)
        {
            this.OnArchivingComplete(sender);
        }
        #endregion

        #region enums
        [Flags()]
        public enum Feeds
        {
            Flag = 0,
            Live = 1 << 0,
            Leaderboard = 1 << 1,
            Points = 1 << 2,
            Qualifying = 1 << 3,
            Weather = 1 << 4,
            All = Feeds.Flag | Feeds.Live | Feeds.Leaderboard | Feeds.Points | Feeds.Qualifying | Feeds.Weather
        }
        #endregion

        #region fields
        IList<IFeed> FeedProcessors;
        #endregion

        #region properties
        public Feeds FeedStreams { get; protected set; }

        int raceId;
        public int race_id
        {
            get { return raceId; }
            protected set { raceId = value; }
        }

        int seriesId;
        public int series_id
        {
            get { return seriesId; }
            protected set { seriesId = value; }
        }

        int seasonId;
        public int season_id
        {
            get { return seasonId; }
            protected set { seasonId = value; }
        }
        #endregion

        public EventFeedManager(int season_id, int series_id, int race_id, Feeds feeds)
        {
            this.FeedStreams = feeds;
            this.season_id = season_id;
            this.series_id = series_id;
            this.race_id = race_id;

            this.InitializeEventFeedManager();
        }

        private void InitializeEventFeedManager()
        {
            FeedProcessors = new List<IFeed>();

            if (this.FeedStreams.HasFlag(Feeds.Flag))
            {
                var processor = new FlagFeedProcessor(this.season_id, this.series_id, this.race_id);
                processor.ArchivingComplete += processor_ArchivingComplete;
                processor.ProcessingComplete += processor_ProcessingComplete;
                processor.ProcessingError += processor_ProcessingError;
                FeedProcessors.Add(processor);
            }
            if (this.FeedStreams.HasFlag(Feeds.Live))
            {
                var processor = new LiveFeedProcessor(this.season_id, this.series_id, this.race_id);
                processor.ArchivingComplete += processor_ArchivingComplete;
                processor.ProcessingComplete += processor_ProcessingComplete;
                processor.ProcessingError += processor_ProcessingError;
                FeedProcessors.Add(processor);
            }
            if (this.FeedStreams.HasFlag(Feeds.Leaderboard))
            {
                var processor = new LeaderboardFeedProcessor(this.season_id, this.series_id, this.race_id);
                processor.ArchivingComplete += processor_ArchivingComplete;
                processor.ProcessingComplete += processor_ProcessingComplete;
                processor.ProcessingError += processor_ProcessingError;
                FeedProcessors.Add(processor);
            }
            if (this.FeedStreams.HasFlag(Feeds.Points))
            {
                var processor = new PointsFeedProcessor(this.season_id, this.series_id, this.race_id);
                processor.ArchivingComplete += processor_ArchivingComplete;
                processor.ProcessingComplete += processor_ProcessingComplete;
                processor.ProcessingError += processor_ProcessingError;
                FeedProcessors.Add(processor);
            }
            if (this.FeedStreams.HasFlag(Feeds.Qualifying))
            {
                var processor = new QualifyingFeedProcessor(this.season_id, this.series_id, this.race_id);
                processor.ArchivingComplete += processor_ArchivingComplete;
                processor.ProcessingComplete += processor_ProcessingComplete;
                processor.ProcessingError += processor_ProcessingError;
                FeedProcessors.Add(processor);
            }
            if (this.FeedStreams.HasFlag(Feeds.Weather))
            {
                var processor = new WeatherFeedProcessor(this.season_id, this.series_id, this.race_id);
                processor.ArchivingComplete += processor_ArchivingComplete;
                processor.ProcessingComplete += processor_ProcessingComplete;
                processor.ProcessingError += processor_ProcessingError;
                FeedProcessors.Add(processor);
            }
        }

        public void Start()
        {

        }

        public void Stop()
        {

        }

    }
    public class FeedSync
    {
        SeriesType SelectedSeries;
        int race_id;
        ApiFeedType feed;

        public IFeedProcessor<LiveFeedModel> FeedProcessor { get; set; }
        public LiveFeedManager manager { get; set; }

        public FeedSync(SeriesType SelectedSeries, int race_id, ApiFeedType feed)           
        {
            this.SelectedSeries = SelectedSeries;
            this.race_id = race_id;
            this.feed = feed;
        }

        void InitializeManager()
        {
            if (null != manager)
            {
                manager.Stop();
                manager.LiveFeedStarted -= manager_LiveFeedStarted;
                manager.LiveFeedStopped -= manager_LiveFeedStopped;
                manager.LiveFeedEvent -= manager_LiveFeedEvent;
                manager.Dispose();
                if (null != manager) manager = null;
            }
            manager = new LiveFeedManager(this.SelectedSeries, this.race_id, this.feed);
            manager.LiveFeedStarted += manager_LiveFeedStarted;
            manager.LiveFeedStopped += manager_LiveFeedStopped;

            manager.LiveFeedEvent += manager_LiveFeedEvent;
        }

        void manager_LiveFeedEvent(object sender, LiveFeedEventArgs e)
        {
            FeedProcessor.ProcessModel(e.LiveFeed);
        }

        void manager_LiveFeedStarted(object sender, EventArgs e)
        {

        }

        void manager_LiveFeedStopped(object sender, EventArgs e)
        {

        }
    }
}
