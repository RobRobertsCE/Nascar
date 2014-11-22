namespace NascarApi.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QualifyingResult")]
    public class QualifyingResult
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int qualifying_result_id { get; set; }
        [ForeignKey("Season")]
        public int seasion_id { get; set; }
        [ForeignKey("Series")]
        public int series_id { get; set; }
        [ForeignKey("Race")]
        public int race_id { get; set; }
        public int run_id { get; set; }
        [ForeignKey("Driver")]
        public int driver_id { get; set; }
        public int qualifying_round { get; set; }
        public int position { get; set; }
        public string vehicle_number { get; set; }
        public string full_name { get; set; }
        public int laps_completed { get; set; }
        public int best_lap { get; set; }
        public double best_lap_time { get; set; }
        public double best_lap_speed { get; set; }
        public string comment { get; set; }
        public bool is_on_track { get; set; }
        public bool is_current_round { get; set; }
        public int time_limit { get; set; }
        public double last_lap_time { get; set; }

        public virtual Season season { get; set; }
        public virtual Series series { get; set; }
        public virtual Race race { get; set; }
        public virtual Driver driver { get; set; }
    }
}
