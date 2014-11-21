namespace NascarApi.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FlagState")]
    public partial class FlagState
    {
        public FlagState()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int flag_state { get; set; }

        [Required]
        [StringLength(25)]
        public string flag_state_name { get; set; }
    }
}
