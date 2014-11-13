using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nascar.Data.Schedule
{
    [Table("RaceEvent")]
    public class RaceEvent
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity), Key()]
        public int scheduled_event_id { get; set; }
        public int race_session_id { get; set; }
        public string status { get; set; }
        public bool enabled { get; set; }
        public DateTime scheduled_event_start { get; set; }
        public DateTime scheduled_event_end { get; set; }

        [ForeignKey("race_session_id")]
        public virtual RaceSession RaceSession { get; set; }

        public RaceEvent()
        {
            scheduled_event_start = DateTime.Now;
            scheduled_event_end = DateTime.Now;
            status = "Not Saved";
        }
    }
}
