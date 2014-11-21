using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nascar.WinApp.Views
{
    public partial class StopwatchView : UserControl
    {
        #region locals
        enum DisplayMode
        {
            Previous,
            Best,
            Next,
            Current,
            Ready
        }

        DisplayMode mode = DisplayMode.Current;
        IList<StopwatchData> laps = new List<StopwatchData>();
        int lapIdx = 0;
        bool currentLapDisplayOn = false;
        StopwatchData BestLap
        {
            get
            {
                return laps.OrderBy(l => l.LapTime).FirstOrDefault();
            }

        }
        int CurrentLapNumber
        {
            get
            {
                return lapIdx + 1;
            }
        }
        int LapCount
        {
            get
            {
                return laps.Count();
            }
        }
        #endregion

        #region properties
        double lastElapsedTime = 0;
        StopwatchData data;
        public StopwatchData Data
        {
            get
            {
                return data;
            }
            set
            {
                if (value == null) return;
                if (value.ElapsedTime == lastElapsedTime) return;
                lastElapsedTime = value.ElapsedTime;
                data = value;
                laps.Add(data);
                lapIdx = laps.Count - 1;
                SetViewState(DisplayMode.Current);
                DisplayData(data);               
            }
        }
        #endregion

        #region ctor
        public StopwatchView()
        {
            InitializeComponent();
            SetViewState(DisplayMode.Ready);
        }

        public StopwatchView(StopwatchData data)
            : this()
        {
            this.Data = data;
        }
        #endregion

        #region display data
        void DisplayData(StopwatchData swd)
        {
            if (null == swd) return;

            this.lblCarNumber.Text = swd.CarNumber.ToString();
            this.lblLapCount.Text = LapCount.ToString();
            this.lblLapNumber.Text = swd.LapNumber.ToString();
            var best = BestLap;
            if (null!=best)
                this.lblBestLap.Text = best.LapNumber.ToString();
            this.SetLapTime(swd.LapTime);
            this.SetLapSpeed(swd.LapSpeed);
        }

        void SetLapTime(double lapTime)
        {
            int ints = (int)Math.Floor(lapTime);
            double fractions = lapTime - ints;

            this.lblLapTime.Text = ints.ToString();
            this.lblLapTimeFractions.Text = String.Format("{0:.000}", fractions);
        }

        void SetLapSpeed(double lapSpeed)
        {
            int ints = (int)Math.Floor(lapSpeed);
            double fractions = lapSpeed - ints;

            this.lblLapMph.Text = ints.ToString();
            this.lblLapMphFractions.Text = String.Format("{0:.000}", fractions);
        }

        void DisplayLapIndexLap()
        {
            DisplayData(GetLap(lapIdx));
        }

        #endregion

        #region button click handlers
        private void btnBest_Click(object sender, EventArgs e)
        {
            SetViewState(DisplayMode.Best);

            var bestLap = laps.OrderBy(l => l.LapTime).FirstOrDefault();

            lapIdx = bestLap.LapNumber - 1;

            DisplayData(bestLap);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            SetViewState(DisplayMode.Previous); 
            DecrementLapIndex();
            DisplayLapIndexLap();
        }

        private void btnCurrent_Click(object sender, EventArgs e)
        {
            SetViewState(DisplayMode.Current);
            SetLapIndexToCurrent();
            DisplayLapIndexLap();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            SetViewState(DisplayMode.Next);
            IncrementLapIndex();
            DisplayLapIndexLap();
        }

        #endregion

        #region private methods
        void CurrentLapTimerOn()
        {
            currentLapTimer.Enabled = true;
        }
        void CurrentLapTimerOff()
        {
            currentLapTimer.Enabled = false;
        }
        void SetLapIndexToCurrent()
        {
            lapIdx = this.LapCount - 1;
            btnNext.Enabled = false;
            btnPrevious.Enabled = true;
        }
        void IncrementLapIndex()
        {
            if (lapIdx < this.LapCount - 1)
            {
                lapIdx++;
            }

            btnNext.Enabled = (lapIdx < this.LapCount - 1);
            btnPrevious.Enabled = (lapIdx > 0);
        }
        void DecrementLapIndex()
        {
            if (lapIdx > 0)
            {
                lapIdx--;
            }

            btnNext.Enabled = (lapIdx < this.LapCount - 1);
            btnPrevious.Enabled = (lapIdx > 0);
        }

        StopwatchData GetLap(int idx)
        {
            return laps[idx];
        }

        void SetViewState(DisplayMode newMode)
        {
            this.lsBest.Visible = false;
            this.lsLast.Visible = false;
            this.lsNext.Visible = false;
            this.lsCurrent.Visible = false;

            CurrentLapTimerOff();

            switch (newMode)
            {
                case DisplayMode.Best:
                    {
                        this.lsBest.Visible = true;
                        break;
                    }
                case DisplayMode.Current:
                    {
                        this.lsCurrent.Visible = true;
                        break;
                    }
                case DisplayMode.Previous:
                    {
                        this.lsLast.Visible = true;
                        break;
                    }
                case DisplayMode.Next:
                    {
                        this.lsNext.Visible = true;
                        break;
                    }
                case DisplayMode.Ready:
                    {
                        CurrentLapTimerOn();
                        this.lsCurrent.Visible = true;
                        break;
                    }
            }

            mode = newMode;
        }
        #endregion

        #region timer tick
        private void currentLapTimer_Tick(object sender, EventArgs e)
        {
            if (mode != DisplayMode.Ready) return;

            string displayChars;

            if (this.currentLapDisplayOn)
                displayChars = "";
            else
                displayChars = "- - -";

            this.lblLapTime.Text = displayChars;
            this.lblLapTimeFractions.Text = displayChars;
            this.lblLapMph.Text = displayChars;
            this.lblLapMphFractions.Text = displayChars;

            this.lsCurrent.Visible = currentLapDisplayOn;

            currentLapDisplayOn = !currentLapDisplayOn;
        }
		 
	#endregion
    }

    public class StopwatchData
    {
        public double ElapsedTime { get; set; }
        public double LapTime { get; set; }
        public double LapSpeed { get; set; }
        public string CarNumber { get; set; }
        public int LapNumber { get; set; }

        public StopwatchData(string vehicle_number)
        {          
            this.CarNumber = vehicle_number;
        }
    }
}
