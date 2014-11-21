using System;
using System.Drawing;
using System.Windows.Forms;
using Tweetinvi.Core.Interfaces;
using Tweetinvi.Core.Interfaces.Models.Entities;

namespace TwitterLibraryTestApp
{
    public partial class TweetViewControl : UserControl
    {
        public TweetViewControl()
        {
            InitializeComponent();
        }
        public TweetViewControl(ITweet tweet)
            : this()
        {
            this.label1.Text = tweet.Creator.Name;
            this.label2.Text = "@" + tweet.Creator.ScreenName;
            this.label3.Text = GetTimeSinceTweet(tweet.CreatedAt);
            this.pictureBox1.Image = GetProfileImage(tweet);
            this.tweetBox.Text = tweet.Text;
            if (null != tweet.Entities.Medias)
            {
                foreach (var mediaItem in tweet.Entities.Medias)
                {
                    Console.WriteLine(mediaItem.MediaType);
                    if (mediaItem.MediaType == "photo")
                    {
                        this.pictureBox2.Image = GetMediaImage(mediaItem);
                        pictureBox2.Size = new Size(48, 48);
                        break;
                    }
                }
            }
            else
            {
                pictureBox2.Visible = false;
                this.Height = 58;
            }
        }
        string GetTimeSinceTweet(DateTime tweetTime)
        {
            var rightNow = DateTime.Now;
            var ts = rightNow.Subtract(tweetTime);
            if (ts.Days > 0)
            {
                return " - " + ts.ToString("%d") + " Days";
            }
            else if (ts.Hours > 0)
            {
                return " - " + ts.ToString("%h") + "h";
            }
            else if (ts.Minutes > 0)
            {
                return " - " + ts.ToString("%m") + "m";
            }
            else
            {
                return " - " + ts.ToString("%s") + "s";
            }
        }
        private Image GetProfileImage(ITweet tweet)
        {
            Image img = null;
            var imageStream = tweet.Creator.GetProfileImageStream();
            if (imageStream.CanRead)
            {
                 img = Image.FromStream(imageStream);
            }

            return img;
        }

        private Image GetMediaImage(IMediaEntity mediaEntity)
        {
            return ImageLoader.GetImageFromUrl(mediaEntity.MediaURL);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = ((LinkLabel)sender).Text;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (pictureBox2.SizeMode== PictureBoxSizeMode.Zoom )
            {
                pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
            }
            else
            {
                pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }
    }
}
