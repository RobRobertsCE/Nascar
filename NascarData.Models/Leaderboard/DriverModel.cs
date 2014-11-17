using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NascarData.Models.Leaderboard
{
    public class DriverModel
    {
        public string DriverName { get; set; }
        public int HistoricalDriverID { get; set; }
        public bool IsInChase { get; set; }
    }

     //"Driver":             {
     //           "DriverName": "Jeff Gordon",
     //           "HistoricalDriverID": 1237,
     //           "IsInChase": false
     //       }

}
