using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nascar.Data.Schedule
{
    [Table("Track")]
    public class Track
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None), Key()]
        public int track_id { get; set; }
        public double track_length { get; set; }
        public string track_name { get; set; }
    }
}
