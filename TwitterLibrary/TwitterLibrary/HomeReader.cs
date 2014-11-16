using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Core.Interfaces;

namespace TwitterLibrary
{
    internal class HomeReader : TweetReader
    {
        public HomeReader()
            : base()
        {        
        }

        protected override IEnumerable<ITweet> GetTweetsInternal()
        {
            var timelineParameter = Timeline.CreateHomeTimelineRequestParameter();
            timelineParameter.SinceId = lastTweetId;

            var tweets = loggedUser.GetHomeTimeline(timelineParameter);

            if (null == tweets)
            {
                Console.WriteLine(ExceptionHandler.GetLastException().TwitterDescription);
            }
            else
                lastTweetId = tweets.Max(t => t.Id);

            return tweets;         
        }
    }
}
