using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;
using Nascar.Api;
using Nascar.Data.Schedule;

namespace Nascar.ServiceScheduler
{
    public partial class ScheduleDialog : Form
    {
        #region fields
        private IApiFeedEngine _engine = null;
        private IList<RaceEventView> _schedule = null;
        #endregion

        #region properties
        //private RaceEvent SelectedEvent
        //{
        //    get
        //    {
        //        return (RaceEvent)dataGridView1.CurrentRow.DataBoundItem;
        //    }
        //}

        private RaceEventView SelectedEventView
        {
            get
            {
                return (RaceEventView)dataGridView1.CurrentRow.DataBoundItem;
            }
        }
        #endregion

        #region ctor / load
        public ScheduleDialog()
        {
            InitializeComponent();
        }

        private void ScheduleDialog_Load(object sender, EventArgs e)
        {
            UpdateScheduleDisplay();
        }
        #endregion

        #region close form
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region display schedule
        void UpdateScheduleDisplay()
        {
            this.Invoke((MethodInvoker)delegate
            {
                LoadSchedule();
                DisplaySchedule();
            });           
        }
        void LoadSchedule()
        {
            using (var context = new ScheduleDbContext())
            {
                DateTime today = DateTime.Now.Date;

                Expression<Func<RaceEventView, bool>> predicate = r => ((
                  chkCup.Checked && ((r.RaceSession.Race.series_id == 1) == chkCup.Checked))
                  || (chkNationwide.Checked && ((r.RaceSession.Race.series_id == 2) == chkNationwide.Checked))
                  || (chkTruck.Checked && ((r.RaceSession.Race.series_id == 3) == chkTruck.Checked))
                  && (chkTodayOnly.Checked && ((DbFunctions.TruncateTime(r.scheduled_event_start) == today) == chkTodayOnly.Checked)));

                _schedule = context.RaceEventViews.Include("RaceSession").Include("RaceSession.Race.Track").Include("RaceSession.Race.Series").Where(predicate).OrderBy(r => r.scheduled_event_start).ToArray();
            }
        }
        void DisplaySchedule()
        {
            this.dataGridView1.DataSource = _schedule;
            //this.dataGridView1.Columns["scheduled_event_id"].Visible = false;
            //this.dataGridView1.Columns["race_session_id"].Visible = false;
            //this.dataGridView1.Columns["race_id"].Visible = false;
            this.dataGridView1.Columns["RaceSession"].Visible = false;

            this.dataGridView1.Columns["track_name"].DisplayIndex = 0;
            this.dataGridView1.Columns["track_name"].HeaderText = "Track";
            this.dataGridView1.Columns["series_name"].DisplayIndex = 1;
            this.dataGridView1.Columns["series_name"].HeaderText = "Series";
            this.dataGridView1.Columns["session_name"].DisplayIndex = 2;
            this.dataGridView1.Columns["session_name"].HeaderText = "Session";
            this.dataGridView1.Columns["sequence"].DisplayIndex = 3;
            this.dataGridView1.Columns["sequence"].HeaderText = "Sequence";
            this.dataGridView1.Columns["status"].HeaderText = "Status";
            this.dataGridView1.Columns["enabled"].HeaderText = "Enabled";
            this.dataGridView1.Columns["scheduled_event_start"].HeaderText = "Start";
            this.dataGridView1.Columns["scheduled_event_end"].HeaderText = "End";
            this.dataGridView1.Columns["scheduled_event_id"].DisplayIndex = 8;
            this.dataGridView1.Columns["race_session_id"].DisplayIndex = 8;
            this.dataGridView1.Columns["race_id"].DisplayIndex = 8;
        }
        #endregion

        #region delete an existing event from the schedule
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteSelectedEvent();
        }
        void DeleteSelectedEvent()
        {
            if (null == SelectedEventView) return;
            DeleteEvent(SelectedEventView.scheduled_event_id);
        }
        #endregion

        #region add new event to schedule
        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.DisplayScheduledEventDialog(new RaceEvent());
        }
        #endregion

        #region edit an existing event
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (null == SelectedEventView) return;
            DisplayScheduledEventDialog(SelectedEventView);
        }
        #endregion

        #region ScheduledEventDialog
        void DisplayScheduledEventDialog(RaceEventView scheduledEventView)
        {
            RaceEvent raceEvent = null;

            using (var context = new ScheduleDbContext())
            {
                raceEvent = context.RaceEvents.Include("RaceSession").Include("RaceSession.Race.Track").Include("RaceSession.Race.Series").Where(r => r.scheduled_event_id == scheduledEventView.scheduled_event_id).FirstOrDefault();
            }

            if (raceEvent != null)
                DisplayScheduledEventDialog(raceEvent);
        }
        void DisplayScheduledEventDialog(RaceEvent scheduledEvent)
        {
            ScheduledEventDialog dialog = new ScheduledEventDialog(scheduledEvent);

            if (dialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                this.SaveEvent(dialog.ScheduledEvent);
            }
        }
        #endregion

        #region data methods
        void SaveEvent(RaceEvent scheduledEvent)
        {
            if (null == scheduledEvent) return;

            using (var context = new ScheduleDbContext())
            {
                if (scheduledEvent.status != "Saved") scheduledEvent.status = "Saved";

                context.RaceEvents.AddOrUpdate(scheduledEvent);
                
                context.SaveChanges();
            }

            UpdateScheduleDisplay();
        }
        void DeleteEvent(int scheduled_event_id)
        {
            using (var context = new ScheduleDbContext())
            {
                var selected = context.RaceEvents.Where(e => e.scheduled_event_id == scheduled_event_id).FirstOrDefault();
                if (null == selected) return;
                context.RaceEvents.Remove(selected);
                context.SaveChanges();
            }
            UpdateScheduleDisplay();
        }
        #endregion

        #region individual models dialogs (race, series, track, etc...)
        private void btnTracks_Click(object sender, EventArgs e)
        {
            DisplayTracksDialog();
        }
        void DisplayTracksDialog()
        {
            TracksDialog dialog = new TracksDialog();
            dialog.ShowDialog(this);
        }

        private void btnSeries_Click(object sender, EventArgs e)
        {
            DisplaySeriesDialog();
        }
        void DisplaySeriesDialog()
        {
            RaceSeriesDialog dialog = new RaceSeriesDialog();
            dialog.ShowDialog(this);
        }

        private void btnRaces_Click(object sender, EventArgs e)
        {
            DisplayRacesDialog();
        }
        void DisplayRacesDialog()
        {
            SeriesScheduleDialog dialog = new SeriesScheduleDialog();
            dialog.ShowDialog(this);
            UpdateScheduleDisplay();
        }
        #endregion

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (btnStartStop.Text == "Start")
            {
                StartFeedHarvester();
                btnStartStop.Text = "Stop";
                txtGreenLight.BackColor = Color.LimeGreen;

            }
            else
            {
                StopFeedHarvester();
                btnStartStop.Text = "Start";
                txtGreenLight.BackColor = Color.White;
            }
        }
        void StartFeedHarvester()
        {
            if (null != _engine)
                _engine.Stop();

            _engine = new ApiFeedEngine();
            _engine.LiveFeedEngineError += _engine_LiveFeedEngineError;
            _engine.EventFeedStarted += _engine_EventFeedStarted;
            _engine.EventFeedStopped += _engine_EventFeedStopped;
            _engine.Start();
        }

        void _engine_EventFeedStopped(object sender, EventStoppedEventArgs e)
        {
            UpdateScheduleDisplay();
        }

        void _engine_EventFeedStarted(object sender, EventStartedEventArgs e)
        {
            UpdateScheduleDisplay();
        }

        void _engine_LiveFeedEngineError(object sender, Exception e)
        {
            UpdateScheduleDisplay();
        }
        void StopFeedHarvester()
        {
            if (null != _engine)
                _engine.Stop();
            _engine.LiveFeedEngineError -= _engine_LiveFeedEngineError;
            
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            UpdateScheduleDisplay();
        }

        private void chkSeries_CheckedChanged(object sender, EventArgs e)
        {
            UpdateScheduleDisplay();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateScheduleDisplay();
        }
    }
}
