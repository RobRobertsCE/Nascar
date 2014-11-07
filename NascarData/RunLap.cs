namespace NascarData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RunLap
    {
        [Key]
        public int run_laps_id { get; set; }

        public int race_id { get; set; }

        public int run_id { get; set; }

        public int lap_number { get; set; }

        public int flag_state_id { get; set; }

        public double elapsed_time { get; set; }

        public double time_of_day { get; set; }

        public virtual FlagState FlagState { get; set; }

        public virtual Run Run { get; set; }
    }
}
