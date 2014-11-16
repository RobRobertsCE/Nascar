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
using Nascar.WinApp.Views;
using Newtonsoft.Json;

namespace Nascar.WinApp
{
    public partial class NascarDataTesting : Form
    {
        #region enumerations
        private enum IndicatorState
        {
            Off,
            Ready,
            Busy,
            Error
        }
        #endregion

        #region constants
        private const bool DisableControls = false;
        private const bool EnableControls = true;
        private const int CupSeriesId = 1;
        private const int XFinitySeriesId = 2;
        private const int TruckSeriesId = 3;
        #endregion

        #region fields
        IList<StopwatchDialog> stopwatches = new List<StopwatchDialog>();
        ILiveFeedProcessor processor = null;
        IApiFeedProcessor harvester = null;
        FeedManager manager = null;
        ReplayManager replayManager = null; 
        int currentRaceId = 0;
        int feedCount = 0;
        DateTime startTime;
        private int currentRunId;
        #endregion

        #region properties
        SeriesName SelectedSeries
        {
            get
            {
                if (rbCup.Checked) return SeriesName.Cup;
                if (rbXfinity.Checked) return SeriesName.XFinity;
                if (rbTruck.Checked) return SeriesName.Truck;

                return SeriesName.Cup;
            }
        }
        #endregion

        #region ctor
        public NascarDataTesting()
        {
            InitializeComponent();
            try
            {
                LoadRaceSelectionList(CupSeriesId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex);
            }
        }
        #endregion

        #region start live feed
        private void btnStartLiveFeed_Click(object sender, EventArgs e)
        {
            StartLiveFeed();
        }
        void StartLiveFeed()
        {
            try
            {
                InitializeFeedStats();

                SetControlState(DisableControls);

                InitializeManager();

                manager.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex);
            }
        }
        void manager_LiveFeedStarted(object sender, EventArgs e)
        {
            Console.WriteLine("FeedManager Started");
        }
        #endregion

        #region stop live feed
        private void btnStopLiveFeed_Click(object sender, EventArgs e)
        {
            StopLiveFeed();
        }
        void StopLiveFeed()
        {
            try
            {
                if (null == manager) return;
                manager.Stop();

                SetControlState(EnableControls);
                SetFeedIndicatorState(IndicatorState.Off);
                SetRawFeedIndicatorState(IndicatorState.Off);

                ReloadRaceSelectionList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex);
            }
        }
        void manager_LiveFeedStopped(object sender, EventArgs e)
        {
            Console.WriteLine("FeedManager Stopped");
        }
        #endregion

        #region control state
        void SetControlState(bool controlEnabled)
        {
            grpSeries.Enabled = controlEnabled;
            btnStartLiveFeed.Enabled = controlEnabled;
            btnStopLiveFeed.Enabled = !controlEnabled;
        }
        void SetFeedIndicatorState(IndicatorState state)
        {
            switch (state)
            {
                case IndicatorState.Off:
                    {
                        picFeedState.BackColor = Color.WhiteSmoke;
                        break;
                    }
                case IndicatorState.Ready:
                    {
                        picFeedState.BackColor = Color.Green;
                        break;
                    }
                case IndicatorState.Busy:
                    {
                        picFeedState.BackColor = Color.LimeGreen;
                        break;
                    }
                case IndicatorState.Error:
                    {
                        picFeedState.BackColor = Color.Red;
                        break;
                    }
                default:
                    {
                        picFeedState.BackColor = Color.Black;
                        break;
                    }
            }
        }
        void SetRawFeedIndicatorState(IndicatorState state)
        {
            switch (state)
            {
                case IndicatorState.Off:
                    {
                        picRawFeedState.BackColor = Color.WhiteSmoke;
                        break;
                    }
                case IndicatorState.Ready:
                    {
                        picRawFeedState.BackColor = Color.Green;
                        break;
                    }
                case IndicatorState.Busy:
                    {
                        picRawFeedState.BackColor = Color.LimeGreen;
                        break;
                    }
                case IndicatorState.Error:
                    {
                        picRawFeedState.BackColor = Color.Red;
                        break;
                    }
                default:
                    {
                        picRawFeedState.BackColor = Color.Black;
                        break;
                    }
            }
        }
        void InitializeManager()
        {
            if (null != manager)
            {
                manager.Stop();
                manager.LiveFeedStarted -= manager_LiveFeedStarted;
                manager.LiveFeedRawData -= manager_RawFeedEvent;
                manager.LiveFeedStopped -= manager_LiveFeedStopped;
                manager.LiveFeedEvent -= manager_LiveFeedEvent;
                manager.Dispose();
                if (null != manager) manager = null;
            }
            lblRaceId.Text = String.Format("RaceId: {0}", currentRaceId);
            manager = new FeedManager(SelectedSeries, currentRaceId);
            manager.LiveFeedStarted += manager_LiveFeedStarted;
            manager.LiveFeedStopped += manager_LiveFeedStopped;
            if (chkHarvest.Checked)
            {
                manager.LiveFeedRawData += manager_RawFeedEvent;
                SetRawFeedIndicatorState(IndicatorState.Ready);
            }
            if (chkProcess.Checked || chkDisplay.Checked)
            {
                manager.LiveFeedEvent += manager_LiveFeedEvent;
                SetFeedIndicatorState(IndicatorState.Ready);
            }

        }
        void InitializeFeedStats()
        {
            feedCount = 0;
            startTime = DateTime.Now;
            lblFeedStart.Text = String.Format("Feed Start: {0}", startTime.ToString());
        }
        void UpdateFeedCount()
        {
            feedCount++;
            lblFeedCount.Text = String.Format("Feed Count: {0}", feedCount);

        }
        #endregion

        #region feed data processing
        void manager_LiveFeedEvent(object sender, LiveFeedEventArgs e)
        {
            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    ProcessFeedData(e.LiveFeed);

                    UpdateStopwatches(e);
                });

                this.Invoke((MethodInvoker)delegate
                {
                    UpdateFeedCount();
                });
            }
            catch (Exception ex)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    SetFeedIndicatorState(IndicatorState.Error);
                });
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex);
            }
        }
        void ProcessFeedData(LiveFeedModel model)
        {
            SetFeedIndicatorState(IndicatorState.Busy);

            if (chkProcess.Checked)
                RecordFeedData(model);

            if (chkDisplay.Checked)
                DisplayFeedData(model);

            SetFeedIndicatorState(IndicatorState.Ready);
        }
        void RecordFeedData(LiveFeedModel model)
        {
            if (null == processor)
                processor = new LiveFeedProcessor();

            processor.ProcessLiveFeed(model);
        }
        void DisplayFeedData(LiveFeedModel model)
        {
            liveFeedDisplay1.Model = model;
        }
        #endregion

        #region raw data processing
        void manager_RawFeedEvent(object sender, string rawFeedData)
        {
            try
            {
                if (chkHarvest.Checked)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        HarvestRawData(rawFeedData);
                    });
                }
            }
            catch (Exception ex)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    SetRawFeedIndicatorState(IndicatorState.Error);
                });
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex);
            }
        }
        void HarvestRawData(string rawData)
        {
            try
            {
                SetRawFeedIndicatorState(IndicatorState.Busy);

                if (null == harvester)
                    harvester = new LiveFeedHarvester();

                harvester.ProcessFeedData(rawData);

                SetRawFeedIndicatorState(IndicatorState.Ready);
            }
            catch (Exception ex)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    SetRawFeedIndicatorState(IndicatorState.Error);
                });
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex);
            }
        }
        #endregion

        #region load race selection list
        void ReloadRaceSelectionList()
        {
            LoadRaceSelectionList((int)SelectedSeries);
        }
        void LoadRaceSelectionList(int series_id)
        {
            using (NascarDbContext context = new NascarDbContext())
            {
                cmbRace.SelectedIndex = -1;
                cmbRace.Items.Clear();

                cmbRace.DisplayMember = "track_name";
                cmbRace.ValueMember = "race_id";

                var races = context.Races.Include("Track").Where(s => s.series_id == series_id).Select(x => new RaceEvent() { race_id = x.race_id, track_name = x.race_id + " " + x.Track.track_name });

                foreach (var race in races)
                {
                    cmbRace.Items.Add(race);
                }
            }
        }

        #endregion

        private class RaceEvent
        {
            public int race_id { get; set; }
            public string track_name { get; set; }
        }

        #region Series / Race Selection
        private void rbSeries_CheckedChanged(object sender, EventArgs e)
        {
            this.LoadRaceSelectionList((int)SelectedSeries);
        }
        private void cmbRace_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRace.SelectedItem == null)
            {
                btnStartLiveFeed.Enabled = false;
            }
            else
            {
                btnStartLiveFeed.Enabled = true;
                var race = (RaceEvent)cmbRace.SelectedItem;
                currentRaceId = race.race_id;
                txtRaceId.Text = currentRaceId.ToString();
            }

        } 
        #endregion

        #region manually increment/decrement race id
        private void button1_Click(object sender, EventArgs e)
        {
            currentRaceId--;
            txtRaceId.Text = currentRaceId.ToString();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            currentRaceId++;
            txtRaceId.Text = currentRaceId.ToString();
        } 
        #endregion

        #region Start Replay
        private void startReplay_Click(object sender, EventArgs e)
        {
            StartReplay();
        }
        void StartReplay()
        {
            try
            {
                if (null == replayManager)
                {
                    InitializeFeedStats();

                    SetControlState(DisableControls);

                    InitializeReplayManager();
                }

                replayManager.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex);
            }
        }
        void InitializeReplayManager()
        {
            if (null != replayManager)
            {
                replayManager.Stop();
                replayManager.LiveFeedStarted -= manager_LiveFeedStarted;
                replayManager.LiveFeedStopped -= manager_LiveFeedStopped;
                replayManager.LiveFeedEvent -= manager_ReplayEvent;
                replayManager.LiveFeedDataLoaded -= replayManager_LiveFeedDataLoaded;
                replayManager.Dispose();
                if (null != replayManager) replayManager = null;
            }
            lblRaceId.Text = String.Format("RaceId: {0}", currentRaceId);
            replayManager = new ReplayManager(SelectedSeries, currentRaceId, currentRunId);
            replayManager.LiveFeedStarted += manager_LiveFeedStarted;
            replayManager.LiveFeedStopped += manager_LiveFeedStopped;
            replayManager.LiveFeedEvent += manager_ReplayEvent;
            replayManager.LiveFeedDataLoaded += replayManager_LiveFeedDataLoaded;
            if (chkProcess.Checked)
            {
                SetFeedIndicatorState(IndicatorState.Ready);
            }
        }

        void replayManager_LiveFeedDataLoaded(object sender, EventArgs e)
        {
            Console.WriteLine("replayManager_LiveFeedDataLoaded");
        } 
        #endregion

        #region Stop Replay
        private void stopReplay_Click(object sender, EventArgs e)
        {
            StopReplay();
        }
        void StopReplay()
        {
            try
            {
                if (null == replayManager) return;
                replayManager.Stop();

                SetControlState(EnableControls);
                SetFeedIndicatorState(IndicatorState.Off);
                SetRawFeedIndicatorState(IndicatorState.Off);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex);
            }
        } 
        #endregion

        void manager_ReplayStarted(object sender, EventArgs e)
        {
            Console.WriteLine("ReplayManager Started");
        }
        void manager_ReplayStopped(object sender, EventArgs e)
        {
            Console.WriteLine("ReplayManager Stopped");
        }
        void manager_ReplayEvent(object sender, LiveFeedEventArgs e)
        {
            try
            {
                this.SuspendLayout();

                this.Invoke((MethodInvoker)delegate
                {
                    if (chkProcess.Checked)  ProcessReplayData(e.LiveFeed);

                    if (chkDisplay.Checked) DisplayReplayData(e.LiveFeed);

                    UpdateStopwatches(e);

                });

                this.Invoke((MethodInvoker)delegate
                {
                    UpdateFeedCount();
                });
            }
            catch (Exception ex)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    SetFeedIndicatorState(IndicatorState.Error);
                });
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex);
            }
            finally
            {
                this.ResumeLayout();
            }
        }

        void ProcessReplayData(LiveFeedModel model)
        {
            SetFeedIndicatorState(IndicatorState.Busy);

            DisplayFeedData(model);

            SetFeedIndicatorState(IndicatorState.Ready);
        }
        void DisplayReplayData(LiveFeedModel model)
        {
            SetFeedIndicatorState(IndicatorState.Busy);

            DisplayFeedData(model);

            SetFeedIndicatorState(IndicatorState.Ready);
        }

        private void pauseReplay_Click(object sender, EventArgs e)
        {
            if (null == replayManager) return;
            replayManager.Pause();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (null == replayManager) return;
            replayManager.GetSingleFeed();
        }

        void UpdateStopwatches(LiveFeedEventArgs e)
        {
            if (stopwatches.Count() > 0)
            {
                foreach (StopwatchDialog dialog in stopwatches)
                {
                    dialog.stopwatch_LiveFeedEvent(this, e);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                StopwatchDialog dialog = new StopwatchDialog(this.txtStopwatchCarNumber.Text);

                dialog.Show();

                stopwatches.Add(dialog);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void btnSelectReplay_Click(object sender, EventArgs e)
        {
            try
            {
                chkProcess.Checked = false;

                ReplaySelectionDialog dialog = new ReplaySelectionDialog();

                if (DialogResult.OK == dialog.ShowDialog(this)) ;
                {
                    LoadReplay(dialog.SelectedReplay);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        void LoadReplay(RawFeedRecordView replay)
        {
            if (replay.series_id == 1)
                rbCup.Checked = true;
            else if (replay.series_id == 2)
                rbXfinity.Checked = true;
            else if (replay.series_id == 3)
                rbTruck.Checked = true;

            currentRunId = replay.run_id;
            currentRaceId = replay.race_id;
            txtRaceId.Text = currentRaceId.ToString();

            StartReplay();
        }

        private void btnTrackViewMapper_Click(object sender, EventArgs e)
        {
            try
            {
                TrackViewDialog dialog = new TrackViewDialog();

                dialog.ShowDialog(this);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
