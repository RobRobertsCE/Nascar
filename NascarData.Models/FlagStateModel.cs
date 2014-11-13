using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NascarData.Models
{
    public class FlagStateModel
    {
        // {"lap_number":0,"flag_state":8,"elapsed_time":0.0,"comment":"","beneficiary":"","time_of_day":0.0}
        public int lap_number { get; set; }
        public int flag_state { get; set; }
        public double elapsed_time { get; set; }
        public string comment { get; set; }
        public string beneficiary { get; set; }
        public double time_of_day { get; set; }
    }
}
