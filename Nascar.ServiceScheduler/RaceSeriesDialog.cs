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
    public partial class RaceSeriesDialog : Form
    {
        #region fields
        private IList<Series> _data = null; 
        #endregion

        #region properties
        private Series Selected
        {
            get
            {
                return (Series)dataGridView1.CurrentRow.DataBoundItem;
            }
        }
        #endregion

        #region ctor/init
        public RaceSeriesDialog()
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
                _data = context.Series.ToArray();
            }
        }
        void DisplayData()
        {
            this.dataGridView1.DataSource = _data;
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
            this.DisplayDialog(new Series());
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
        void DisplayDialog(Series itemToDisplay)
        {
            SeriesDialog dialog = new SeriesDialog(itemToDisplay);

            if (dialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                this.Save(dialog.Series, dialog.IsNew);
            }
        }
        #endregion

        #region data methods
        void Save(Series item, bool isNew)
        {
            if (null == item) return;

            using (var context = GetContext())
            {
                context.Series.Add(item);

                context.Entry(item).State = isNew ?
                                   EntityState.Added :
                                   EntityState.Modified;

                context.SaveChanges();
            }

            UpdateDisplay();
        }
        void Delete(Series item)
        {
            if (null == item) return;
            using (var context = GetContext())
            {
                var selected = context.Series.Where(e => e.series_id == item.series_id).FirstOrDefault();
                if (null == selected) return;
                context.Series.Remove(selected);
                context.SaveChanges();
            }
            UpdateDisplay();
        }
        ScheduleDbContext GetContext()
        {
            return new ScheduleDbContext();
        }
        #endregion               
    }
}
