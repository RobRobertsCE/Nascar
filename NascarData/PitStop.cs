namespace NascarData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PitStop")]
    public partial class PitStop
    {
        [Key]
        public int pit_stop_id { get; set; }

        public int vehicle_run_id { get; set; }

        public int pit_in_lap_count { get; set; }

        public int positions_gained_lost { get; set; }

        public double pit_in_elapsed_time { get; set; }

        public double pit_out_elapsed_time { get; set; }

        public int pit_in_leader_lap { get; set; }

        public virtual VehicleRun VehicleRun { get; set; }
    }
}
