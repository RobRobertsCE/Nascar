using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nascar.Data.Schedule;
using System.Data.Entity.Migrations;

namespace Nascar.ServiceScheduler
{
    public partial class TracksDialog : Form
    {
        private IList<Track> _tracks = null;

        #region properties
        private Track SelectedTrack
        {
            get
            {
                return (Track)dataGridView1.CurrentRow.DataBoundItem;
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
            using (var context = new ScheduleDbContext())
            {
                _tracks = context.Tracks.ToArray();
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
            this.DisplayTrackDialog(new Track());
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
        void DisplayTrackDialog(Track TrackdEvent)
        {
            TrackDialog dialog = new TrackDialog(TrackdEvent);

            if (dialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                this.SaveTrack(dialog.Track, dialog.IsNew);
            }
        }
        #endregion

        #region data methods
        void SaveTrack(Track track, bool isNew)
        {
            if (null == track) return;

            using (var context = new ScheduleDbContext())
            {
                context.Tracks.AddOrUpdate(track);

                //context.Entry(track).State = isNew ?
                //                   EntityState.Added :
                //                   EntityState.Modified;

                context.SaveChanges();
            }

            UpdateTrackDisplay();
        }
        void DeleteTrack(Track track)
        {
            if (null == track) return;
            using (var context = new ScheduleDbContext())
            {
                var selected = context.Tracks.Where(e => e.track_id == track.track_id).FirstOrDefault();
                if (null == selected) return;
                context.Tracks.Remove(selected);
                context.SaveChanges();
            }
            UpdateTrackDisplay();
        }
        #endregion
    }
}
