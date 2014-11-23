using Nascar.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NascarApi.Readers
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
                if (run_id == 0)
                {
                    feeds = context.RawFeedRecords.Where(f => f.race_id == race_id).OrderBy(f => f.elapsed_time).Select(f => f.data).ToList();
                }
                else
                {
                    feeds = context.RawFeedRecords.Where(f => f.race_id == race_id && f.run_id == run_id).OrderBy(f=>f.elapsed_time).Select(f => f.data).ToList();
                }
            }
        }
    }
}
