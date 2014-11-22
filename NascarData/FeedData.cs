namespace NascarApi.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FeedData")]
    public partial class FeedData
    {
        public FeedData()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int feed_data_id { get; set; }

        public int race_id { get; set; }

        public int feed_type { get; set; }

        public string data { get; set; }

        public DateTime created { get; set; }
    }
}

