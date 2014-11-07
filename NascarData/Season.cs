namespace NascarData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Season")]
    public partial class Season
    {
        public Season()
        {
            Races = new HashSet<Race>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int season_id { get; set; }

        [Required]
        [StringLength(4)]
        public string season_name { get; set; }

        public virtual ICollection<Race> Races { get; set; }
    }
}
