using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nascar.WinApp.Views
{
    public class LapTimeData
    {
        #region properties
        public double LapTime { get; set; }
        public double LapNumber { get; set; }
        public double LeaderDelta { get; set; }
        public double PositionDelta { get; set; }
        public bool IsOnTrack { get; set; }
        public FlagState FlagState { get; set; } 
        #endregion
    }
}
