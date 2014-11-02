using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nascar.Data.Schedule;

namespace Nascar.ServiceScheduler
{
    public partial class RaceSessionsDialog : Form
    {
        private IList<ScheduledRaceSession> _data = null;
        private ScheduledRace _race = null;

        #region properties
        private ScheduledRaceSession Selected
        {
            get
            {
                return (ScheduledRaceSession)dataGridView1.CurrentRow.DataBoundItem;
            }
        }
        #endregion

        #region ctor/init
        public RaceSessionsDialog(ScheduledRace race)
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
            using (var context = new ServiceSchedulerDbContext())
            {
                _data = context.ScheduledRaceSessions.Include("Race").Include("Race.Series").Include("Race.Track").Where(s => s.race_id == _race.race_id).OrderBy(t => t.start_time).ToList();
            }
        }
        void DisplayData()
        {
            this.dataGridView1.DataSource = _data;
            this.dataGridView1.Columns["Race"].Visible = false;
            this.dataGridView1.Columns["Session"].Visible = false;
            if (this.dataGridView1.Rows.Count>0)
                this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].Selected = true;
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
            this.DisplayDialog(new ScheduledRaceSession() { race_id = _race.race_id, sequence=1, session_id = 1, start_time = _race.race_date, end_time = _race.race_date });
        }
        #endregion
        
        #region add next

        private void btnAddAnother_Click(object sender, EventArgs e)
        {
            ScheduledRaceSession nextSession = new ScheduledRaceSession() { race_id = _race.race_id };

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
        void DisplayDialog(ScheduledRaceSession selected)
        {
            RaceSessionDialog dialog = new RaceSessionDialog(selected);

            if (dialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                this.Save(dialog.RaceSession, dialog.IsNew);
            }
        }
        #endregion

        #region data methods
        void Save(ScheduledRaceSession item, bool isNew)
        {
            if (null == item) return;

            using (var context = new ServiceSchedulerDbContext())
            {
                if (isNew)
                {
                    context.ScheduledRaceSessions.Add(item);
                }
                else
                {
                    context.ScheduledRaceSessions.Attach(item);
                    context.Entry(item).State = EntityState.Modified;
                }

                context.SaveChanges();
            }

            UpdateDisplay();
        }
        void Delete(ScheduledRaceSession item)
        {
            if (null == item) return;
            using (var context = new ServiceSchedulerDbContext())
            {
                var selected = context.ScheduledRaceSessions.Where(e => e.race_session_id == item.race_session_id).FirstOrDefault();
                if (null == selected) return;
                context.ScheduledRaceSessions.Remove(selected);
                context.SaveChanges();
            }
            UpdateDisplay();
        }
        #endregion

    }
}
