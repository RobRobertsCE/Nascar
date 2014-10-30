using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nascar.Models;

namespace Nascar.WinApp.Views
{
    public partial class VehicleView : UserControl
    {
        VehicleModel model = new VehicleModel();
        public VehicleModel Vehicle { get { return model; } set { model = value; DisplayModel(); } }
        
        public VehicleView()
        {
            InitializeComponent();
        }

        public VehicleView(VehicleModel model)
            : this()
        {
            this.Vehicle = model;
        }

        void DisplayModel()
        {
            if (null == Vehicle) return;

            this.driverView1.Driver = Vehicle.driver;
            this.CarNumberLabel.Text = Vehicle.vehicle_number;
            this.PositionLabel.Text = Vehicle.running_position.ToString();
            this.BestLapTimeTextBox.Text = Vehicle.best_lap_time.ToString();
            this.BestLapOnTextBox.Text = Vehicle.best_lap.ToString();
            this.BestLapSpeedTextBox.Text = Vehicle.best_lap_speed.ToString();

        }

      
    }
}
