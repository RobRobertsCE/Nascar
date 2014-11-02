using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nascar.Data.Schedule;

namespace Nascar.ServiceScheduler.Views
{
    public partial class ScheduledEventView : UserControl
    {
        private ScheduledEvent _scheduledEvent = null;
        public ScheduledEvent ScheduledEvent
        {
            get
            {
                return _scheduledEvent;
            }
            set
            {
                _scheduledEvent = value;
                if (null != _scheduledEvent)
                    this.AddBindings();
            }
        }

        private class NameIdModel
        {
            public Int32 id { get; set; }
            public String name { get; set; }

            public NameIdModel()
            {

            }

            public NameIdModel(Int32 id, string name)
            {
                this.id = id;
                this.name = name;
            }
        }

        public ScheduledEventView()
        {
            InitializeComponent();
            this.PopulateControls();            
        }     

        void PopulateControls()
        {
            this.PopulateTrackControl();
            this.PopulateSeriesControl();
            this.PopulateSessionControl();
        }
        void PopulateTrackControl()
        {
            using (var context = new Nascar.Data.NascarDbContext())
            {
                this.cboTrack.DataSource = context.Tracks.OrderBy(t => t.track_name).ToList();
            }
            this.cboTrack.ValueMember = "track_id";
            this.cboTrack.DisplayMember = "track_name";
        }
        void PopulateSessionControl()
        {
            this.cboSession.DataSource = null;
            this.cboSession.DisplayMember = "name";
            this.cboSession.ValueMember = "id";

            IList<NameIdModel> sessionList = new List<NameIdModel>();
            sessionList.Add(new NameIdModel(0, "Practice"));
            sessionList.Add(new NameIdModel(1, "Qualifying"));
            sessionList.Add(new NameIdModel(2, "Race"));

            this.cboSession.DataSource = sessionList;
            this.cboSession.SelectedIndex = -1;
        }
        void PopulateSeriesControl()
        {
            this.cboSeries.DataSource = null;
            this.cboSeries.DisplayMember = "series_name";
            this.cboSeries.ValueMember = "series_id";
            using (var context = new Nascar.Data.NascarDbContext())
            {
                this.cboSeries.DataSource = context.RaceSeries.Where(s => s.series_id > 0).OrderBy(s => s.series_id).ToList();
            }
        }

        void AddBindings()
        {
            this.cboTrack.DataBindings.Add("SelectedValue", ScheduledEvent, "track_id", true, DataSourceUpdateMode.OnValidation);
            this.cboSession.DataBindings.Add("SelectedValue", ScheduledEvent, "session_id", true, DataSourceUpdateMode.OnValidation);
            this.dtStart.DataBindings.Add("Value", ScheduledEvent, "scheduled_event_start", true, DataSourceUpdateMode.OnValidation);
            this.dtEnd.DataBindings.Add("Value", ScheduledEvent, "scheduled_event_end", true, DataSourceUpdateMode.OnValidation);
            this.chkEnabled.DataBindings.Add("Checked", ScheduledEvent, "enabled", true, DataSourceUpdateMode.OnValidation);
            this.lblStatus.DataBindings.Add("Text", ScheduledEvent, "status", true, DataSourceUpdateMode.OnValidation);
        }
        
        private void cboTrack_SelectedValueChanged(object sender, EventArgs e)
        {
            if (null == ScheduledEvent) return;

            if (null != cboTrack.SelectedItem)
            {
                Nascar.Data.Track model = (Nascar.Data.Track)cboTrack.SelectedItem;
                ScheduledEvent.track_id = model.track_id;
                ScheduledEvent.track_name = model.track_name;
            }
        }
    }
}
