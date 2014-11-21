namespace NascarApi.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TrackType")]
    public partial class TrackType
    {
        public TrackType()
        {
            Tracks = new HashSet<Track>();
        }

        [Key]
        public int track_type_id { get; set; }

        [Required]
        [StringLength(50)]
        public string track_type_name { get; set; }

        public virtual ICollection<Track> Tracks { get; set; }
    }
}
