using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nascar.Data
{
    [Table("RawFeedRecord")]
    public class RawFeedRecord
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int RawFeedRecordId { get; set; }
        public DateTime FeedTimestamp { get; set; }
        public int race_id { get; set; }
        public int run_id { get; set; }
        public string data { get; set; }
        public int lap_number { get; set; }
        public int flag_state { get; set; }
        public double elapsed_time { get; set; }
        public int RawFeedKey { get; set; }
        public byte[] rowversion { get; set; }

        public RawFeedRecord()
        {

        }

    }
}
