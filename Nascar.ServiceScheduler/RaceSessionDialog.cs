using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nascar.Data.Schedule;

namespace Nascar.ServiceScheduler
{
    public partial class RaceSessionDialog : Form
    {
        private RaceSession _raceSession = null;
        public RaceSession RaceSession
        { 
            get 
            { return _raceSession; } 
            private set 
            {
                _raceSession = value;
            } 
        }

        public RaceSessionDialog()
            : this(new RaceSession())
        {  }

        public RaceSessionDialog(RaceSession raceSession)
        {
            InitializeComponent();
            this.RaceSession = raceSession;
            PopulateSessionControl();
            SetBindings();
            Race race  = GetRace(raceSession.race_id);
            this.Text = race.Series.series_name + " - " + race.Track.track_name;
        }

        Race GetRace(int race_id)
        {
            using (var context = new ScheduleDbContext())
            {
                return context.Races.Include("Series").Include("Track").Where(r => r.race_id == race_id).FirstOrDefault();
            }
        }

        void PopulateSessionControl()
        {
            this.cboSessions.DataSource = null;
            this.cboSessions.DisplayMember = "session_name";
            this.cboSessions.ValueMember = "session_id";
            using (var context = new ScheduleDbContext())
            {
                this.cboSessions.DataSource = context.Sessions.OrderBy(s => s.session_id).ToList();
            }
        }
        void SetBindings()
        {
            if (null == _raceSession) return;
            this.txtSequence.DataBindings.Add(new Binding("Text", RaceSession, "sequence"));
            this.cboSessions.DataBindings.Add(new Binding("SelectedValue", RaceSession, "session_id"));
            this.dtStart.DataBindings.Add(new Binding("Value", RaceSession, "start_time"));
            this.dtEnd.DataBindings.Add(new Binding("Value", RaceSession, "end_time"));
        }

        private void dtStart_ValueChanged(object sender, EventArgs e)
        {
            dtEnd.Value = dtStart.Value;
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {

        }
    }
}
