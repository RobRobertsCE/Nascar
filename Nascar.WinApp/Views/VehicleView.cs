using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nascar.Api.Models;
using Nascar.WinApp;
using Nascar.WinApp.Views;

namespace Nascar.WinApp.Views
{
    public partial class VehicleView : UserControl
    {
        public GreenFlagRun currentRun;
        public IList<GreenFlagRun> GreenFlagRuns = new List<GreenFlagRun>();
        public IList<LapTimeData> Laps = new List<LapTimeData>();

        VehicleModel last_model;
        VehicleModel model = new VehicleModel();

        public VehicleModel Vehicle { get { return model; } set { model = value; DisplayModel(); } }

        public double FiveLapAverage
        {
            get
            {
                return NLapAverage(5, true);
            }
        }
        public double TenLapAverage
        {
            get
            {
                return NLapAverage(10, true);
            }
        }
        public double TwentyLapAverage
        {
            get
            {
                return NLapAverage(20, true);
            }
        }
        public int RunPlusMinus
        {
            get
            {
                return position_at_last_green == 0 ? 0 : position_at_last_green - Vehicle.running_position;
            }
        }
        public int RacePlusMinus
        {
            get
            {
                return Vehicle.starting_position - Vehicle.running_position;
            }
        }
        public int LastPitLap
        {
            get
            {
                if (model.pit_stops.Count == 0)
                {
                    return 0;
                }
                else
                {
                    return model.pit_stops.Max(p => p.pit_in_leader_lap);
                }
            }
        }

        double lastDistanceBehind = 0;
        double distanceBehind = 0;
        public double DistanceBehind
        {
            get
            {
                return distanceBehind;
            }
            set
            {
                distanceBehind = value;
            }
        }

        double lastPositionDelta5Laps = 0;
        public double PositionDelta5Laps
        {
            get
            {
                return NLapPositionDelta(5, true);
            }
        }
        public double PositionDelta10Laps
        {
            get
            {
                return NLapPositionDelta(10, true);
            }
        }
        public double LeaderDelta5Laps
        {
            get
            {
                return NLapLeaderDelta(5, true);
            }
        }
        public double LeaderDelta10Laps
        {
            get
            {
                return NLapLeaderDelta(10, true);
            }
        }

        double last_delta = 0.0;
        int last_position = 0;
        int last_lap;
        int last_green_lap = 0;
        int last_yellow_lap = 0;
        int position_at_last_green = 0;
        int position_at_last_yellow = 0;
        FlagState current_flag_state;

        bool last_is_on_track = false;

        public string VehicleNumber { get { return Vehicle.vehicle_number; } }

        public VehicleView()
        {
            InitializeComponent();
        }

        public VehicleView(VehicleModel model)
            : this()
        {
            position_at_last_green = model.running_position;
            last_lap = model.laps_completed;
            this.Vehicle = model;
        }

        void DisplayModel()
        {
            if (null == Vehicle) return;

            if (null != Vehicle.driver)
                this.driverView1.Driver = Vehicle.driver;

            if (last_lap == Vehicle.laps_completed) return;

            this.CarNumberLabel.Text = Vehicle.vehicle_number;

            SetRunningPosition(Vehicle);

            this.BestLapTimeTextBox.Text = Vehicle.best_lap_time.ToString();
            this.BestLapOnTextBox.Text = Vehicle.best_lap.ToString();
            this.BestLapSpeedTextBox.Text = Vehicle.best_lap_speed.ToString();
            this.AvgRunPosition.Text = Vehicle.average_running_position.ToString();

            SetFastestlap(Vehicle);

            this.LapsCompletedTextBox.Text = Vehicle.laps_completed.ToString();

            SetLapsLed(Vehicle);

            SetDelta(Vehicle);
            SetDeltaPosition(Vehicle);
            SetDeltaPositionEx(Vehicle);
            SetGreenRunDelta(Vehicle);

            this.LastLapSpeedTextBox.Text = Vehicle.last_lap_speed.ToString();

            SetLapTime(Vehicle);

            this.PassesMadeTextBox.Text = Vehicle.passes_made.ToString();
            this.PassDifferentialTextBox.Text = Vehicle.passing_differential.ToString();
            this.QualityPassesTextBox.Text = Vehicle.quality_passes.ToString();
            this.StartPosTextBox.Text = Vehicle.starting_position.ToString();

            SetDeltaStart(Vehicle);
        }

        void SetLapsLed(VehicleModel model)
        {
            int timesLed = 0;
            int lapsLed = 0;

            if (null != Vehicle.laps_led)
            {
                timesLed = Vehicle.laps_led.Count;
                foreach (LapsLedModel lapsLedModel in Vehicle.laps_led)
                {
                    lapsLed += (lapsLedModel.end_lap - lapsLedModel.start_lap) + 1;
                }
            }

            this.LapsLedTextBox.Text = String.Format("{0} Times {1} Laps", timesLed, lapsLed);

            if (timesLed > 0)
            {
                this.LapsLedTextBox.BackColor = Color.Yellow;
            }
            else
            {
                this.LapsLedTextBox.BackColor = Color.White;
            }

        }

        void SetFastestlap(VehicleModel model)
        {
            this.FastestLapsTextBox.Text = model.fastest_laps_run.ToString();

            if ((model.is_on_track) && model.laps_completed == model.best_lap)
            {
                this.FastestLapsTextBox.BackColor = Color.LimeGreen;
                this.BestLapSpeedTextBox.BackColor = Color.LimeGreen;
                this.BestLapTimeTextBox.BackColor = Color.LimeGreen;
                this.BestLapOnTextBox.BackColor = Color.LimeGreen;
                this.LastLapSpeedTextBox.BackColor = Color.LimeGreen;
                this.LastLapTimeTextBox.BackColor = Color.LimeGreen;
            }
            else
            {
                this.FastestLapsTextBox.BackColor = Color.White;
                this.BestLapSpeedTextBox.BackColor = Color.White;
                this.BestLapTimeTextBox.BackColor = Color.White;
                this.BestLapOnTextBox.BackColor = Color.White;
                this.LastLapSpeedTextBox.BackColor = Color.White;
                this.LastLapTimeTextBox.BackColor = Color.White;
            }
        }

        void SetDeltaStart(VehicleModel model)
        {
            int deltaStart = (Vehicle.starting_position - Vehicle.running_position);

            this.DeltaStartTextBox.Text = deltaStart.ToString();
            if (deltaStart < 0)
            {
                this.DeltaStartTextBox.ForeColor = Color.Red;
            }
            else
            {
                this.DeltaStartTextBox.ForeColor = Color.Black; ;
            }
        }

        void SetDelta(VehicleModel model)
        {
            double delta_change = (last_delta - model.delta);

            this.DeltaGainLossTextBox.Text = delta_change.ToString();

            this.DeltaTextBox.Text = model.delta.ToString();

            if (last_delta < model.delta)
            {
                this.DeltaTextBox.ForeColor = Color.Red;
                this.DeltaGainLossTextBox.ForeColor = Color.Red;
            }
            else if (last_delta > model.delta)
            {
                this.DeltaTextBox.ForeColor = Color.Green;
                this.DeltaGainLossTextBox.ForeColor = Color.Green;
            }

            last_delta = model.delta;

        }

        void SetDeltaPosition(VehicleModel model)
        {
            double deltaPosChange = lastDistanceBehind - DistanceBehind;

            if (deltaPosChange > 0)
            {
                // gained on car in front.
                DeltaPositionTextBox.ForeColor = Color.Green;
                DeltaPositionGainLossTextBox.ForeColor = Color.Green;
            }
            else
            {
                // lost to car in front.
                DeltaPositionTextBox.ForeColor = Color.Red;
                DeltaPositionGainLossTextBox.ForeColor = Color.Red;
            }

            DeltaPositionGainLossTextBox.Text = deltaPosChange.ToString();
            DeltaPositionTextBox.Text = DistanceBehind.ToString();

            lastDistanceBehind = DistanceBehind;
        }

        void SetDeltaPositionEx(VehicleModel model)
        {
            double deltaPosChange = lastPositionDelta5Laps - PositionDelta5Laps;

            if (deltaPosChange > 0)
            {
                // gained on car in front.
                DeltaPosition5LapsTextBox.ForeColor = Color.Green;
                DeltaPositionGainLoss5LapsTextBox.ForeColor = Color.Green;
            }
            else
            {
                // lost to car in front.
                DeltaPosition5LapsTextBox.ForeColor = Color.Red;
                DeltaPositionGainLoss5LapsTextBox.ForeColor = Color.Red;
            }

            DeltaPositionGainLoss5LapsTextBox.Text = deltaPosChange.ToString();
            DeltaPosition5LapsTextBox.Text = PositionDelta5Laps.ToString();

            lastPositionDelta5Laps = PositionDelta5Laps;
        }

        void SetRunningPosition(VehicleModel model)
        {
            if (!model.is_on_track)
            {
                this.PositionLabel.BackColor = Color.LightGray;
                lblLapDelta.Text = "";
            }
            else
            {
                if ((last_lap != 0) && last_lap != Vehicle.laps_completed)
                {
                    int lapChange = last_position - Vehicle.running_position;
                    if (lapChange > 0)
                    {
                        this.PositionLabel.BackColor = Color.LimeGreen;
                        lblLapDelta.Text = String.Format("+{0}", lapChange.ToString());
                    }
                    else if (lapChange < 0)
                    {
                        this.PositionLabel.BackColor = Color.Red;
                        lblLapDelta.Text = String.Format("{0}", lapChange.ToString());
                    }
                    else
                    {
                        this.PositionLabel.BackColor = Color.White;
                        lblLapDelta.Text = "";
                    }
                }
            }
            this.PositionLabel.Text = Vehicle.running_position.ToString();

            last_position = Vehicle.running_position;
            last_lap = Vehicle.laps_completed;
            this.LapsSincePitTextBox.Text = (last_lap - LastPitLap).ToString();
        }

        void SetGreenRunDelta(VehicleModel model)
        {
            int deltaGreen = (position_at_last_green - Vehicle.running_position);

            this.RestartDeltaTextBox.Text = deltaGreen.ToString();

            if (deltaGreen < 0)
            {
                this.RestartDeltaTextBox.ForeColor = Color.Red;
            }
            else if (deltaGreen > 0)
            {
                this.RestartDeltaTextBox.ForeColor = Color.Green;
            }
            else
            {
                this.RestartDeltaTextBox.ForeColor = Color.Black; ;
            }
        }

        void SetLapTime(VehicleModel model)
        {
            this.LastLapTimeTextBox.Text = model.last_lap_time.ToString();

            AddLapData(model);
        }

        void AddLapData(VehicleModel model)
        {
            LapTimeData lapData = new LapTimeData { LapNumber = model.laps_completed, IsOnTrack = model.is_on_track, LapTime = model.last_lap_time, FlagState = current_flag_state, LeaderDelta = model.delta, PositionDelta = DistanceBehind };
            Laps.Add(lapData);
            if (null == this.currentRun)
            {
                this.currentRun = new GreenFlagRun(model.laps_completed, model.running_position, GreenFlagRuns.Count);
                GreenFlagRuns.Add(this.currentRun);
            }
            if (this.currentRun.is_active)
                this.currentRun.AddLapData(lapData);
        }

        double NLapAverage(int n, bool requireNLaps)
        {
            int count = (Laps.Count >= n) ? n : Laps.Count;

            if ((Laps.Count > 0) && (!requireNLaps || (requireNLaps && (count >= n))))
            {
                double result = 0;
                if (Laps.Any(l => l.FlagState == FlagState.Green))
                {
                    result = Laps.OrderByDescending(l => l.LapNumber).Where(l => l.FlagState == FlagState.Green).Take(count).Average(l => l.LapTime);
                }
                return result;
            }
            else
            {
                return 0;
            }
        }

        double NLapPositionDelta(int n, bool requireNLaps)
        {
            int count = (Laps.Count >= n) ? n : Laps.Count;

            if ((Laps.Count > 0) && (!requireNLaps || (requireNLaps && (count >= n))))
            {
                double result = 0;
                if (Laps.Any(l => l.FlagState == FlagState.Green))
                {
                    result = Laps.OrderByDescending(l => l.LapNumber).Where(l => l.FlagState == FlagState.Green).Take(count).Average(l => l.PositionDelta);
                }
                return result;
            }
            else
            {
                return 0;
            }
        }

        double NLapLeaderDelta(int n, bool requireNLaps)
        {
            int count = (Laps.Count >= n) ? n : Laps.Count;

            if ((Laps.Count > 0) && (!requireNLaps || (requireNLaps && (count >= n))))
            {
                double result = 0;
                if (Laps.Any(l => l.FlagState == FlagState.Green))
                {
                    result = Laps.OrderByDescending(l => l.LapNumber).Where(l => l.FlagState == FlagState.Green).Take(count).Average(l => l.LeaderDelta);
                }
                return result;
            }
            else
            {
                return 0;
            }
        }

        public void FlagStateChangedHandler(FlagState old_state, FlagState new_state, int lap_number)
        {
            if (new_state == FlagState.Green)
            {
                this.currentRun = new GreenFlagRun(lap_number, model.running_position, GreenFlagRuns.Count);
                GreenFlagRuns.Add(this.currentRun);
                last_yellow_lap = lap_number;
                position_at_last_green = model.running_position;
                RestartPositionTextBox.Text = position_at_last_green.ToString();
            }
            if (old_state == FlagState.Green)
            {
                last_green_lap = lap_number;
                position_at_last_yellow = model.running_position;
                this.currentRun.EndRun(lap_number, model.running_position);
            }
            current_flag_state = new_state;
        }

    }
}
