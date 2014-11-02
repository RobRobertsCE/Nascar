using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nascar.Data.Schedule
{
    [Table("ScheduledEvent")]
    public class ScheduledEvent
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity), Key()]
        public int scheduled_event_id { get; set; }
        public int track_id { get; set; }
        public string track_name { get; set; }
        public int run_id { get; set; }
        public string run_name { get; set; }
        public int series_id { get; set; }
        public int race_id { get; set; }
        public int session_id { get; set; }
        public string status { get; set; }
        public bool enabled { get; set; }
        public DateTime scheduled_event_start { get; set; }
        public DateTime scheduled_event_end { get; set; }


        public ScheduledEvent()
        {
            scheduled_event_start = DateTime.Now;
            scheduled_event_end = DateTime.Now;
            status = "Not Saved";
        }
    }
}
