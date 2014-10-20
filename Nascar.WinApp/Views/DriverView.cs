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
    public partial class DriverView : UserControl
    {
        DriverModel model = new DriverModel();
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.Description("Number of steps between the start and end values.")]
        [System.ComponentModel.Category("Appearance")]
        public DriverModel Driver { get { return model; } set { model = value; DisplayModel(); } }

        public DriverView()
        {
            InitializeComponent();
        }

        void DisplayModel()
        {
            if (null == model) return;

            DriverTextBox.Text = Driver.full_name;
        }
    }
}
