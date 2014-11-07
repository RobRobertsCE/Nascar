namespace NascarData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Track")]
    public partial class Track
    {
        public Track()
        {
            Races = new HashSet<Race>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int track_id { get; set; }

        public int track_type_id { get; set; }

        public double track_length { get; set; }

        [Required]
        [StringLength(50)]
        public string track_name { get; set; }

        public virtual ICollection<Race> Races { get; set; }

        public virtual TrackType TrackType { get; set; }
    }
}
