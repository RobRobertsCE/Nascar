using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NascarApi.Models.Leaderboard
{
    public class LapsLedModel
    {
        public string CarNo { get; set; }
        public int FromLap { get; set; }
        public int ToLap { get; set; }
        public int TotalLaps { get; set; }
    }

    //"LapsLed":             [
    //                            {
    //                "CarNo": "24",
    //                "FromLap": 1,
    //                "ToLap": 12,
    //                "TotalLaps": 12
    //            },
    //                            {
    //                "CarNo": "24",
    //                "FromLap": 26,
    //                "ToLap": 28,
    //                "TotalLaps": 3
    //            }
}
