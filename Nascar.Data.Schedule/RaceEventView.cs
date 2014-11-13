using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nascar.Data.Schedule
{
    [Table("RaceEventView")]
    public class RaceEventView
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None), Key()]
        public int scheduled_event_id { get; set; }
        public int race_session_id { get; set; }
        public string status { get; set; }
        public bool enabled { get; set; }
        public DateTime scheduled_event_start { get; set; }
        public DateTime scheduled_event_end { get; set; }
        public int race_id { get; set; }
        public string session_name { get; set; }
        public string track_name { get; set; }
        public string series_name { get; set; }
        public int sequence { get; set; }

        [ForeignKey("race_session_id")]
        public virtual RaceSession RaceSession { get; set; }

        public RaceEventView()
        {
           
        }
    }
}
