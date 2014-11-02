using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nascar.ServiceScheduler.Data
{
    [Table("ScheduledSeries")]
    public class ScheduledSeries
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None), Key()]
        public int series_id { get; set; }
        public string series_name { get; set; }

        public ScheduledSeries()
        {
            series_id = -1;
        }
    }
}
