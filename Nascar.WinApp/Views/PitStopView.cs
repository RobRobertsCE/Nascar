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
    public partial class PitStopView : UserControl
    {
        PitStopModel model;
        public PitStopModel PitStop { get { return model; } set { model = value; DisplayModel(); } }

        public PitStopView(PitStopModel model)
            : this()
        {

            this.PitStop = model;
        }

        public PitStopView()
        {
            InitializeComponent();
        }

        void DisplayModel()
        {

        }
    }
}
