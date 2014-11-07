namespace NascarData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VehicleLapsLed")]
    public partial class VehicleLapsLed
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int vehicle_laps_led_id { get; set; }

        public int vehicle_run_id { get; set; }

        public int start_lap { get; set; }

        public int end_lap { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int? total_laps { get; set; }

        public virtual VehicleRun VehicleRun { get; set; }
    }
}
