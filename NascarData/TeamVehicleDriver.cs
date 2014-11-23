namespace NascarApi.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TeamVehicleDriver")]
    public class TeamVehicleDriver
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int team_vehicle_driver_id { get; set; }
        [ForeignKey("TeamVehicle")]
        public int team_vehicle_id { get; set; }
        [ForeignKey("Driver")]
        public int driver_id { get; set; }

        public virtual Driver Driver { get; set; }
        public virtual TeamVehicle TeamVehicle { get; set; }
    }
}
