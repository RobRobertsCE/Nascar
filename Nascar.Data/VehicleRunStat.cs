using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Nascar.Models;

namespace Nascar.Data
{
    [Table("VehicleRunStat")]
    public class VehicleRunStat
    {
        [Key]
        public int vehicle_stat_id { get; set; }

        public int race_id { get; set; }
        public int run_id { get; set; }
        public int lap_number { get; set; }

        public double average_restart_speed { get; set; }
        public double average_running_position { get; set; }
        public double average_speed { get; set; }
        public int best_lap { get; set; }
        public double best_lap_speed { get; set; }
        public double best_lap_time { get; set; }
        public double vehicle_elapsed_time { get; set; }
        public int fastest_laps_run { get; set; }
        public int laps_completed { get; set; }
        public double last_lap_speed { get; set; }
        public double last_lap_time { get; set; }
        public int passes_made { get; set; }
        public int passing_differential { get; set; }
        public int qualifying_status { get; set; }
        public int running_position { get; set; }
        public int status { get; set; }
        public double delta { get; set; }
        public int times_passed { get; set; }
        public int quality_passes { get; set; }
        public bool is_on_track { get; set; }

        [ForeignKey("Vehicle")]
        public int vehicle_id { get; set; }
        public virtual Vehicle Vehicle { get; set; }

        public VehicleRunStat()
        {

        }

        public VehicleRunStat(VehicleModel model, int race_id, int run_id, int lap_number)
            : this()
        {
            this.race_id = race_id;
            this.run_id = run_id;
            this.lap_number = lap_number;
            average_restart_speed = model.average_restart_speed;
            average_running_position = model.average_running_position;
            average_speed = model.average_speed;
            best_lap = model.best_lap;
            best_lap_speed = model.best_lap_speed;
            best_lap_time = model.best_lap_time;
            vehicle_elapsed_time = model.vehicle_elapsed_time;
            fastest_laps_run = model.fastest_laps_run;
            laps_completed = model.laps_completed;
            last_lap_speed = model.last_lap_speed;
            last_lap_time = model.last_lap_time;
            passes_made = model.passes_made;
            passing_differential = model.passing_differential;
            qualifying_status = model.qualifying_status;
            running_position = model.running_position;
            status = model.status;
            delta = model.delta;
            times_passed = model.times_passed;
            quality_passes = model.quality_passes;
            is_on_track = model.is_on_track;
        }

        public void ApplyToModel(VehicleModel model)
        {
            model.average_restart_speed = average_restart_speed;
            model.average_running_position = average_running_position;
            model.average_speed = average_speed;
            model.best_lap = best_lap;
            model.best_lap = best_lap;
            model.best_lap_speed = best_lap_speed;
            model.best_lap_time = best_lap_time;
            model.vehicle_elapsed_time = vehicle_elapsed_time;
            model.fastest_laps_run = fastest_laps_run;
            model.laps_completed = laps_completed;
            model.last_lap_speed = last_lap_speed;
            model.last_lap_time = last_lap_time;
            model.passes_made = passes_made;
            model.passing_differential = passing_differential;
            model.qualifying_status = qualifying_status;
            model.running_position = running_position;
            model.delta = delta;
            model.times_passed = times_passed;
            model.quality_passes = quality_passes;
            model.quality_passes = quality_passes;
            model.is_on_track = is_on_track;
        }
    }
}
