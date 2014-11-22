namespace NascarApi.Processors
{
    using NascarApi.Models.Leaderboard;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NascarApi.Data;
    using NascarApi.Models;

    public class LeaderboardFeedProcessor : FeedProcessor<LeaderboardModel>
    {
        public override FeedFormat FeedFormat
        {
            get
            {
                return FeedFormat.Leaderboard;
            }
        }

        public LeaderboardFeedProcessor(int season_id, int series_id, int race_id)
            : base(season_id, series_id, race_id)
        {

        }

        protected override void BeginProcessAsync(LeaderboardModel model)
        {

        }
        
    }
}