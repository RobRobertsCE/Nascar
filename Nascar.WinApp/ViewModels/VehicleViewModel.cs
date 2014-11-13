using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Nascar.Models;
using Nascar.Api;

namespace Nascar.WinApp.Views
{
    public delegate void VehicleUpdated(object sender, EventArgs e);

    public class VehicleViewModel : Nascar.WinApp.Views.IVehicleViewModel
    {
        public VehicleUpdated VehicleUpdatedEvent;

        #region fields
        FlagState currentFlagState;
        VehicleModel last_model;
        VehicleModel model;
        Image manufacturerImage;
        Image vehicleNumberImage;
        #endregion

        #region properties
        public SeriesName Series;
        public FlagState FlagState
        {
            get
            {
                return currentFlagState; ;
            }
            set
            {
                currentFlagState = value;
            }
        }
        public IList<GreenFlagRun> GreenFlagRuns;
        public IList<LapTimeData> Laps;
        public GreenFlagRun CurrentRun
        {
            get
            {
                if (GreenFlagRuns.Count == 0)
                    return new GreenFlagRun(0, 0, 0);
                else
                    return GreenFlagRuns.LastOrDefault();
            }
        }
        public VehicleModel Vehicle
        {
            get
            {
                return model;
            }
            set
            {
                if (null != model) last_model = model;
                model = value;
                UpdateStats();
            }
        }

        public string VehicleNumber
        {
            get { return Vehicle.vehicle_number; }
        }
        public string DriverName
        {
            get { return Vehicle.driver.full_name; }
        }
        public bool IsOnTrack
        {
            get
            {
                return Vehicle.is_on_track;
            }
        }

        public int LapsCompleted
        {
            get { return Vehicle.laps_completed; }
        }
        public double LastLapTime
        {
            get { return Vehicle.last_lap_time; }
        }
        public double LastLapSpeed
        {
            get { return Vehicle.last_lap_speed; }
        }

        public int BestLap
        {
            get { return Vehicle.best_lap; }
        }
        public double BestLapTime
        {
            get { return Vehicle.best_lap_speed; }
        }
        public double BestLapSpeed
        {
            get { return Vehicle.best_lap_speed; }
        }

        public int PassesMade
        {
            get { return Vehicle.passes_made; }
        }
        public int QualityPassesMade
        {
            get { return Vehicle.quality_passes; }
        }
        public int PassDifferential
        {
            get { return Vehicle.passing_differential; }
        }
        public string LapsLead
        {
            get
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

                return String.Format("{0} Times {1} Laps", timesLed, lapsLed);

            }
        }

        public int StartingPosition
        {
            get { return Vehicle.starting_position; }
        }
        public int RunningPosition
        {
            get
            {
                return Vehicle.running_position;
            }
        }
        public double AverageRunningPosition
        {
            get { return Vehicle.average_running_position; }
        }
        public int LastRestartPosition
        {
            get { return CurrentRun.start_position; }
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
        public int LapsSincePit
        {
            get
            {
                return LapsCompleted - LastPitLap;
            }
        }

        public int LastRestartLap
        {
            get
            {
                return CurrentRun.start_lap;
            }
        }
        public int LapsSinceRestart
        {
            get
            {
                return LapsCompleted - LastRestartLap;
            }
        }

        public double DeltaLeader
        {
            get
            {
                return Vehicle.delta;
            }
        }
        public double DeltaLeaderGainLoss
        {
            get
            {
                return last_model.delta - DeltaLeader;
            }
        }
        public double DeltaLeader5Laps
        {
            get
            {
                return NLapLeaderDelta(5, true);
            }
        }
        public double DeltaLeader10Laps
        {
            get
            {
                return NLapLeaderDelta(10, true);
            }
        }

        public int DeltaPositionsRace
        {
            get
            {
                return StartingPosition - RunningPosition;
            }
        }
        public int DeltaPositionsRun
        {
            get
            {
                return LastRestartPosition - RunningPosition;
            }
        }
        public double DeltaPosition5Laps
        {
            get
            {
                return NLapPositionDelta(5, true);
            }
        }
        public double DeltaPosition10Laps
        {
            get
            {
                return NLapPositionDelta(10, true);
            }
        }

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

        public Image ManufacturerImage
        {
            get
            {
                if (null == manufacturerImage)
                    manufacturerImage = GetManufacturerImage();

                return manufacturerImage;
            }
        }
        public Image VehicleNumberImage
        {
            get
            {
                if (null == vehicleNumberImage)
                    vehicleNumberImage = GetVehicleNumberImage();

                return vehicleNumberImage;
            }
        }
        #endregion

        #region ctor
        public VehicleViewModel()
        {
            this.GreenFlagRuns = new List<GreenFlagRun>();
            this.Laps = new List<LapTimeData>();

            this.last_model = new VehicleModel();
            this.Vehicle = new VehicleModel();

            this.Series = SeriesName.Cup;
        }

        public VehicleViewModel(VehicleModel model, SeriesName series)
            : this()
        {
            this.Vehicle = model;
            this.Series = series;
        }
        #endregion

        #region FlagStateChanged handler
        public void FlagStateChangedHandler(FlagState old_state, FlagState new_state, int lap_number)
        {
            if (new_state == FlagState.Green)
            {
                if (this.CurrentRun.is_active)
                {
                    this.CurrentRun.EndRun(lap_number, model.running_position);
                }
                GreenFlagRun new_run = new GreenFlagRun(lap_number, model.running_position, GreenFlagRuns.Count);
                this.GreenFlagRuns.Add(new_run);
            }
            if (old_state == FlagState.Green)
            {
                this.CurrentRun.EndRun(lap_number, model.running_position);
            }
            currentFlagState = new_state;
        }
        #endregion

        #region private methods
        void UpdateStats()
        {
            if (null == Vehicle) return;

            if (last_model.laps_completed != Vehicle.laps_completed)
            {
                UpdateLapData();

                OnVehicleUpdate();
            }
        }

        void UpdateLapData()
        {
            LapTimeData lapData = new LapTimeData
            {
                LapNumber = this.LapsCompleted,
                IsOnTrack = this.IsOnTrack,
                LapTime = this.LastLapTime,
                FlagState = this.FlagState,
                LeaderDelta = this.DeltaLeader,
                PositionDelta = this.DeltaPositionsRace
            };
            Laps.Add(lapData);

            if (this.CurrentRun.is_active)
                this.CurrentRun.AddLapData(lapData);
        }

        double NLapAverage(int n, bool requireNLaps)
        {
            int count = (Laps.Count >= n) ? n : Laps.Count;

            if ((Laps.Count > 0) && (!requireNLaps || (requireNLaps && (count >= n))))
            {
                return Laps.OrderByDescending(l => l.LapNumber).Where(l => l.FlagState == FlagState.Green).Take(count).Average(l => l.LapTime);
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
                return Laps.OrderByDescending(l => l.LapNumber).Where(l => l.FlagState == FlagState.Green).Take(count).Average(l => l.PositionDelta);
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
                return Laps.OrderByDescending(l => l.LapNumber).Where(l => l.FlagState == FlagState.Green).Take(count).Average(l => l.LeaderDelta);
            }
            else
            {
                return 0;
            }
        }

        Image GetManufacturerImage()
        {
            using (ResourceManager manager = new ResourceManager())
            {
                return manager.GetManufacturerImage(Vehicle.vehicle_manufacturer);
            }
        }

        Image GetVehicleNumberImage()
        {
            using (ResourceManager manager = new ResourceManager())
            {
                return manager.GetVehicleNumberImage(Vehicle.vehicle_number, (int)Series);
            }
        }

        void OnVehicleUpdate()
        {
            if (null != VehicleUpdatedEvent)
            {
                VehicleUpdatedEvent.Invoke(this, EventArgs.Empty);
            }
        }
        #endregion
    }
}
