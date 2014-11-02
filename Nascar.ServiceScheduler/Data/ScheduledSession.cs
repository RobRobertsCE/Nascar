using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nascar.ServiceScheduler.Data
{
    [Table("ScheduledSession")]
    public class ScheduledSession
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None), Key()]
        public int session_id { get; set; }
        public string session_name { get; set; }
    }
}
