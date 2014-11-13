using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nascar.Data.Schedule
{
    [Table("RaceView")]
    public class RaceView
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None), Key()]
        public int race_id { get; set; }
        public int track_id { get; set; }
        public string track_name { get; set; }
        public int series_id { get; set; }
        public string series_name { get; set; }
        public DateTime race_date { get; set; }

        [ForeignKey("track_id")]
        public virtual Track Track { get; set; }
        [ForeignKey("series_id")]
        public virtual Series Series { get; set; }

        public RaceView()
        {            
        }
    }
}

