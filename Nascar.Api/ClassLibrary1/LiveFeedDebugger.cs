using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nascar.Data;
using Nascar.Models;

namespace Nascar.Api
{
    public class LiveFeedDebugger : ILiveFeedProcessor
    {
        IList<LiveFeedModel> LiveFeedList { get; set; }
        IDictionary<string, FeedData> FeedDataList { get; set; }
        LiveFeedModel LastLiveFeed { get; set; }
        Track CurrentTrack { get; set; }
        Series CurrentSeries { get; set; }
        Session CurrentSession { get; set; }
        Race CurrentRace { get; set; }
        NascarDbContext NewContext
        {
            get
            {
                return new NascarDbContext();
            }
        }

        private NascarDbContext _context = null;
        protected internal virtual NascarDbContext Context
        {
            get
            {
                if (null == _context)
                    _context = new NascarDbContext();

                return _context;
            }
        }

        public LiveFeedDebugger()
        {
            LiveFeedList = new List<LiveFeedModel>();
            FeedDataList = new Dictionary<string, FeedData>();
            LastLiveFeed = new LiveFeedModel();
        }

        public void ProcessLiveFeed(LiveFeedModel model)
        {
            try
            {
                LiveFeedList.Add(model);
                ProcessModel(model);
                LastLiveFeed = model;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        void ProcessModel(LiveFeedModel model)
        {
            FeedData fd = new FeedData(model);
            if (!FeedDataList.ContainsKey(fd.runkey))
            {
                FeedDataList.Add(fd.runkey, fd);
            }
        }

        public void Display()
        {
            StringBuilder sb = new StringBuilder();

            foreach (FeedData fd in FeedDataList.Values.OrderBy(v => v.track_id).ThenBy(v => v.run_id))
            {
                sb.AppendLine(fd.ToString());
            }

            Console.WriteLine(sb.ToString());
        }
    }

    public class FeedData
    {
        public int series_id { get; set; }
        public int track_id { get; set; }
        public string track_name { get; set; }
        public int race_id { get; set; }
        public int run_id { get; set; }
        public string run_name { get; set; }
        public int run_type { get; set; }

        public string racekey
        {
            get
            {
                return string.Format("{0}-{1}-{2}", series_id, track_id, race_id);
            }
        }
        public string runkey
        {
            get
            {
                return string.Format("{0}-{1}-{2}-{3}", series_id, track_id, race_id, run_id);
            }
        }

        public FeedData()
        {

        }

        public FeedData(LiveFeedModel model)
        {
            this.series_id = model.series_id;
            this.track_id = model.track_id;
            this.track_name = model.track_name;
            this.race_id = model.race_id;
            this.run_id = model.run_id;
            this.run_name = model.run_name;
            this.run_type = model.run_type;
        }

        public virtual string ToString()
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6}", series_id, track_id, track_name, race_id, run_id, run_type, run_name);
        }
    }
}
