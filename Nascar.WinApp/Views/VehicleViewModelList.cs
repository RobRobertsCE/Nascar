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
    public partial class VehicleViewModelList : UserControl
    {
        public VehicleViewModelList()
        {
            InitializeComponent();
            this.viewPanel.Controls.Clear();
        }

        public void UpdateDisplay(LiveFeedModel model)
        {
            double lastDelta = 0;
            foreach (VehicleModel vehicle in model.vehicles.OrderBy(p => p.running_position))
            {
                var view = GetVehicleView(vehicle.vehicle_number);

                //view.DistanceBehind = vehicle.delta - lastDelta;

                view.ViewModel = new VehicleViewModel(vehicle, SeriesName.Cup); // << updates done here

                this.viewPanel.Controls.SetChildIndex(view, vehicle.running_position - 1);

                lastDelta = vehicle.delta;
            }
        }
        VehicleStatView GetVehicleView(string vehicle_number)
        {
            var view = this.viewPanel.Controls.OfType<VehicleStatView>().Where(v => v.ViewModel.VehicleNumber == vehicle_number).FirstOrDefault();

            if (null == view)
            {
                view = new VehicleStatView();
                //FlagStateChangeEvent += view.FlagStateChangedHandler;
                view.Disposed += view_Disposed;
                this.viewPanel.Controls.Add(view);
            }

            return view;
        }

        void view_Disposed(object sender, EventArgs e)
        {
            sender = null;
        }
    }
}
