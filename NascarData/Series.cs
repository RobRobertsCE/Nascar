namespace NascarData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Series
    {
        public Series()
        {
            Races = new HashSet<Race>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int series_id { get; set; }

        [Required]
        [StringLength(50)]
        public string series_name { get; set; }

        public virtual ICollection<Race> Races { get; set; }
    }
}
