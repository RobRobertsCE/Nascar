using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NascarData.Business;

namespace NascarData.TestApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IFeedProcessor processor = new FeedProcessor(3, 4374);
            using (Nascar.Data.NascarDbContext context = new Nascar.Data.NascarDbContext("NascarContext"))
            {
                var feedData = context.RawFeeds.Where(r => r.RawFeedKey == 2895).FirstOrDefault();
                processor.processFeedData(feedData.RawFeedData);
                feedData = context.RawFeeds.Where(r => r.RawFeedKey == 2896).FirstOrDefault();
                processor.processFeedData(feedData.RawFeedData);
            }
           
            

        }
    }
}
