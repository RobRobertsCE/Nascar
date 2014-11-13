using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nascar.Data.Schedule
{
    [Table("RaceSession")]
    public class RaceSession
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity), Key()]
        public int race_session_id { get; set; }
        public int race_id { get; set; }
        public int session_id { get; set; }
        public int sequence { get; set; }
        public DateTime start_time { get; set; }
        public DateTime end_time { get; set; }

        [ForeignKey("race_id")]
        public virtual Race Race { get; set; }
        [ForeignKey("session_id")]
        public virtual Session Session { get; set; }

        public RaceSession()
        {
            start_time = DateTime.Now;
            end_time = DateTime.Now;
        }
    }
}
