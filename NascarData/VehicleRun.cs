namespace NascarApi.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VehicleRun")]
    public partial class VehicleRun
    {
        public VehicleRun()
        {
            PitStops = new HashSet<PitStop>();
            VehicleLaps = new HashSet<VehicleLap>();
            VehicleLapsLeds = new HashSet<VehicleLapsLed>();
        }

        [Key]
        public int vehicle_run_id { get; set; }

        [ForeignKey("RaceVehicle")]
        public int vehicle_id { get; set; }

        [Index()]
        public int race_run_id { get; set; }
        
        public int driver_id { get; set; }

        public virtual Driver Driver { get; set; }

        public virtual ICollection<PitStop> PitStops { get; set; }

        public virtual Run Run { get; set; }

        public virtual RaceVehicle RaceVehicle { get; set; }

        public virtual ICollection<VehicleLap> VehicleLaps { get; set; }

        public virtual ICollection<VehicleLapsLed> VehicleLapsLeds { get; set; }
    }
}
