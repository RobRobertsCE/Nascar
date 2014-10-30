using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Nascar.Models;

namespace Nascar.Data
{
    [Table("Race")]
    public class Race
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None), Key()] 
        public int race_id { get; set; }
        public string race_name { get; set; }

        //public int lap_number { get; set; }
        //public double elapsed_time { get; set; }
        //public int flag_state { get; set; }
        //public int laps_in_race { get; set; }
        //public int laps_to_go { get; set; }
        ////public double time_of_day { get; set; }
        //public int run_type { get; set; }
        //public int number_of_caution_segments { get; set; }
        //public int number_of_caution_laps { get; set; }
        //public int number_of_lead_changes { get; set; }
        ////public int number_of_leaders { get; set; }

        //public IList<Vehicle> vehicles { get; set; }

        //public int run_id { get; set; }
        //public string run_name { get; set; }
        //public int series_id { get; set; }
        //public int track_id { get; set; }
        //public double track_length { get; set; }
        //public string track_name { get; set; }

        [ForeignKey("Track")]
        public int track_id { get; set; }
        public virtual Track Track { get; set; }

        [ForeignKey("Series")]
        public int series_id { get; set; }
        public virtual Series Series { get; set; }

        public virtual ICollection<Session> sessions { get; set; }

        public Race()
        {
            sessions = new List<Session>();
        }


    }
}
