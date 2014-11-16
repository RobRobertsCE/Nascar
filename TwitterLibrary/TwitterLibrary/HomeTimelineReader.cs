using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Core.Enum;
using Tweetinvi.Core.Extensions;
using Tweetinvi.Core.Interfaces;
using Tweetinvi.Core.Interfaces.Controllers;
using Tweetinvi.Core.Interfaces.DTO;
using Tweetinvi.Core.Interfaces.Models;
using Tweetinvi.Core.Interfaces.Models.Parameters;

namespace TwitterLibrary
{
    

    public class HomeTimelineReader
    {
        public event TweetReceivedDelegate TweetReceived;
        protected virtual void OnTweetReceived(ITweet tweet)
        {
            if (null != TweetReceived)
                TweetReceived.Invoke(this, tweet);
        }

        ILoggedUser loggedUser = null;
        long lastHomeId = -1;
        long lastUserId = -1;

        public HomeTimelineReader()
        {
            var oauth_token = Provider.AccessToken;
            var oauth_token_secret = Provider.AccessTokenSecret;

            var oauth_consumer_key = Provider.ApiKey;
            var oauth_consumer_secret = Provider.ApiSecret;

            TwitterCredentials.SetCredentials(oauth_token, oauth_token_secret, oauth_consumer_key, oauth_consumer_secret);

            loggedUser = User.GetLoggedUser();
        }
        public IEnumerable<ITweet> UpdateHomeTimelineTweets()
        {
            var timelineParameter = Timeline.CreateHomeTimelineRequestParameter();
            timelineParameter.SinceId = lastHomeId;

            var tweets = loggedUser.GetHomeTimeline(timelineParameter);

            if (null==tweets)
            {
                Console.WriteLine(ExceptionHandler.GetLastException().TwitterDescription);
            }
            else
                lastHomeId = tweets.Max(t => t.Id);

            return tweets;
         
        }
        public void GetHomeTimelineTweets()
        {
            var timelineParameter = Timeline.CreateHomeTimelineRequestParameter();
            timelineParameter.SinceId = lastHomeId;

            var tweets = loggedUser.GetHomeTimeline(timelineParameter);

            if (null != tweets)
                DisplayHomeTweets(tweets.ToList());
            else
                Console.WriteLine("No tweets returned");
        }
        private void DisplayHomeTweets(IList<ITweet> tweets)
        {
            if (null == tweets) return;          

            foreach (var tweet in tweets.OrderBy(t=>t.CreatedAt))
            {
                lastHomeId = tweet.Id;
                OnTweetReceived(tweet);
            }
        }

        public void GetUserTimelineTweets()
        {
            var timelineParameter = Timeline.CreateUserTimelineRequestParameter(loggedUser);
            timelineParameter.IncludeRTS = false;
            timelineParameter.SinceId = lastUserId;

            var tweets = Timeline.GetUserTimeline(timelineParameter);
            if (null != tweets)
                DisplayUserTweets(tweets);
            else
                Console.WriteLine("No tweets returned");
        }
        private void DisplayUserTweets(IEnumerable<ITweet> tweets)
        {
            if (null == tweets) return;

            foreach (var tweet in tweets.OrderBy(t => t.CreatedAt))
            {
                lastUserId = tweet.Id;
                OnTweetReceived(tweet);
            }
        }

        public IEnumerable<ITweetList> GetLists()
        {
            var currentUser = User.GetLoggedUser();
            return TweetList.GetUserLists(loggedUser, true);

            //tweetLists.ForEach(list => Console.WriteLine("- {0}", list.FullName));
        }
        public IEnumerable<ITweet> GetTweetsFromList(long listId)
        {
            var list = TweetList.GetExistingList(listId);
            var tweets = list.GetTweets();
            return tweets;
            //tweets.ForEach(t => Console.WriteLine(t.Text));
        }
    }
}
