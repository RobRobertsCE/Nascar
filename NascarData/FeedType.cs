namespace NascarApi.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FeedType")]
    public partial class FeedType
    {
        public FeedType()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int feed_type { get; set; }

        public string feed_type_name { get; set; }

        public string feed_url_template { get; set; }
    }
}

