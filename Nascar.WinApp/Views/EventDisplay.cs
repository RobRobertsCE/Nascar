using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nascar.Api.Models;
using Nascar.WinApp.Views;

namespace Nascar.WinApp
{
    public partial class EventDisplay : UserControl, INotifyPropertyChanged
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

        public bool ShowRunStats
        {
            get
            {
                return pnlRunStats.Visible;
            }
            set
            {
                pnlRunStats.Visible = value;
            }
        }
        public bool ShowRaceStats
        {
            get
            {
                return pnlRaceStats.Visible;
            }
            set
            {
                pnlRaceStats.Visible = value;
            }
        }
        public bool ShowAverages
        {
            get
            {
                return pnlAverages.Visible;
            }
            set
            {
                pnlAverages.Visible = value;
            }
        }
        public bool ShowLastLap
        {
            get
            {
                return pnlLastLap.Visible;
            }
            set
            {
                pnlLastLap.Visible = value;
            }
        }
        public bool ShowCautions
        {
            get
            {
                return pnlCautions.Visible;
            }
            set
            {
                pnlCautions.Visible = value;
            }
        }
        public bool ShowLapLeaders
        {
            get
            {
                return pnlLapLeaders.Visible;
            }
            set
            {
                pnlLapLeaders.Visible = value;
            }
        }

        public EventDisplay()
        {
            InitializeComponent();
            
            InitializaEventDisplay();
        }

        void InitializaEventDisplay()
        {
            SetFlagStatus(FlagState.Yellow);

            ShowRunStats = true;
            ShowRaceStats = true;
            ShowAverages = true;
            ShowLastLap = true;
            ShowCautions = true;
            ShowLapLeaders = true;

            //this.pnlRunStats.DataBindings.Add(new Binding("Visible", this, "ShowRunStats"));
            //this.pnlRaceStats.DataBindings.Add(new Binding("Visible", this, "ShowRaceStats"));
            //this.pnlAverages.DataBindings.Add(new Binding("Visible", this, "ShowAverages"));
            //this.pnlLastLap.DataBindings.Add(new Binding("Visible", this, "ShowLastLap"));
            //this.pnlCautions.DataBindings.Add(new Binding("Visible", this, "ShowCautions"));
            //this.pnlLapLeaders.DataBindings.Add(new Binding("Visible", this, "ShowLapLeaders"));
        }

        void DisplayModel(LiveFeedModel model)
        {
            if (null == model) return;
            this.RunLabel.Text = model.run_name;
            this.TrackLabel.Text = model.track_name;
            this.lblLap.Text = model.run_name;
            this.SeriesLabel.Text = ((SeriesName)model.series_id).ToString() + "Series";
            this.SetFlagStatus((FlagState)model.flag_state);
            this.SetLeadersText(model.number_of_leaders, model.number_of_lead_changes);
            this.SetCautionsText(model.number_of_caution_segments, model.number_of_caution_laps);           
            this.lblLap.Text = String.Format("Lap {0} of {1}, {2} to go", model.lap_number.ToString(), model.laps_in_race.ToString(), model.laps_to_go.ToString());
        }

        void SetLeadersText(int number_of_leaders, int lead_changes)
        {
            string leadersCaption = number_of_leaders == 1 ? "Leader" : "Leaders";
            string changesCaption = lead_changes == 1 ? "Change" : "Changes";
            this.lblLeaders.Text = String.Format("{0} {1} with {2} Lead {3})", number_of_leaders.ToString(), leadersCaption, lead_changes.ToString(), changesCaption);
        }

        void SetCautionsText(int number_of_caution_segments, int number_of_caution_laps)
        {
            string cautionsCaption = number_of_caution_segments == 1 ? "Caution" : "Cautions";
            string lapsCaption = number_of_caution_laps == 1 ? "Lap" : "Laps";
            this.lblCautions.Text = String.Format("{0} {1} for {2} {3})", number_of_caution_segments, cautionsCaption, number_of_caution_laps, lapsCaption);
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

            cautionLightView1.SetFlagState(flag_status);
            cautionLightView2.SetFlagState(flag_status);

            picRaceStatus.BackColor = flagColor;

            if (null == Model) return;

            if (flag_status != FlagState.Green)
            {
                this.last_green_start = Model.lap_number;
            }
            else if ((null != last_model) && last_model.flag_state != 1 && flag_status == FlagState.Green)
                this.last_green_start = Model.lap_number;

            //lblGreenLaps.Text = (Model.lap_number - this.last_green_start).ToString();
            SetGreenLaps(Model.lap_number - this.last_green_start);
        }

        public void SetGreenLaps(int numberOfLaps)
        {
            lblGreenLaps.Text = String.Format("Current Green Flag Run: {0} Laps", numberOfLaps);
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

        #region INotifyPropertyChanged support
        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            if (null != PropertyChanged)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
