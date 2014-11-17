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
    public partial class LiveFeedDisplay : UserControl, INotifyPropertyChanged
    {
        FlagStateChanged FlagStateChangeEvent;

        LiveFeedModel last_model;

        LiveFeedModel current_model;
        public LiveFeedModel Model
        {
            get
            {
                return current_model;
            }
            set
            {
                current_model = value;
                UpdateDisplay(current_model);
                last_model = current_model;
            }
        }

        public bool ShowRunStats
        {
            get
            {
                return eventDisplay.ShowRunStats;
            }
            set
            {
                eventDisplay.ShowRunStats = value;
            }
        }
        public bool ShowRaceStats
        {
            get
            {
                return eventDisplay.ShowRaceStats;
            }
            set
            {
                eventDisplay.ShowRaceStats = value;
            }
        }
        public bool ShowAverages
        {
            get
            {
                return eventDisplay.ShowAverages;
            }
            set
            {
                eventDisplay.ShowAverages = value;
            }
        }
        public bool ShowLastLap
        {
            get
            {
                return eventDisplay.ShowLastLap;
            }
            set
            {
                eventDisplay.ShowLastLap = value;
            }
        }
        public bool ShowCautions
        {
            get
            {
                return eventDisplay.ShowCautions;
            }
            set
            {
                eventDisplay.ShowCautions = value;
            }
        }
        public bool ShowLapLeaders
        {
            get
            {
                return eventDisplay.ShowLapLeaders;
            }
            set
            {
                eventDisplay.ShowLapLeaders = value;
            }
        }

        public LiveFeedDisplay()
        {
            InitializeComponent();

            ShowRunStats = true;
            ShowRaceStats = true;
            ShowAverages = true;
            ShowLastLap = true;
            ShowCautions = true;
            ShowLapLeaders = true;

            vehiclePanel.Controls.Clear();
        }

        void UpdateDisplay(LiveFeedModel model)
        {
            if (null == model) return;

            try
            {
                this.SuspendLayout();
                UpdateFlagState(model);
                UpdateEvent(model);
                UpdateVehicles(model);
                UpdateMovers();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                this.ResumeLayout();
            }
        }

        void UpdateFlagState(LiveFeedModel model)
        {
            if (null == last_model) return;

            if (model.flag_state != last_model.flag_state)
            {
                FlagStateChangeEvent.Invoke((FlagState)last_model.flag_state, (FlagState)model.flag_state, model.lap_number);
            }
        }

        void UpdateEvent(LiveFeedModel model)
        {
            eventDisplay.Model = model;
        }

        void UpdateVehicles(LiveFeedModel model)
        {
            double lastDelta = 0;
            foreach (VehicleModel vehicle in model.vehicles.OrderBy(p => p.running_position))
            {
                var view = GetVehicleView(vehicle.vehicle_number);

                view.DistanceBehind = vehicle.delta - lastDelta;

                view.Vehicle = vehicle; // << updates done here

                this.vehiclePanel.Controls.SetChildIndex(view, vehicle.running_position - 1);

                lastDelta = vehicle.delta;
            }

            // this.vehicleViewModelList1.UpdateDisplay(model);
        }

        VehicleView GetVehicleView(string vehicle_number)
        {
            var view = vehiclePanel.Controls.OfType<VehicleView>().Where(v => v.VehicleNumber == vehicle_number).FirstOrDefault();

            if (null == view)
            {
                view = new VehicleView();
                FlagStateChangeEvent += view.FlagStateChangedHandler;
                view.Disposed += view_Disposed;
                vehiclePanel.Controls.Add(view);
            }

            return view;
        }
        void view_Disposed(object sender, EventArgs e)
        {
            FlagStateChangeEvent += ((VehicleView)sender).FlagStateChangedHandler;
        }

        #region List Displays
        void UpdateMovers()
        {
            UpdateBestRun();
            UpdateWorstRun();
            UpdateBestRace();
            UpdateWorstRace();
            Update5LapAverage();
            Update10LapAverage();
            Update20LapAverage();
            UpdateBestLastLap();

            eventDisplay1.Invalidate();
        }
        void UpdateBestRun()
        {
            eventDisplay.SetRunMovers(vehiclePanel.Controls.OfType<VehicleView>().OrderByDescending(v => v.RunPlusMinus).Take(5).ToList());
        }
        void UpdateWorstRun()
        {
            eventDisplay.SetRunFallers(vehiclePanel.Controls.OfType<VehicleView>().OrderBy(v => v.RunPlusMinus).Take(5).ToList());
        }
        void UpdateBestRace()
        {
            eventDisplay.SetRaceMovers(vehiclePanel.Controls.OfType<VehicleView>().OrderByDescending(v => v.RacePlusMinus).Take(5).ToList());
        }
        void UpdateWorstRace()
        {
            eventDisplay.SetRaceFallers(vehiclePanel.Controls.OfType<VehicleView>().OrderBy(v => v.RacePlusMinus).Take(5).ToList());
        }
        void Update5LapAverage()
        {
            eventDisplay.Set5LapAverage(vehiclePanel.Controls.OfType<VehicleView>().Where(v => v.FiveLapAverage > 0).OrderBy(v => v.FiveLapAverage).Take(5).ToList());
        }
        void Update10LapAverage()
        {
            eventDisplay.Set10LapAverage(vehiclePanel.Controls.OfType<VehicleView>().Where(v => v.TenLapAverage > 0).OrderBy(v => v.TenLapAverage).Take(5).ToList());
        }
        void Update20LapAverage()
        {
            eventDisplay.Set20LapAverage(vehiclePanel.Controls.OfType<VehicleView>().Where(v => v.TwentyLapAverage > 0).OrderBy(v => v.TwentyLapAverage).Take(5).ToList());
        }
        void UpdateBestLastLap()
        {
            eventDisplay.SetBestLastLaps(vehiclePanel.Controls.OfType<VehicleView>().Where(v => v.Vehicle.last_lap_time > 0).OrderBy(v => v.Vehicle.last_lap_time).Take(5).ToList());
        }
        #endregion

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
