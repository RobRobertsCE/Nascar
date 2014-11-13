using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nascar.WinApp.Views
{
    public partial class VehicleStatView : UserControl
    {
        private Color BaseColor = Color.DarkBlue;
        private Color AlternateColor = Color.MediumBlue;

        VehicleViewModel viewModel;
        public VehicleViewModel ViewModel
        {
            get
            {
                return viewModel;
            }
            set
            {
                viewModel = value;
                UpdateDisplay();
            }
        }

        public VehicleStatView()
        {
            InitializeComponent();
        }

        void UpdateDisplay()
        {
            if (null == ViewModel) return;

            this.lblDriver.Text = ViewModel.DriverName;
            this.lblVehicleNumber.Text = ViewModel.VehicleNumber;
            this.lblPosition.Text = ViewModel.RunningPosition.ToString();
            this.picManufacturer.Image = ViewModel.ManufacturerImage;
            this.lblLastLapSpeed.Text = ViewModel.LastLapSpeed.ToString();
            this.lblLastLapTime.Text = ViewModel.LastLapTime.ToString();

            if (ViewModel.RunningPosition % 2 == 0)
            {
                this.BackColor = BaseColor;
            }
            else
            {
                this.BackColor = AlternateColor;
            }
        }
    }
}
