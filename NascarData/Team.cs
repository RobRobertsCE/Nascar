namespace NascarData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Team")]
    public partial class Team
    {
        public Team()
        {
            TeamVehicles = new HashSet<TeamVehicle>();
        }

        [Key]
        public int team_id { get; set; }

        [Required]
        [StringLength(50)]
        public string team_name { get; set; }

        public virtual ICollection<TeamVehicle> TeamVehicles { get; set; }
    }
}
