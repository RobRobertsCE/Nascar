using System;
using System.Linq.Expressions;
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
    public partial class SeriesScheduleDialog : Form
    {
        #region fields
        //private IList<Race> _data = null;
        private IList<RaceView> _data = null;
        #endregion

        #region properties
        private Race Selected
        {
            get
            {
                var rv = (RaceView)dataGridView1.CurrentRow.DataBoundItem;
                using (var context = GetContext())
                {
                    return context.Races.Include("Track").Include("Series").Where(e => e.race_id == rv.race_id).FirstOrDefault();
                }
            }
        }
        private RaceView SelectedRaceView
        {
            get
            {
                return (RaceView)dataGridView1.CurrentRow.DataBoundItem;
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
            using (var context = new ScheduleDbContext())
            {               
                Expression<Func<RaceView, bool>> predicate = r => (
                   chkCup.Checked && ((r.series_id == 1) == chkCup.Checked))
                   || (chkNationwide.Checked && ((r.series_id == 2) == chkNationwide.Checked))
                   || (chkTruck.Checked && ((r.series_id == 3) == chkTruck.Checked));

                _data = context.RaceViews.Include("Track").Include("Series").Where(predicate).OrderBy(r => r.race_date).ToArray();

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
            this.DisplayDialog(new Race());
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
        void DisplayDialog(Race itemToDisplay)
        {
            SeriesRaceDialog dialog = new SeriesRaceDialog(itemToDisplay);

            if (dialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                this.Save(dialog.Race, dialog.IsNew);

                UpdateDisplay();
            }
        }
        #endregion

        #region data methods
        void Save(Race item, bool isNew)
        {
            if (null == item) return;

            using (var context = GetContext())
            {
                context.Races.AddOrUpdate(item);

                context.SaveChanges();
            }

            UpdateDisplay();
        }
        void Delete(Race item)
        {
            if (null == item) return;
            using (var context = GetContext())
            {
                var selected = context.Races.Where(e => e.series_id == item.series_id).FirstOrDefault();
                if (null == selected) return;
                context.Races.Remove(selected);
                context.SaveChanges();
            }
            UpdateDisplay();
        }
        ScheduleDbContext GetContext()
        {
            return new ScheduleDbContext();
        }
        #endregion

        #region filtering
        private void chkSeries_CheckedChanged(object sender, EventArgs e)
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
        void DisplaySessionsDialog(Race race)
        {
            RaceSessionsDialog dialog = new RaceSessionsDialog(race);
            dialog.ShowDialog(this);

        }
        #endregion
    }
}
