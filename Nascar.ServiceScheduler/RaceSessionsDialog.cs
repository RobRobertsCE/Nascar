using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nascar.Data.Schedule;

namespace Nascar.ServiceScheduler
{
    public partial class RaceSessionsDialog : Form
    {
       private IList<RaceSessionView> _data = null;
        private Race _race = null;

        #region properties
        private RaceSession Selected
        {
            get
            {
                var rv = (RaceSessionView)dataGridView1.CurrentRow.DataBoundItem;
                using (var context = GetContext())
                {
                    return context.RaceSessions.Include("Race").Include("Race.Track").Include("Race.Series").Include("Session").Where(e => e.race_session_id == rv.race_session_id).FirstOrDefault();
                }
            }
        }
        private RaceSessionView SelectedView
        {
            get
            {
                return (RaceSessionView)dataGridView1.CurrentRow.DataBoundItem;
            }
        }
        #endregion

        #region ctor/init
        public RaceSessionsDialog(Race race)
        {
            InitializeComponent();
            _race = race;
            InitializeDialog();
            this.Text = "Sessions - " + race.Series.series_name + " - " + race.Track.track_name;
        }

        void InitializeDialog()
        {
            UpdateDisplay();
        }
        #endregion

        #region close dialog
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region load / display data
        void UpdateDisplay()
        {
            LoadData();
            DisplayData();
        }
        void LoadData()
        {
            using (var context = GetContext())
            {
               _data = context.RaceSessionViews.Include("Race").Include("Race.Series").Include("Race.Track").Where(s => s.race_id == _race.race_id).OrderBy(t => t.start_time).ToList();
            }
        }
        void DisplayData()
        {
            this.dataGridView1.DataSource = _data;
            this.dataGridView1.Columns["race_session_id"].Visible = false;
            this.dataGridView1.Columns["race_id"].Visible = false; 
            this.dataGridView1.Columns["session_id"].Visible = false;
            this.dataGridView1.Columns["track_id"].Visible = false;
            this.dataGridView1.Columns["track_name"].Visible = false;
            this.dataGridView1.Columns["series_id"].Visible = false;
            this.dataGridView1.Columns["series_name"].Visible = false;
            this.dataGridView1.Columns["Session"].Visible = false;
            this.dataGridView1.Columns["Race"].Visible = false;
            this.dataGridView1.Columns["Session"].Visible = false;
            this.dataGridView1.Columns["Track"].Visible = false;
            this.dataGridView1.Columns["Series"].Visible = false;
            if (this.dataGridView1.Rows.Count > 0)
                this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].Selected = true;
        }
        ScheduleDbContext GetContext()
        {
            return new ScheduleDbContext();
        }
        #endregion

        #region delete
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteSelected();
        }
        void DeleteSelected()
        {
            if (null == Selected) return;
            Delete(Selected);
        }
        #endregion

        #region add new
        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.DisplayDialog(new RaceSession() { race_id = _race.race_id, sequence = 1, session_id = 1, start_time = _race.race_date, end_time = _race.race_date });
        }
        #endregion

        #region add next

        private void btnAddAnother_Click(object sender, EventArgs e)
        {
            RaceSession nextSession = new RaceSession() { race_id = _race.race_id };

            if (null != Selected)
            {
                if (Selected.session_id == 1) // practice 
                {
                    if (Selected.Race.series_id == 3) // truck 
                    {
                        // add qualifying session 
                        nextSession.session_id = 2; // qualifying 
                        nextSession.sequence = 1;
                        nextSession.start_time = Selected.start_time.AddHours(3);
                        nextSession.end_time = nextSession.start_time.AddHours(1);
                    }
                    else if (Selected.Race.series_id == 2) // nationwide 
                    {
                        if (Selected.sequence == 1)// first practice 
                        {
                            nextSession.session_id = 1; // add second practice 
                            nextSession.sequence = 2;
                            nextSession.start_time = Selected.start_time.AddHours(3);
                            nextSession.end_time = nextSession.start_time.AddHours(1);
                        }
                        else // second practice 
                        {
                            // add qualifying session 
                            nextSession.session_id = 2; // qualifying 
                            nextSession.sequence = 1;
                            nextSession.start_time = Selected.start_time.AddHours(3);
                            nextSession.end_time = nextSession.start_time.AddMinutes(15);
                        }
                    }
                    else if (Selected.Race.series_id == 1) // cup 
                    {
                        if (Selected.sequence == 1)// first practice 
                        {
                            // add second practice 
                            nextSession.session_id = 1; // add second practice 
                            nextSession.sequence = 2;
                            nextSession.start_time = Selected.start_time.AddHours(3);
                            nextSession.end_time = nextSession.start_time.AddHours(1);
                        }
                        else if (Selected.sequence == 2)// second practice 
                        {
                            // add qualifying 
                            // add qualifying session 
                            nextSession.session_id = 2; // qualifying 
                            nextSession.sequence = 1;
                            nextSession.start_time = Selected.start_time.AddDays(1);
                            nextSession.end_time = nextSession.start_time.AddMinutes(15);
                        }
                        else if (Selected.sequence == 3)// happy hour 
                        {
                            // add race 
                            nextSession.session_id = 3; // race 
                            nextSession.sequence = 1;
                            nextSession.start_time = Selected.start_time.AddDays(1);
                            nextSession.end_time = nextSession.start_time.AddHours(5);
                        }
                    }
                }
                else if (Selected.session_id == 2) // qualifying 
                {
                    if (Selected.Race.series_id == 3) // truck 
                    {
                        // add race session 
                        nextSession.session_id = 3; // race 
                        nextSession.sequence = 1;
                        nextSession.start_time = Selected.start_time.AddHours(3);
                        nextSession.end_time = nextSession.start_time.AddHours(3);
                    }
                    else
                    {   // qualifying - cup or nationwide 
                        if (Selected.sequence < 3) // not last qualifying session 
                        {
                            // add next qualifying session 
                            nextSession.session_id = 2;
                            nextSession.sequence = Selected.sequence + 1;
                            nextSession.start_time = Selected.end_time;
                            nextSession.end_time = nextSession.start_time.AddMinutes(15);
                        }
                        else // last qualifying session 
                        {
                            if (Selected.Race.series_id == 1) // cup - add final practice.
                            {
                                nextSession.session_id = 1; // practice 
                                nextSession.sequence = 3;
                                nextSession.start_time = Selected.start_time.AddHours(3);
                                nextSession.end_time = Selected.end_time.AddHours(5);
                            }
                            else if (Selected.Race.series_id == 2)// nationwide - add race 
                            {
                                nextSession.session_id = 3; // race 
                                nextSession.sequence = 1;
                                nextSession.start_time = Selected.start_time.AddDays(1);
                                nextSession.start_time = Selected.start_time.AddDays(1).AddHours(3);
                            }
                        }
                    }
                }
            }
            this.DisplayDialog(nextSession);
        }
        #endregion

        #region edit existing
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (null == Selected) return;
            DisplayDialog(Selected);
        }
        #endregion

        #region RaceSessionDialog
        void DisplayDialog(RaceSession selected)
        {
            RaceSessionDialog dialog = new RaceSessionDialog(selected);

            if (dialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                this.Save(dialog.RaceSession);
            }
        }
        #endregion

        #region data methods
        void Save(RaceSession item)
        {
            if (null == item) return;

            using (var context = GetContext())
            {
                context.RaceSessions.AddOrUpdate(item);

                context.SaveChanges();
            }

            UpdateDisplay();
        }
        void Delete(RaceSession item)
        {
            if (null == item) return;
            using (var context = GetContext())
            {
                var selected = context.RaceSessions.Where(e => e.race_session_id == item.race_session_id).FirstOrDefault();
                if (null == selected) return;
                context.RaceSessions.Remove(selected);
                context.SaveChanges();
            }
            UpdateDisplay();
        }
        #endregion

#region  Add to Schedule
        private void btnSchedule_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = GetContext())
                {
                    if (null == Selected) return;

                    RaceSession session =  context.RaceSessions.Include("Race").Include("Race.Track").Include("Race.Series").Include("Session").Where(s => s.race_session_id == Selected.race_session_id).FirstOrDefault();;

                    var scheduledEvent = context.RaceEvents.Include("RaceSession").Include("RaceSession.Race.Track").Include("RaceSession.Race.Series").Where(s => s.race_session_id == session.race_session_id).FirstOrDefault();
                   
                    if (null==scheduledEvent)
                    {
                        scheduledEvent =  new RaceEvent()
                        {
                            race_session_id = session.race_session_id,
                            status = "Not Saved",
                            enabled = true,
                            scheduled_event_start = session.start_time,
                            scheduled_event_end = session.end_time
                        };
                        context.RaceEvents.Add(scheduledEvent);
                        scheduledEvent.race_session_id = session.race_session_id;
                        scheduledEvent.RaceSession = session;
                    }

                    ScheduledEventDialog dialog = new ScheduledEventDialog(scheduledEvent);

                    if (DialogResult.OK == dialog.ShowDialog(this))
                    {
                        scheduledEvent.status = "Saved";
                        
                        context.SaveChanges();

                        UpdateDisplay();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message);
            }
        }


#endregion

    }
}
