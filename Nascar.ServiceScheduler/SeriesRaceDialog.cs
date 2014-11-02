using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nascar.ServiceScheduler.Data;

namespace Nascar.ServiceScheduler
{
    public partial class SeriesRaceDialog : Form
    {
        public bool IsNew { get; set; }

        private ScheduledRace _race = null;
        public ScheduledRace Race
        { 
            get 
            { return _race; } 
            private set 
            {
                _race = value;
            } 
        }

        public SeriesRaceDialog()
            : this(new ScheduledRace())
        {  }

        public SeriesRaceDialog(ScheduledRace series)
        {
            InitializeComponent();
            this.Race = series;
            this.IsNew = (this.Race.race_id==0);
            PopulateControls();
            SetBindings();
        }

        void PopulateControls()
        {
            this.PopulateTrackControl();
            this.PopulateSeriesControl();
        }
        void PopulateTrackControl()
        {
            using (var context = new ServiceSchedulerDbContext())
            {
                this.cboTrack.DataSource = context.ScheduledTracks.OrderBy(t => t.track_name).ToList();
            }
            this.cboTrack.ValueMember = "track_id";
            this.cboTrack.DisplayMember = "track_name";
        }
        void PopulateSeriesControl()
        {
            this.cboSeries.DataSource = null;
            this.cboSeries.DisplayMember = "series_name";
            this.cboSeries.ValueMember = "series_id";
            using (var context = new ServiceSchedulerDbContext())
            {
                this.cboSeries.DataSource = context.ScheduledRaceSeries.Where(s => s.series_id > 0).OrderBy(s => s.series_id).ToList();
            }
        }
        void SetBindings()
        {
            if (null == _race) return;
            this.txtId.DataBindings.Add(new Binding("Text", Race, "race_id"));
            this.txtSequence.DataBindings.Add(new Binding("Text", Race, "sequence"));
            this.cboTrack.DataBindings.Add(new Binding("SelectedValue", Race, "track_id"));
            this.cboSeries.DataBindings.Add(new Binding("SelectedValue", Race, "series_id"));
            this.dtDate.DataBindings.Add(new Binding("Value", Race, "race_date"));
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtId.Text) || txtId.Text=="0")
            {
                MessageBox.Show("Enter a race id!");
            }
            else
                this.DialogResult = System.Windows.Forms.DialogResult.OK;

        }
    }
}
