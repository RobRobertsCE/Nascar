using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nascar.Api;
using Nascar.Api.Models;
using Nascar.Data;
using Newtonsoft.Json;

namespace Nascar.WinApp.Views
{
    public partial class ReplaySelectionDialog : Form
    {
        IList<RawFeedRecordView> replays = new List<RawFeedRecordView>();

        public RawFeedRecordView SelectedReplay { get;  private set; }

        public ReplaySelectionDialog()
        {
            InitializeComponent();

            LoadAvailableReplays();

            DisplayAvailableReplays();
        }

        void LoadAvailableReplays()
        {
            try
            {
                using (NascarDbContext context = GetContext())
                {
                    replays = context.RawFeedRecordViews.OrderBy(r => r.date_time).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message);
            }
        }

        void DisplayAvailableReplays()
        {
            try
            {
                replayListView.SuspendLayout();

                replayListView.Items.Clear();

                using (NascarDbContext context = GetContext())
                {
                    foreach (RawFeedRecordView replay in replays)
                    {
                        ListViewItem lvi = new ListViewItem(replay.date_time.ToString()) { Tag = replay };
                        lvi.SubItems.Add(replay.series_name);
                        lvi.SubItems.Add(replay.track_name);
                        lvi.SubItems.Add(replay.run_type_name);
                        lvi.SubItems.Add(replay.run_name);
                        lvi.SubItems.Add(replay.feed_count.ToString());

                        replayListView.Items.Add(lvi);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message);
            }
            finally
            {
                replayListView.ResumeLayout();
            }
        }

        NascarDbContext GetContext()
        {
            return new NascarDbContext();
        }

        private void replayListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if( replayListView.SelectedItems.Count>0)
            {
                btnOK.Enabled = true;
                this.SelectedReplay = (RawFeedRecordView)replayListView.SelectedItems[0].Tag;
            }
        }
    }
}
