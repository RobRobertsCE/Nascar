namespace NascarApi.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VehicleLap")]
    public partial class VehicleLap
    {
        [Key]
        public int vehicle_lap_id { get; set; }

        [Index("IX_RunLap",1)]
        public int vehicle_run_id { get; set; }

         [Index("IX_RunLap", 2, IsUnique=true)]
        public int lap_number { get; set; }

        public double average_restart_speed { get; set; }

        public double average_running_position { get; set; }

        public double average_speed { get; set; }

        public int best_lap { get; set; }

        public double best_lap_speed { get; set; }

        public double best_lap_time { get; set; }

        public double vehicle_elapsed_time { get; set; }

        public int fastest_laps_run { get; set; }

        [Index()]
        public int laps_completed { get; set; }

        public double last_lap_speed { get; set; }

        public double last_lap_time { get; set; }

        public int passes_made { get; set; }

        public int passing_differential { get; set; }

        public int qualifying_status { get; set; }

        public int running_position { get; set; }

        public int status { get; set; }

        public double delta { get; set; }

        public int times_passed { get; set; }

        public int quality_passes { get; set; }

        public bool is_on_track { get; set; }

        public virtual VehicleRun VehicleRun { get; set; }
    }
}
