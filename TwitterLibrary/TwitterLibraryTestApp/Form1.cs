using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tweetinvi.Core.Interfaces;
using TwitterLibrary;

namespace TwitterLibraryTestApp
{
    public partial class Form1 : Form
    {
        TwitterReader r = null;
        HomeTimelineReader reader = null;

        IDictionary<long, ITweet> dT = new Dictionary<long, ITweet>();

        public Form1()
        {
            InitializeComponent();
            reader = new HomeTimelineReader();
            reader.TweetReceived += reader_TweetReceived;
        }

        void reader_TweetReceived(object sender, ITweet tweet)
        {
            if (!dT.ContainsKey(tweet.Id))
            {
                dT.Add(tweet.Id, tweet);
                DisplayTweet(tweet);
            }
        }
        void DisplayTweets(IEnumerable<ITweet> tweets)
        {
            try
            {
                this.flowLayoutPanel1.SuspendLayout();

                foreach (var item in tweets)
                {
                    DisplayTweet(item);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                this.flowLayoutPanel1.ResumeLayout();
            }
            
        }
        void DisplayTweet(ITweet tweet)
        {
            UpdateTweetTimes();
            ListTweet(tweet);
            AddTweetView(tweet);
        }

        private void AddTweetView(ITweet tweet)
        {
            TweetViewControl tv = new TweetViewControl(tweet);
            this.flowLayoutPanel1.Controls.Add(tv);
            this.flowLayoutPanel1.Controls.SetChildIndex(tv, 0);
        }
        void UpdateTweetTimes()
        {
            foreach (ListViewItem lvi in this.listView1.Items)
            {
                ITweet tweet = (ITweet)lvi.Tag;
                lvi.SubItems[3].Text = GetTimeSinceTweet(tweet.CreatedAt);
            }
        }
        void ListTweet(ITweet tweet)
        {
            ListViewItem lvi = new ListViewItem(tweet.Id.ToString());
            lvi.Tag = tweet;
            lvi.SubItems.Add(tweet.Creator.Name);
            lvi.SubItems.Add("@" + tweet.Creator.ScreenName);
            lvi.SubItems.Add(tweet.CreatedAt.ToString());
            lvi.SubItems.Add(GetTimeSinceTweet(tweet.CreatedAt));
            lvi.SubItems.Add(FormatTweetForList(tweet));
            this.listView1.Items.Insert(0, lvi);
        }
        string FormatTweetForList(ITweet tweet)
        {
            if (null != tweet.Entities.Medias)
            {
                foreach (var mediaItem in tweet.Entities.Medias)
                {
                    Console.WriteLine(mediaItem.MediaType);
                    if (mediaItem.MediaType == "photo")
                    {

                    }
                }
            }
            return tweet.Text;
        }
        string GetTimeSinceTweet(DateTime tweetTime)
        {
            var rightNow = DateTime.Now;
            var ts = rightNow.Subtract(tweetTime);
            if (ts.Days > 0)
            {
                return ts.ToString("%d") + " Days";
            }
            else if (ts.Hours > 0)
            {
                return ts.ToString("%h") + " h";
            }
            else if (ts.Minutes > 0)
            {
                return ts.ToString("%m") + " m";
            }
            else
            {
                return ts.ToString("%s") + " s";
            }
        }
        void AppendTweet(ITweet tweet)
        {
            textBox1.AppendText(FormatTweetForText(tweet));
        }
        string FormatTweetForText(ITweet tweet)
        {
            return String.Format("{0} {1,-20}:{2}\r\n", tweet.IdStr, tweet.Creator.ScreenName, tweet.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                reader.GetHomeTimelineTweets();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                reader.GetUserTimelineTweets();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void btnLoadLists_Click(object sender, EventArgs e)
        {
            try
            {
                IEnumerable<ITweetList> lists = reader.GetLists();
                this.cboLists.DisplayMember = "FullName";
                this.cboLists.ValueMember = "Id";
                this.cboLists.DataSource = lists;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void btnDisplayListTweets_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cboLists.SelectedItem == null) return;
                ITweetList list = (ITweetList)this.cboLists.SelectedItem;
                var listTweets = reader.GetTweetsFromList(list.Id);
                if (null == listTweets) return;
                DisplayTweets(listTweets);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
            if (button3.Text == "Timer On")
                button3.Text = "Timer Off";
            else
                button3.Text = "Timer On";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                var tweets = reader.UpdateHomeTimelineTweets();
                
                if (null != tweets)
                    DisplayTweets(tweets.ToList());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
