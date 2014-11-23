namespace NascarApi.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SeriesPoints")]
    public class SeriesPoints
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int series_points_id { get; set; }
        [ForeignKey("Season")]
        public int season_id { get; set; }
        [ForeignKey("Series")]
        public int series_id { get; set; }
        [ForeignKey("Race")]
        public int race_id { get; set; }
        public int finish_position { get; set; }
        public int bonus_points { get; set; }
        public string car_number { get; set; }
        public int delta_leader { get; set; }
        public int delta_next { get; set; }
        public string first_name { get; set; }
        [ForeignKey("Driver")]
        public int driver_id { get; set; }
        public bool is_in_chase { get; set; }
        public string last_name { get; set; }
        public int membership_id { get; set; }
        public int points { get; set; }
        public int points_position { get; set; }
        public int points_earned_this_race { get; set; }
        public int wins { get; set; }
        public int top_5 { get; set; }
        public int top_10 { get; set; }
        public int poles { get; set; }

        public virtual Season Season { get; set; }
        public virtual Series Series { get; set; }
        public virtual Race Race { get; set; }
        public virtual Driver Driver { get; set; }

        public SeriesPoints()
        {

        }
    }
}
