namespace NascarApi.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VehicleType")]
    public partial class VehicleType
    {
        public VehicleType()
        {
            RaceVehicles = new HashSet<RaceVehicle>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int vehicle_type_id { get; set; }

        [Required]
        [StringLength(50)]
        public string vehicle_type_name { get; set; }

        [Required]
        [StringLength(3)]
        public string vehicle_manufacturer { get; set; }

        public virtual ICollection<RaceVehicle> RaceVehicles { get; set; }
    }
}
