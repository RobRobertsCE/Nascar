namespace NascarData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RaceVehicle")]
    public partial class RaceVehicle
    {
        public RaceVehicle()
        {
            TeamVehicles = new HashSet<TeamVehicle>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int vehicle_id { get; set; }

        public int race_id { get; set; }

        public int vehicle_number { get; set; }

        [Required]
        [StringLength(100)]
        public string sponsor_name { get; set; }

        public int vehicle_type_id { get; set; }

        public virtual Race Race { get; set; }

        public virtual VehicleType VehicleType { get; set; }

        public virtual ICollection<TeamVehicle> TeamVehicles { get; set; }
    }
}
