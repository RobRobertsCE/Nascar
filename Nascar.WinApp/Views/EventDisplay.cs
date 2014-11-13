using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nascar.Models;
using Nascar.WinApp.Views;

namespace Nascar.WinApp
{
    public partial class EventDisplay : UserControl
    {
        int last_green_start = 0;
        private LiveFeedModel last_model;

        private LiveFeedModel current_model;
        public LiveFeedModel Model
        {
            get
            {
                return current_model;
            }
            set
            {
                current_model = value;
                DisplayModel(current_model);
                last_model = current_model;
            }
        }
             
        public EventDisplay()
        {
            InitializeComponent();
        }

        void DisplayModel(LiveFeedModel model)
        {
            if (null == model) return;
            this.RunLabel.Text = model.run_name;
            this.TrackLabel.Text = model.track_name;
            this.lblLap.Text  = model.run_name;
            this.SeriesLabel.Text = ((SeriesName)model.series_id).ToString();
            this.SetFlagStatus((FlagState)model.flag_state);
            this.CautionsLabel.Text = String.Format("{0} for {1} laps", model.number_of_caution_segments.ToString(), model.number_of_caution_laps.ToString());
            this.lblLeaders .Text = String.Format("{0} with {1} lead changes", model.number_of_leaders.ToString(), model.number_of_lead_changes.ToString());
            this.lblLap.Text = String.Format("{0} of {1}, {2} to go", model.lap_number.ToString(), model.laps_in_race.ToString(), model.laps_to_go.ToString());
        }

        void SetFlagStatus(FlagState flag_status)
        {
            Color flagColor = Color.White;
            switch (flag_status)
            {
                case FlagState.None:
                    {
                        flagColor = Color.DarkGray;
                        break;
                    }
                case FlagState.Green:
                    {
                        flagColor = Color.Green;
                        break;
                    }
                case FlagState.Yellow:
                    {
                        flagColor = Color.Yellow;
                        break;
                    }
                case FlagState.Red:
                    {
                        flagColor = Color.Red;
                        break;
                    }
                case FlagState.White:
                    {
                        flagColor = Color.White;
                        break;
                    }
                case FlagState.Checkered:
                    {
                        flagColor = Color.WhiteSmoke;
                        break;
                    }
                case FlagState.Warm:
                    {
                        flagColor = Color.Orange;
                        break;
                    }
                case FlagState.Cold:
                    {
                        flagColor = Color.Blue;
                        break;
                    }
                default:
                    {
                        flagColor = Color.Gray;
                        break;
                    }
            }

            picRaceStatus.BackColor = flagColor;

            if (flag_status != FlagState.Green)
            {
                this.last_green_start = Model.lap_number;
            }
            else if ((null != last_model) && last_model.flag_state != 1 && flag_status == FlagState.Green)
                this.last_green_start = Model.lap_number;

            lblGreenLaps.Text = (Model.lap_number - this.last_green_start).ToString();            
        }

        public void SetRaceFallers(IList<VehicleView> movers)
        {
            lvWorstRace.Items.Clear();
            foreach (VehicleView view in movers)
            {
                ListViewItem lvi = new ListViewItem(view.Vehicle.vehicle_number);
                lvi.SubItems.Add(view.Vehicle.driver.full_name);
                lvi.SubItems.Add(view.RacePlusMinus.ToString());
                lvWorstRace.Items.Add(lvi);
            }
        }
        public void SetRaceMovers(IList<VehicleView> movers)
        {
            lvBestRace.Items.Clear();
            foreach (VehicleView view in movers)
            {
                ListViewItem lvi = new ListViewItem(view.Vehicle.vehicle_number);
                lvi.SubItems.Add(view.Vehicle.driver.full_name);
                lvi.SubItems.Add(view.RacePlusMinus.ToString());
                lvBestRace.Items.Add(lvi);
            }
            lvBestRace.Invalidate();
        }
        public void SetRunFallers(IList<VehicleView> movers)
        {
            lvWorstRun.Items.Clear();
            foreach (VehicleView view in movers)
            {
                ListViewItem lvi = new ListViewItem(view.Vehicle.vehicle_number);
                lvi.SubItems.Add(view.Vehicle.driver.full_name);
                lvi.SubItems.Add(view.RunPlusMinus.ToString());
                lvWorstRun.Items.Add(lvi);
            }
        }
        public void SetRunMovers(IList<VehicleView> movers)
        {
            lvBestRun.Items.Clear();
            foreach (VehicleView view in movers)
            {
                ListViewItem lvi = new ListViewItem(view.Vehicle.vehicle_number);
                lvi.SubItems.Add(view.Vehicle.driver.full_name);
                lvi.SubItems.Add(view.RunPlusMinus.ToString());
                lvBestRun.Items.Add(lvi);
            }
        }
        public void Set10LapAverage(IList<VehicleView> movers)
        {
            lvBest10LapAvg.Items.Clear();
            foreach (VehicleView view in movers)
            {
                ListViewItem lvi = new ListViewItem(view.Vehicle.vehicle_number);
                lvi.SubItems.Add(view.Vehicle.driver.full_name);
                lvi.SubItems.Add(view.TenLapAverage.ToString());
                lvBest10LapAvg.Items.Add(lvi);
            }
        }
        public void Set5LapAverage(IList<VehicleView> movers)
        {
            lvBest5LapAvg.Items.Clear();
            foreach (VehicleView view in movers)
            {
                ListViewItem lvi = new ListViewItem(view.Vehicle.vehicle_number);
                lvi.SubItems.Add(view.Vehicle.driver.full_name);
                lvi.SubItems.Add(view.FiveLapAverage.ToString());
                lvBest5LapAvg.Items.Add(lvi);
            }
        }
        public void Set20LapAverage(IList<VehicleView> movers)
        {
            lvBest20LapAvg.Items.Clear();
            foreach (VehicleView view in movers)
            {
                ListViewItem lvi = new ListViewItem(view.Vehicle.vehicle_number);
                lvi.SubItems.Add(view.Vehicle.driver.full_name);
                lvi.SubItems.Add(view.TwentyLapAverage.ToString());
                lvBest20LapAvg.Items.Add(lvi);
            }
        }
        public void SetBestLastLaps(IList<VehicleView> movers)
        {
            lvBestLastLap.Items.Clear();
            foreach (VehicleView view in movers)
            {
                ListViewItem lvi = new ListViewItem(view.Vehicle.vehicle_number);
                lvi.SubItems.Add(view.Vehicle.driver.full_name);
                lvi.SubItems.Add(view.Vehicle.last_lap_time.ToString());
                lvBestLastLap.Items.Add(lvi);
            }
        }


    }
}
