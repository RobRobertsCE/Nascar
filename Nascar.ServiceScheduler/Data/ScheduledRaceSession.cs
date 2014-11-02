using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nascar.ServiceScheduler.Data
{
    [Table("ScheduledRaceSession")]
    public class ScheduledRaceSession
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity), Key()]
        public int race_session_id { get; set; }
        public int race_id { get; set; }
        public int session_id { get; set; }
        public int sequence { get; set; }
        public DateTime start_time { get; set; }
        public DateTime end_time { get; set; }

        [ForeignKey("race_id")]
        public virtual ScheduledRace Race { get; set; }
        [ForeignKey("session_id")]
        public virtual ScheduledSession Session { get; set; }

        public ScheduledRaceSession()
        {
            start_time = DateTime.Now;
            end_time = DateTime.Now;
        }
    }
}
