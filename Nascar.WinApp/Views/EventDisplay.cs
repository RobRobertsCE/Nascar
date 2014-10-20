using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nascar.Models;

namespace Nascar.WinApp
{
    public partial class EventDisplay : UserControl
    {
        public string TrackName
        {
            get
            {
                return this.TrackLabel.Text;
            }
            set
            {
                this.TrackLabel.Text = value;
            }
        }
        public DateTime EventDate
        {
            get
            {
                return  DateTime.Parse(this.DateLabel.Text);
            }
            set
            {
                this.DateLabel.Text = value.ToString();
            }
        }
        public string Run
        {
            get
            {
                return this.RunLabel.Text;
            }
            set
            {
                this.RunLabel.Text = value;
            }
        }
        public Series Series
        {
            get
            {
                return (Series)Enum.Parse(typeof(Series), this.SeriesLabel.Text);
            }
            set
            {
                this.SeriesLabel.Text = ((Series)value).ToString();
            }
        }

        public EventDisplay()
        {
            InitializeComponent();
        }
    }
}
