using Tweetinvi.Core;
using Tweetinvi.Core.Interfaces.Models.Parameters;

namespace Tweetinvi.Logic.Model.Parameters
{
    public class RetweetsOfMeTimelineRequestParameter : IRetweetsOfMeTimelineRequestParameters
    {
        public RetweetsOfMeTimelineRequestParameter()
        {
            MaximumNumberOfTweetsToRetrieve = 100;
            SinceId = TweetinviSettings.DEFAULT_ID;
            MaxId = TweetinviSettings.DEFAULT_ID;
            TrimUser = false;
            IncludeEntities = true;
            IncludeUserEntities = true;
        }

        public int MaximumNumberOfTweetsToRetrieve { get; set; }
        public long SinceId { get; set; }
        public long MaxId { get; set; }
        public bool TrimUser { get; set; }
        public bool IncludeEntities { get; set; }
        public bool IncludeUserEntities { get; set; }
    }
}