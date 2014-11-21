using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nascar.Data
{
    [Table("RawFeedRecordView")]
    public class RawFeedRecordView
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None), Key, Column(Order = 0)]
        public int race_id { get; set; }
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None), Key, Column(Order = 1)]
        public int run_id { get; set; }
        public int series_id { get; set; }
        public int track_id { get; set; }
        public int run_type { get; set; }
        public string run_name { get; set; }
        public string run_type_name { get; set; }
        public string series_name { get; set; }
        public string track_name { get; set; }
        public DateTime date_time { get; set; }
        public int feed_count { get; set; }

        public RawFeedRecordView()
        {
        }

    }
}
