using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nascar.Data
{
    public class LiveFeedReader
    {
        int race_id = 0;
        int run_id = 0;
        private int dataIdx = 0;
        private List<string> feeds;

        public bool HasData
        {
            get
            {
                return ((null!=feeds) && (feeds.Count>0));
            }
        }

        public LiveFeedReader(int race_id)
        {
            this.race_id = race_id;

            LoadFeedData();
        }

        public LiveFeedReader(int race_id, int run_id)
        {
            this.race_id = race_id;
            this.run_id = run_id;

            LoadFeedData();
        }

        public string GetNextFeed()
        {
            string feedData = GetFeedData(dataIdx);
            dataIdx++;
            return feedData;
        }

        string GetFeedData(int idx)
        {
            string feed = String.Empty;
            if (idx < feeds.Count)
            {
                feed = feeds[idx];
            }
            return feed;
        }

        void LoadFeedData()
        {
            feeds = new List<string>();
            using (NascarDbContext context = new NascarDbContext())
            {
                string raceFilter = String.Format("\"race_id\":{0}", race_id);
                string runTypeFilter = "\"run_type\":3";
                string runFilter = String.Format("\"run_id\":{0}", run_id);
                if (run_id == 0)
                {
                    feeds = context.RawFeeds.Where(f => f.RawFeedData.Contains(raceFilter) && f.RawFeedData.Contains(runTypeFilter)).Take(100).Select(f => f.RawFeedData).ToList();
                }
                else
                {
                    feeds = context.RawFeeds.Where(f => f.RawFeedData.Contains(raceFilter) && f.RawFeedData.Contains(runFilter)).Take(100).Select(f => f.RawFeedData).ToList();
                }
            }
        }
    }
}
