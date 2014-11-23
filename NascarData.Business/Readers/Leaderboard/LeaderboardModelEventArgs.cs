namespace NascarApi.Readers
{
    using System;
    using NascarApi.Models.Leaderboard ;

    public sealed class LeaderboardModelEventArgs : ApiModelEventArgs<LeaderboardModel>
    {        
        public LeaderboardModelEventArgs(LeaderboardModel model)
            : base(model)
        {   }
    }
}
