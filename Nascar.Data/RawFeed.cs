using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nascar.Data
{
    [Table("RawFeed")]
    public class RawFeed
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int RawFeedKey { get; set; }
        public DateTime Timestamp { get; set; }
        public string RawFeedData { get; set; }

        public RawFeed()
        {
            Timestamp = DateTime.Now;
        }

        public RawFeed(string data)
        {
            Timestamp = DateTime.Now;
            RawFeedData = data;
        }
    }
}
