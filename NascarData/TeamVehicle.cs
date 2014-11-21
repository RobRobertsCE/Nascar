namespace NascarApi.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TeamVehicle")]
    public partial class TeamVehicle
    {
        [Key]
        public int team_vehicle_id { get; set; }

        public int vehicle_id { get; set; }

        public int team_id { get; set; }

        public virtual RaceVehicle RaceVehicle { get; set; }

        public virtual Team Team { get; set; }
    }
}
