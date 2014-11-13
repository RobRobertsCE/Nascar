using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nascar.Data.Schedule
{
    [Table("RaceSessionView")]
    public class RaceSessionView
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None), Key()]
        public int race_session_id { get; set; }
        public int race_id { get; set; }
        public int session_id { get; set; }
        public string session_name { get; set; }
        public int track_id { get; set; }
        public string track_name { get; set; }
        public int series_id { get; set; }
        public string series_name { get; set; }
        public int sequence { get; set; }
        public DateTime start_time { get; set; }
        public DateTime end_time { get; set; }
        public bool is_scheduled { get; set; }

        [ForeignKey("race_id")]
        public virtual Race Race { get; set; }
        [ForeignKey("session_id")]
        public virtual Session Session { get; set; }
        [ForeignKey("track_id")]
        public virtual Track Track { get; set; }
        [ForeignKey("series_id")]
        public virtual Series Series { get; set; }
        public RaceSessionView()
        {
        }
    }
}
