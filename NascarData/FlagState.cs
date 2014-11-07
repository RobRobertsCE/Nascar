namespace NascarData
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
            RunLaps = new HashSet<RunLap>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int flag_state_id { get; set; }

        [Required]
        [StringLength(25)]
        public string flag_state_name { get; set; }

        public virtual ICollection<RunLap> RunLaps { get; set; }
    }
}
