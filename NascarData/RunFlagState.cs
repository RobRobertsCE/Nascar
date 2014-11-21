namespace NascarApi.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RunFlagState")]
    public class RunFlagState
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int run_flag_state_id { get; set; }
        public int race_run_id { get; set; }
        public int lap_number { get; set; }
        [ForeignKey("FlagState")]
        public int flag_state { get; set; }
        public double elapsed_time { get; set; }
        public string comment { get; set; }
        public string beneficiary { get; set; }
        public double time_of_day { get; set; }

        public virtual FlagState FlagState { get; set; }
    }
}
