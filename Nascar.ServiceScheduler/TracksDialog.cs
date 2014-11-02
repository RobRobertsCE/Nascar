using System;
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
    public partial class TracksDialog : Form
    {
        private IList<ScheduledTrack> _tracks = null;

        #region properties
        private ScheduledTrack SelectedTrack
        {
            get
            {
                return (ScheduledTrack)dataGridView1.CurrentRow.DataBoundItem;
            }
        }
        #endregion

        #region ctor/init
        public TracksDialog()
        {
            InitializeComponent();
            InitializeDialog();
        }

        void InitializeDialog()
        {
            UpdateTrackDisplay();
        }
        #endregion

        #region close dialog
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region display Track
        void UpdateTrackDisplay()
        {
            LoadTrack();
            DisplayTrack();
        }
        void LoadTrack()
        {
            using (var context = new Data.ServiceSchedulerDbContext())
            {
                _tracks = context.ScheduledTracks.ToArray();
            }
        }
        void DisplayTrack()
        {
            this.dataGridView1.DataSource = _tracks;
        }
        #endregion

        #region delete an existing Track
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteSelectedEvent();
        }
        void DeleteSelectedEvent()
        {
            if (null == SelectedTrack) return;
            DeleteTrack(SelectedTrack);
        }
        #endregion

        #region add new Track
        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.DisplayTrackDialog(new ScheduledTrack());
        }
        #endregion

        #region edit an existing Track
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (null == SelectedTrack) return;
            DisplayTrackDialog(SelectedTrack);
        }
        #endregion

        #region ScheduledTrackDialog
        void DisplayTrackDialog(ScheduledTrack TrackdEvent)
        {
            TrackDialog dialog = new TrackDialog(TrackdEvent);

            if (dialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                this.SaveTrack(dialog.Track, dialog.IsNew);
            }
        }
        #endregion

        #region data methods
        void SaveTrack(ScheduledTrack track, bool isNew)
        {
            if (null == track) return;

            using (var context = new Data.ServiceSchedulerDbContext())
            {
                context.ScheduledTracks.Add(track);

                context.Entry(track).State = isNew ?
                                   EntityState.Added :
                                   EntityState.Modified;

                context.SaveChanges();
            }

            UpdateTrackDisplay();
        }
        void DeleteTrack(ScheduledTrack track)
        {
            if (null == track) return;
            using (var context = new Data.ServiceSchedulerDbContext())
            {
                var selected = context.ScheduledTracks.Where(e => e.track_id == track.track_id).FirstOrDefault();
                if (null == selected) return;
                context.ScheduledTracks.Remove(selected);
                context.SaveChanges();
            }
            UpdateTrackDisplay();
        }
        #endregion
    }
}
