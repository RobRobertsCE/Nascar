using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Tweetinvi.Core.Interfaces;
using Tweetinvi.Core.Interfaces.Models.Entities;
using TwitterLibrary;

namespace TwitterLibrary
{
    public partial class TweetViewList : UserControl
    {
        BindingList<ITweet> dataSource;

        TweetViewListDriver driver;

        public TweetViewList()
        {
            InitializeComponent();

            driver = new TweetViewListDriver( this);
        }

        public TweetViewList(long listId)
            : this()
        {
            ListReader reader = new ListReader();

            driver = new TweetViewListDriver(reader, this);
        }

        void InitializeTweetViewList()
        {
            dataSource = new BindingList<ITweet>();
            dataSource.AllowNew = true;
            dataSource.AllowEdit = true;
            dataSource.AllowRemove = true;
            dataSource.RaiseListChangedEvents = true;

            dataSource.ListChanged += dataSource_ListChanged;
        }

        void ExceptionHandler(Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

        public void Start()
        {
            driver.Start();
        }

        public void Stop()
        {
            driver.Stop();
        }

        internal void AddTweet(ITweet tweet)
        {
            try
            {
                dataSource.Add(tweet);
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        internal void RemoveTweet(ITweet tweet)
        {
            try
            {
                dataSource.Remove(tweet);
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        void dataSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded)
            {
                InsertTweetView(e.NewIndex);
            }
            else if (e.ListChangedType == ListChangedType.ItemChanged)
            {
                UpdateTweetView(e.NewIndex);
            }
            else if (e.ListChangedType == ListChangedType.ItemDeleted)
            {
                RemoveTweetView(e.NewIndex);
            }
            else if (e.ListChangedType == ListChangedType.Reset)
            {
                ReloadAllTweets();
            }
            else if (e.ListChangedType == ListChangedType.ItemMoved)
            {
                Console.WriteLine("Item Moved in Binding List");
            }
        }

        void ReloadAllTweets()
        {
            try
            {
                this.flpTweets.SuspendLayout();
                this.flpTweets.Controls.Clear();
                foreach (ITweet item in dataSource.OrderBy(t=>t.CreatedAt))
                {
                    TweetViewControl view = new TweetViewControl(item);
                    this.flpTweets.Controls.Add(view);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
            finally
            {
                this.flpTweets.ResumeLayout();
            }
        }

        void InsertTweetView(int tweetIdx)
        {
            try
            {
                TweetViewControl view = new TweetViewControl(dataSource[tweetIdx]);
                this.flpTweets.Controls.Add(view);
                this.flpTweets.Controls.SetChildIndex(view, 0);
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        void UpdateTweetView(int tweetIdx)
        {
            try
            {
                var view = this.flpTweets.Controls.OfType<TweetViewControl>().Where(c => c.TweetId == 0).FirstOrDefault();

                if (null == view)
                    InsertTweetView(tweetIdx);
                else
                    view.Tweet = dataSource[tweetIdx];
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        void RemoveTweetView(int tweetIdx)
        {
            try
            {
                var view = this.flpTweets.Controls.OfType<TweetViewControl>().Where(c => c.TweetId == 0).FirstOrDefault();

                if (null != view)
                    this.flpTweets.Controls.Remove(view);
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
    }
}
