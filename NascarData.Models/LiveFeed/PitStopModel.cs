namespace NascarData.Models.LiveFeed
{
    public class PitStopModel
    {
        public string vehicle_number { get; set; }
        public int positions_gained_lossed { get; set; }
        public double pit_in_elapsed_time { get; set; }
        public int pit_in_lap_count { get; set; }
        public int pit_in_leader_lap { get; set; }
        public double pit_out_elapsed_time { get; set; }
    }
}
