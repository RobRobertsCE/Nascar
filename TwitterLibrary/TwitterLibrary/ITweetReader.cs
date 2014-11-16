using System;
namespace TwitterLibrary
{
    internal interface ITweetReader
    {
        System.Collections.Generic.IEnumerable<Tweetinvi.Core.Interfaces.ITweet> GetTweets();
        void GetTweetsAsync();
        event TweetReceivedDelegate TweetReceived;
    }
}
