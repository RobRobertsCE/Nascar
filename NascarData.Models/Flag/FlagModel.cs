using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NascarApi.Models.Flag
{
    public class FlagModel : IApiModel
    {
        public int lap_number { get; set; }
        public int flag_state { get; set; }
        public double elapsed_time { get; set; }
        public string comment { get; set; }
        public string beneficiary { get; set; }
        public double time_of_day { get; set; }
    }
}
