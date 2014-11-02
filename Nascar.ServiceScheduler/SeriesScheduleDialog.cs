using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nascar.ServiceScheduler.Data;

namespace Nascar.ServiceScheduler
{
    public partial class SeriesScheduleDialog : Form
    {
        #region fields
        private IList<ScheduledRace> _data = null;
        #endregion

        #region properties
        private ScheduledRace Selected
        {
            get
            {
                return (ScheduledRace)dataGridView1.CurrentRow.DataBoundItem;
            }
        }
        #endregion

        #region ctor/init
        public SeriesScheduleDialog()
        {
            InitializeComponent();
            InitializeDialog();
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

        #region display
        void UpdateDisplay()
        {
            LoadData();
            DisplayData();
        }
        void LoadData()
        {
            using (var context = new Data.ServiceSchedulerDbContext())
            {
                Expression<Func<ScheduledRace, bool>> predicate = r => (
                    chkCup.Checked && ((r.series_id == 1) == chkCup.Checked))
                    || (chkNationwide.Checked && ((r.series_id == 2) == chkNationwide.Checked))
                    || (chkTruck.Checked && ((r.series_id == 3) == chkTruck.Checked));

                _data = context.ScheduledRaces.Include("Track").Include("Series").Where(predicate).OrderBy(r => r.race_date).ToArray();

            }
        }
       
        void DisplayData()
        {
            this.dataGridView1.DataSource = _data;
            this.dataGridView1.Columns["Track"].Visible = false;
            this.dataGridView1.Columns["Series"].Visible = false;
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
            this.DisplayDialog(new ScheduledRace());
        }
        #endregion

        #region edit existing
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (null == Selected) return;
            DisplayDialog(Selected);
        }
        #endregion

        #region ItemDialog
        void DisplayDialog(ScheduledRace itemToDisplay)
        {
            SeriesRaceDialog dialog = new SeriesRaceDialog(itemToDisplay);

            if (dialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                this.Save(dialog.Race, dialog.IsNew);
            }
        }
        #endregion

        #region data methods
        void Save(ScheduledRace item, bool isNew)
        {
            if (null == item) return;

            using (var context = GetContext())
            {
                if (isNew)
                {
                    context.ScheduledRaces.Add(item);
                }
                else
                {
                    context.ScheduledRaces.Attach(item); 
                    context.Entry(item).State = EntityState.Modified;
                }
                
                context.SaveChanges();
            }

            UpdateDisplay();
        }
        void Delete(ScheduledRace item)
        {
            if (null == item) return;
            using (var context = GetContext())
            {
                var selected = context.ScheduledRaces.Where(e => e.series_id == item.series_id).FirstOrDefault();
                if (null == selected) return;
                context.ScheduledRaces.Remove(selected);
                context.SaveChanges();
            }
            UpdateDisplay();
        }
        ServiceSchedulerDbContext GetContext()
        {
            return new ServiceSchedulerDbContext();
        }
        #endregion

        #region filtering
        private void chkCup_CheckedChanged(object sender, EventArgs e)
        {
            UpdateDisplay();
        } 
        #endregion

        #region sessions
        private void btnSessions_Click(object sender, EventArgs e)
        {
            if (null == Selected) return;
            DisplaySessionsDialog(Selected);
        }
        void DisplaySessionsDialog(ScheduledRace race)
        {
            RaceSessionsDialog dialog = new RaceSessionsDialog(race);
            dialog.ShowDialog(this);

        } 
        #endregion
    }
}
