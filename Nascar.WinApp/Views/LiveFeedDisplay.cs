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
    public partial class LiveFeedDisplay : UserControl
    {
        bool eventSet = false;

        public LiveFeedDisplay()
        {
            InitializeComponent();
        }

        public void UpdateDisplay(LiveFeedModel model)
        {
            if (!eventSet)
            {
                SetEvent(model);
            }
                        
            vehiclePanel.Controls.Clear();

            foreach (VehicleModel vehicle in model.vehicles.OrderBy(p=>p.running_position))
            {
                vehiclePanel.Controls.Add(new VehicleView(vehicle));
            }
           
        }

        void SetEvent(LiveFeedModel model)
        {
            eventDisplay.TrackName = model.track_name;
            eventDisplay.Run = model.run_name;
            eventDisplay.EventDate = model.created;
            eventDisplay.Series = (Series)model.series_id;
            eventSet = true;
        }
    }
}
