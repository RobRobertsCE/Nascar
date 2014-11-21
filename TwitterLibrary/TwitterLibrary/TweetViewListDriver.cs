using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TwitterLibrary
{
    internal class TweetViewListDriver
    {
        ITweetReader reader;
        TweetViewList viewList;
        Timer updateTimer;

        double interval = 5000;
        public double Interval
        {
            get
            {
                return interval;
            }
            set
            {
                interval = value;
                if (updateTimer.Enabled)
                {
                    Stop();
                    InitializeTimer();
                    Start();
                }
            }
        }

        public TweetViewListDriver(TweetViewList viewList)
        {
            this.viewList = viewList;
            reader = new HomeReader();
        }

        public TweetViewListDriver(ITweetReader reader, TweetViewList viewList)
        {
            this.viewList = viewList;
            this.reader = reader;
        }

        void InitializeTweetViewListDriver()
        {
            reader.TweetReceived += reader_TweetReceived;
        }
        
        void InitializeTimer()
        {
            if (null != updateTimer)
            {
                updateTimer.Enabled = false;
                updateTimer.Elapsed -= updateTimer_Elapsed;
                updateTimer.Dispose();
            }

            updateTimer = new Timer(Interval);
            updateTimer.Elapsed += updateTimer_Elapsed; 
        }

        public void Start()
        {
            if (null == updateTimer)
                InitializeTimer();

            updateTimer.Enabled = true;
        }

        public void Stop()
        {
            updateTimer.Enabled = false;
        }

        void updateTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            BeginGetTweetsAsync();
        }

        void BeginGetTweetsAsync()
        {
            reader.GetTweetsAsync();
        }

        void reader_TweetReceived(object sender, Tweetinvi.Core.Interfaces.ITweet tweet)
        {
            viewList.AddTweet(tweet);
        }
    }
}
