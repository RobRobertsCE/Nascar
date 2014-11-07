namespace NascarData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LapStatusByRaceRun")]
    public partial class LapStatusByRaceRun
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string run_name { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string run_type_name { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int race_id { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int run_id { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int lap_number { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(25)]
        public string flag_state_name { get; set; }
    }
}
