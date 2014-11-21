namespace NascarApi.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RunType")]
    public partial class RunType
    {
        public RunType()
        {
            Runs = new HashSet<Run>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int run_type { get; set; }

        [Required]
        [StringLength(50)]
        public string run_type_name { get; set; }

        public virtual ICollection<Run> Runs { get; set; }
    }
}
