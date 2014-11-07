namespace NascarData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SeriesSchedule
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(4)]
        public string season_name { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string series_name { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int race_number { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(100)]
        public string race_name { get; set; }

        [Key]
        [Column(Order = 4)]
        public DateTime main_event_date { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(50)]
        public string track_name { get; set; }

        [Key]
        [Column(Order = 6)]
        public double track_length { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(50)]
        public string track_type_name { get; set; }
    }
}
