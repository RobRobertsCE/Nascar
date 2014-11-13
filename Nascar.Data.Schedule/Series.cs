using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nascar.Data.Schedule
{
    [Table("Series")]
    public class Series
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None), Key()]
        public int series_id { get; set; }
        public string series_name { get; set; }

        public Series()
        {
            series_id = -1;
        }
    }
}
