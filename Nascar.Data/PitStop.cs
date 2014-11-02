using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Nascar.Models;

namespace Nascar.Data
{
    [Table("PitStop")]
    public class PitStop
    {
        [Key()]
        public int pit_stop_id { get; set; }
        public int pit_in_lap_count { get; set; }
        public string vehicle_number { get; set; }
        public int positions_gained_lossed { get; set; }
        public double pit_in_elapsed_time { get; set; }
        public int pit_in_leader_lap { get; set; }
        public double pit_out_elapsed_time { get; set; }

        [ForeignKey("Vehicle")]
        public int vehicle_id { get; set;  }
        public virtual Vehicle Vehicle { get; set; }
        
        public PitStop()
        {

        }

        public PitStop(PitStopModel model)
            :this()
        {
            vehicle_number = model.vehicle_number;
            pit_in_lap_count = model.pit_in_lap_count;

            positions_gained_lossed = model.positions_gained_lossed;
            pit_in_elapsed_time = model.pit_in_elapsed_time;
            pit_in_leader_lap = model.pit_in_leader_lap;
            pit_out_elapsed_time = model.pit_out_elapsed_time;
        }

        public void ApplyToModel(PitStopModel model)
        {
            model.vehicle_number = vehicle_number;
            model.pit_in_lap_count = pit_in_lap_count;

            model.positions_gained_lossed = positions_gained_lossed;
            model.pit_in_elapsed_time = pit_in_elapsed_time;
            model.pit_in_leader_lap = pit_in_leader_lap;
            model.pit_out_elapsed_time = pit_out_elapsed_time;
        }
    }
}
