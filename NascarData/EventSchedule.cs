namespace NascarApi.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EventSchedule")]
    public partial class EventSchedule
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int race_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string race_name { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int run_id { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string run_name { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string run_type_name { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int round_number { get; set; }

        [Key]
        [Column(Order = 6)]
        public DateTime start_timestamp { get; set; }
    }
}
