﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nascar.Web;
using Nascar.Models;
using Newtonsoft.Json;

namespace Nascar.WinApp
{
    public partial class Form1 : Form
    {
        string resultJson = string.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LiveFeedClient client = new LiveFeedClient(Series.Truck);

            resultJson = client.GetData();

            if (!String.IsNullOrEmpty(resultJson))
            {
                Console.WriteLine(resultJson);
            }
            else
            {
                Console.WriteLine("null");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                resultJson = Properties.Resources.cup_live_feed;
                LiveFeedModel model = JsonConvert.DeserializeObject<LiveFeedModel>(resultJson);
                ProcessFeedData(model);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        FeedManager manager = null;

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (null != manager)
                {
                    manager.Stop();
                    manager.LiveFeedStarted -= manager_LiveFeedStarted;
                    manager.LiveFeedStopped -= manager_LiveFeedStopped;
                    manager.LiveFeedEvent -= manager_LiveFeedEvent;
                    manager = null;
                }
                manager = new FeedManager(Series.Truck);
                manager.LiveFeedStarted += manager_LiveFeedStarted;
                manager.LiveFeedStopped += manager_LiveFeedStopped;
                manager.LiveFeedEvent += manager_LiveFeedEvent;

                manager.Start();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex);
            }
        }

        void ProcessFeedData(LiveFeedModel model)
        {
            RecordFeedData(model);
            DisplayFeedData(model);
        }

        void RecordFeedData(LiveFeedModel model)
        {

        }

        void DisplayFeedData(LiveFeedModel model)
        {

            liveFeedDisplay1.UpdateDisplay(model);

            listBox1.Items.Clear();
            listBox1.SuspendLayout();
            foreach (VehicleModel vehicle in model.vehicles.OrderBy((v) => v.running_position))
            {
                listBox1.Items.Add(vehicle.driver.full_name + ": " + vehicle.last_lap_speed + " MPH");                
            }     
   
        }
        
        void manager_LiveFeedEvent(object sender, LiveFeedEventArgs e)
        {
            try
            {
                textBox1.SetPropertyThreadSafe(() => textBox1.Text, e.LiveFeed.run_name);

                this.Invoke((MethodInvoker)delegate
                {
                    ProcessFeedData(e.LiveFeed);                   
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex);
            }
            finally
            {
                listBox1.ResumeLayout();
            }
        }

        void manager_LiveFeedStopped(object sender, EventArgs e)
        {

            Console.WriteLine("FeedManager Stopped");
        }

        void manager_LiveFeedStarted(object sender, EventArgs e)
        {
            Console.WriteLine("FeedManager Started");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            manager.Stop();
        }

    }
}
