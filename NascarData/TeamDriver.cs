namespace NascarApi.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TeamDriver
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string team_name { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string series_name { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string full_name { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(100)]
        public string sponsor_name { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string vehicle_type_name { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int vehicle_number { get; set; }
    }
}
