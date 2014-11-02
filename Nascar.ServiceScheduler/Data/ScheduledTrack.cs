using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nascar.ServiceScheduler.Data
{
    [Table("ScheduledTrack")]
    public class ScheduledTrack
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None), Key()]
        public int track_id { get; set; }
        public string track_name { get; set; }
    }
}
