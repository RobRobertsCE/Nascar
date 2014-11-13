using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nascar.Models;
using Nascar.Data;

namespace Nascar.Web
{
    public class ReplayClient : IFeedClient
    {
        LiveFeedReader reader;

        private SeriesName series;
        public SeriesName Series
        {
            get { return series; }
        }

        private int race_id;
        public int RaceId
        {
            get { return race_id; }
        }

        private int run_id = 0;
        public int RunId
        {
            get { return run_id; }
        }

        public ReplayClient(SeriesName series, int race_id)
        {
            this.series = series;
            this.race_id = race_id;

            reader = new LiveFeedReader(race_id);
        }
        public ReplayClient(SeriesName series, int race_id, int run_id)
        {
            this.series = series;
            this.race_id = race_id;
            this.run_id = run_id;

            reader = new LiveFeedReader(race_id, run_id);
        }

        public string GetData()
        {
            return reader.GetNextFeed();
        }

        public void Dispose()
        {
            reader = null;
        }
    }
}
