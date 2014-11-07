namespace NascarData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Driver")]
    public partial class Driver
    {
        public Driver()
        {
            VehicleRuns = new HashSet<VehicleRun>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int driver_id { get; set; }

        [Required]
        [StringLength(50)]
        public string full_name { get; set; }

        [Required]
        [StringLength(50)]
        public string first_name { get; set; }

        [Required]
        [StringLength(50)]
        public string last_name { get; set; }

        public bool is_in_chase { get; set; }

        public virtual ICollection<VehicleRun> VehicleRuns { get; set; }
    }
}
