using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nascar.WinApp.Views
{
    public class GreenFlagRun
    {
        #region properties
        public int run_idx = 0;
        public int start_lap;
        public int end_lap;
        public IList<LapTimeData> Laps;
        public int start_position;
        public int end_position;
        public bool is_active = false;
        public int PositionGainLoss
        {
            get
            {
                return start_position - end_position;
            }
        } 
        #endregion

        #region ctor
        public GreenFlagRun(int lap, int position, int runIdx)
        {
            this.start_lap = lap;
            this.start_position = position;
            this.run_idx = runIdx;
            Laps = new List<LapTimeData>();
            is_active = true;
        } 
        #endregion

        #region public methods
        public void EndRun(int lap, int position)
        {
            if (is_active == false) return;
            this.end_lap = lap;
            this.end_position = position;
            is_active = false;
        }

        public void AddLapData(LapTimeData lap_time_data)
        {
            if (is_active == false) return;
            Laps.Add(lap_time_data);
        }

        public double FirstNLapsOfRunAverageLap(int n, bool requireNLaps)
        {
            if (0 == Laps.Count) return 0;

            int count = (Laps.Count >= n) ? n : Laps.Count;

            if ((Laps.Count > 0) && (!requireNLaps || (requireNLaps && (count >= n))))
            {
                return Laps.OrderBy(l => l.LapNumber).Take(count).Average(l => l.LapTime);
            }
            else
            {
                return 0;
            }
        }

        public double LastNLapsOfRunAverageLap(int n, bool requireNLaps)
        {
            if (0 == Laps.Count) return 0;

            int count = (Laps.Count >= n) ? n : Laps.Count;

            if ((Laps.Count > 0) && (!requireNLaps || (requireNLaps && (count >= n))))
            {
                return Laps.OrderByDescending(l => l.LapNumber).Take(count).Average(l => l.LapTime);
            }
            else
            {
                return 0;
            }
        }

        public double FirstNPercentOfRunAverageLap(int n)
        {
            if (0 == Laps.Count) return 0;

            double lapPercentCount = n / Laps.Count;
            int count = (int)Math.Ceiling(lapPercentCount);

            return FirstNLapsOfRunAverageLap(count, false);
        }

        public double LastNPercentOfRunAverageLap(int n, bool requireNLaps)
        {
            if (0 == Laps.Count) return 0;

            double lapPercentCount = n / Laps.Count;
            int count = (int)Math.Ceiling(lapPercentCount);

            return LastNLapsOfRunAverageLap(count, false);
        } 
        #endregion
    }
}
