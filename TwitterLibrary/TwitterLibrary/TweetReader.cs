using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Core.Interfaces;

namespace TwitterLibrary
{
    internal abstract class TweetReader : TwitterLibrary.ITweetReader
    {
        public event TweetReceivedDelegate TweetReceived;

        protected virtual void OnTweetReceived(ITweet tweet)
        {
            if (null != TweetReceived)
                TweetReceived.Invoke(this, tweet);
        }

        protected  IDictionary<long, ITweet> tweetlist = new Dictionary<long, ITweet>();
        protected ILoggedUser loggedUser = null;
        protected long lastTweetId = -1;

        protected TweetReader()
        {
            var oauth_token = Provider.AccessToken;
            var oauth_token_secret = Provider.AccessTokenSecret;

            var oauth_consumer_key = Provider.ApiKey;
            var oauth_consumer_secret = Provider.ApiSecret;

            TwitterCredentials.SetCredentials(oauth_token, oauth_token_secret, oauth_consumer_key, oauth_consumer_secret);

            loggedUser = User.GetLoggedUser();
        }

        public virtual IEnumerable<ITweet> GetTweets()
        {
            return GetTweetsInternal();
        }

        public virtual void GetTweetsAsync()
        {
            var tweets = GetTweetsInternal();

            BroadcastTweets(tweets.ToList());
        }

        protected abstract IEnumerable<ITweet> GetTweetsInternal();

        protected virtual void BroadcastTweets(IList<ITweet> tweets)
        {
            if (null == tweets) return;

            foreach (var tweet in tweets.OrderBy(t => t.CreatedAt))
            {
                if (!tweetlist.ContainsKey(tweet.Id))
                {
                    tweetlist.Add(tweet.Id, tweet);
                    lastTweetId = tweet.Id;
                    OnTweetReceived(tweet);
                }
            }
        }
    }
}
