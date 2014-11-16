using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Core.Interfaces;

namespace TwitterLibrary
{
    internal class ListReader : TweetReader
    {
        long listId = 0;
        public long ListId
        {
            get
            {
                return listId;
            }
            private set
            {
                listId = value;
            }
        }

        public ListReader()
            : base()
        {   }
        public ListReader(long listId)
            : base()
        {
            this.ListId = listId;
        }
              
        public IEnumerable<ITweetList> GetLists()
        {
            var currentUser = User.GetLoggedUser();
            return TweetList.GetUserLists(loggedUser, true);

            //tweetLists.ForEach(list => Console.WriteLine("- {0}", list.FullName));
        }

        protected override IEnumerable<ITweet> GetTweetsInternal()
        {
            var list = TweetList.GetExistingList(listId);
            var tweets = list.GetTweets();
            return tweets;
        }
    }
}
