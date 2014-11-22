namespace NascarApi.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Race")]
    public partial class Race
    {
        public Race()
        {
            Runs = new HashSet<Run>();
            RaceVehicles = new HashSet<RaceVehicle>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int race_id { get; set; }

        [Required]
        [StringLength(100)]
        public string race_name { get; set; }

        [ForeignKey("Track")]
        public int track_id { get; set; }
        
        [ForeignKey("Series")]
        public int series_id { get; set; }

        public int race_number { get; set; }

        public bool is_points_race { get; set; }

        public DateTime main_event_date { get; set; }
        
        [ForeignKey("Season")]
        public int season_id { get; set; }

        public virtual Series Series { get; set; }

        public virtual Track Track { get; set; }

        public virtual Season Season { get; set; }

        public virtual ICollection<Run> Runs { get; set; }

        public virtual ICollection<RaceVehicle> RaceVehicles { get; set; }
    }
}
