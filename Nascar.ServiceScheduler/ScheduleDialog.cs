using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nascar.Data.Schedule;
using Nascar.ServiceScheduler.Logic;

namespace Nascar.ServiceScheduler
{
    public partial class ScheduleDialog : Form
    {
        #region fields
        private INascarLiveFeedEngine _engine = null;
        private IList<ScheduledEvent> _schedule = null;
        #endregion

        #region properties
        private ScheduledEvent SelectedEvent
        {
            get
            {
                return (ScheduledEvent)dataGridView1.CurrentRow.DataBoundItem;
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
            LoadSchedule();
            DisplaySchedule();
        }
        void LoadSchedule()
        {
            using (var context = new ServiceSchedulerDbContext())
            {
                _schedule = context.ScheduledEvents.ToArray();
            }
        }
        void DisplaySchedule()
        {
            this.dataGridView1.DataSource = _schedule;
        }
        #endregion

        #region delete an existing event from the schedule
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteSelectedEvent();
        }
        void DeleteSelectedEvent()
        {
            if (null == SelectedEvent) return;
            DeleteEvent(SelectedEvent);
        } 
        #endregion
        
        #region add new event to schedule
        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.DisplayScheduledEventDialog(new ScheduledEvent());
        }      
        #endregion

        #region edit an existing event
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (null == SelectedEvent) return;
            DisplayScheduledEventDialog(SelectedEvent);
        }
        #endregion

        #region ScheduledEventDialog
        void DisplayScheduledEventDialog(ScheduledEvent scheduledEvent)
        {
            ScheduledEventDialog dialog = new ScheduledEventDialog(scheduledEvent);

            if (dialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                this.SaveEvent(dialog.ScheduledEvent);
            }
        }
        #endregion

        #region data methods
        void SaveEvent(ScheduledEvent scheduledEvent)
        {
            if (null == scheduledEvent) return;

            using (var context = new ServiceSchedulerDbContext())
            {
                context.ScheduledEvents.Add(scheduledEvent);
                if (scheduledEvent.status == "Not Saved") scheduledEvent.status = "Saved";
                context.Entry(scheduledEvent).State = scheduledEvent.scheduled_event_id == 0 ?
                                   EntityState.Added :
                                   EntityState.Modified; 

                context.SaveChanges();
            }

            UpdateScheduleDisplay();
        }
        void DeleteEvent(ScheduledEvent scheduledEvent)
        {
            if (null == scheduledEvent) return;
            using (var context = new ServiceSchedulerDbContext())
            {
                var selected = context.ScheduledEvents.Where(e => e.scheduled_event_id == scheduledEvent.scheduled_event_id).FirstOrDefault();
                if (null == selected) return;
                context.ScheduledEvents.Remove(selected);
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
        } 
        #endregion

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (btnStartStop.Text=="Start")
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

            _engine = new NascarLiveFeedEngine();
            _engine.Start();
        }
        void StopFeedHarvester()
        {
            if (null != _engine)
                _engine.Stop();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            UpdateScheduleDisplay();
        }
    }
}
