namespace NascarApi.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Run")]
    public partial class Run
    {
        public Run()
        {
            VehicleRuns = new HashSet<VehicleRun>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int race_run_id { get; set; }

        public int race_id { get; set; }

        public int run_id { get; set; }

        [Required]
        [StringLength(100)]
        public string run_name { get; set; }

        public int run_type { get; set; }

        public int round_number { get; set; }

        public DateTime start_timestamp { get; set; }

        public int duration { get; set; }

        public bool is_timed { get; set; }

        public int run_status { get; set; }

        public int? laps_in_run { get; set; }

        public int? laps_to_go { get; set; }

        public double? time_of_day { get; set; }

        public int? number_of_caution_segments { get; set; }

        public int? number_of_caution_laps { get; set; }

        public int? number_of_lead_changes { get; set; }

        public int? number_of_leaders { get; set; }

        public virtual Race Race { get; set; }

        public virtual RunType RunType { get; set; }

        public virtual ICollection<VehicleRun> VehicleRuns { get; set; }
    }
}
