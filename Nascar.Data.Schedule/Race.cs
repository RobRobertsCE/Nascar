using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nascar.Data.Schedule
{
    [Table("Race")]
    public class Race
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None), Key()]
        public int race_id { get; set; }
        public int track_id { get; set; }
        public int series_id { get; set; }
        public int sequence { get; set; }
        public DateTime race_date { get; set; }

        [ForeignKey("track_id")]
        public virtual Track Track { get; set; }
        [ForeignKey("series_id")]
        public virtual Series Series { get; set; }

        public Race()
        {
            race_date = DateTime.Now;
        }

    }
}
