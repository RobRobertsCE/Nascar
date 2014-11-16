using Nascar.Api;
using Nascar.Api.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nascar.WinApp.Views;

namespace Nascar.WinApp
{
    public partial class StopwatchDialog : Form
    {
        string vehicle_number = "0";
        int lap_count = 0;

        public StopwatchDialog(string vehicleNumber)
        {
            InitializeComponent();

            this.vehicle_number = vehicleNumber;
        }
        public StopwatchDialog(string vehicleNumber, string driver_name)
        {
            InitializeComponent();

            this.vehicle_number = vehicleNumber;
            this.Text="Stopwatch - " + driver_name;
        }

        public void stopwatch_LiveFeedEvent(object sender, LiveFeedEventArgs e)
        {
            var model = e.LiveFeed;

            var vehicle = model.vehicles.Where(v => v.vehicle_number == this.vehicle_number).FirstOrDefault();

            if (null != vehicle)
            {
                if (lap_count == 0)
                {
                    for (int i = 0; i < vehicle.laps_completed; i++)
                    {
                        // add the new lap.
                        StopwatchData data = new StopwatchData(vehicle.vehicle_number);
                        data.LapNumber = i + 1;
                        data.ElapsedTime = model.elapsed_time;
                        if (i == vehicle.best_lap)
                        {
                            data.LapSpeed = vehicle.best_lap_speed;
                            data.LapTime = vehicle.best_lap_time;
                        }
                        else
                        {
                            data.LapSpeed = vehicle.last_lap_speed;
                            data.LapTime = vehicle.last_lap_time;
                        }

                        this.stopwatchView1.Data = data;
                    }
                }
                else if (lap_count < vehicle.laps_completed)
                {
                    for (int i = lap_count; i <= vehicle.laps_completed; i++)
                    {
                        // add the new lap.
                        StopwatchData data = new StopwatchData(vehicle.vehicle_number);
                        data.ElapsedTime = model.elapsed_time;
                        data.LapNumber = i + 1;
                        data.LapSpeed = vehicle.last_lap_speed;
                        data.LapTime = vehicle.last_lap_time;

                        this.stopwatchView1.Data = data;
                    }                 
                }

                lap_count = vehicle.laps_completed;
            }
        }
    }
}
