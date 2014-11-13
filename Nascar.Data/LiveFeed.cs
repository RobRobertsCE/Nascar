using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Nascar.Api.Models;

namespace Nascar.Data
{
    [Table("LiveFeed")]
    public class LiveFeed
    {
        [Key, Column(Order = 0)]
        public int live_feed_id { get; set; }
        [Column(Order=1), ForeignKey("Run")]
        public int race_id { get; set; }
        [Column(Order = 2), ForeignKey("Run")]
        public int run_id { get; set; }
        public double elapsed_time { get; set; }
        public int lap_number { get; set; }
        public int flag_state { get; set; }
        public int laps_to_go { get; set; }
        public double time_of_day { get; set; }
        public int number_of_caution_segments { get; set; }
        public int number_of_caution_laps { get; set; }
        public int number_of_lead_changes { get; set; }
        public int number_of_leaders { get; set; }

        public virtual Run Run { get; set; }

        public LiveFeed()
        {
           
        }

        public LiveFeed(LiveFeedModel model)
            : this()
        {
            race_id = model.race_id;
            run_id = model.run_id;
            elapsed_time = model.elapsed_time;
            lap_number = model.lap_number;
            flag_state = model.flag_state;
            laps_to_go = model.laps_to_go;
            time_of_day = model.time_of_day;
            number_of_caution_segments = model.number_of_caution_segments;
            number_of_caution_laps = model.number_of_caution_laps;
            number_of_lead_changes = model.number_of_lead_changes;
            number_of_leaders = model.number_of_leaders;
        }
    }
}
