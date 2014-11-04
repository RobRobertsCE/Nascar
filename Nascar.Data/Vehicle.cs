using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Nascar.Models;

namespace Nascar.Data
{
    [Table("Vehicle")]
    public class Vehicle
    {
        [Key, Column(Order=0)]
        public int vehicle_id { get; set; }

        public string vehicle_number { get; set; }

        [Column(Order = 1), ForeignKey("Run")]
        public int race_id { get; set; }
        [Column(Order = 2), ForeignKey("Run")]
        public int run_id { get; set; }

        public string sponsor_name { get; set; }
        public int starting_position { get; set; }
        public string vehicle_manufacturer { get; set; }
        // update as required VVV 
        public int qualifying_status { get; set; }
        public bool is_on_track { get; set; }
        public int status { get; set; }
        
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
        public int running_position { get; set; }
        public double delta { get; set; }
        public int times_passed { get; set; }
        public int quality_passes { get; set; }

        public IList<LapsLed> laps_led { get; set; }

        public virtual IList<PitStop> pit_stops { get; set; }

        public virtual IList<VehicleRunStat> stats { get; set; }

        public virtual Run Run { get; set; }

        [ForeignKey("Driver")]
        public virtual int driver_id { get; set; }
        public virtual Driver Driver { get; set; }

        public Vehicle()
        {
            pit_stops = new List<PitStop>();
            laps_led = new List<LapsLed>();
            stats = new List<VehicleRunStat>();
        }

        public Vehicle(VehicleModel model, int race_id, int run_id, int lap_number)
            : this()
        {
            this.race_id = race_id;
            this.run_id = run_id;
            average_restart_speed = model.average_restart_speed;
            average_running_position = model.average_running_position;
            average_speed = model.average_speed;
            best_lap = model.best_lap;
            best_lap_speed = model.best_lap_speed;
            best_lap_time = model.best_lap_time;
            vehicle_manufacturer = model.vehicle_manufacturer;
            vehicle_number = model.vehicle_number;
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
            sponsor_name = model.sponsor_name;
            starting_position = model.starting_position;
            times_passed = model.times_passed;
            quality_passes = model.quality_passes;
            is_on_track = model.is_on_track;
            
            foreach (LapsLedModel lapsLedModel in model.laps_led)
            {
                laps_led.Add(new LapsLed() { start_lap = lapsLedModel.start_lap, end_lap = lapsLedModel.end_lap, vehicle_id = this.vehicle_id });
            } 
  
            driver_id = model.driver.driver_id;

            foreach (PitStopModel pitStopModel in model.pit_stops)
            {
                pit_stops.Add(new PitStop(pitStopModel) { vehicle_number = this.vehicle_number });
            }

            stats.Add(new VehicleRunStat(model, race_id, run_id, lap_number));
        }

        public void ApplyToModel(VehicleModel model)
        {
            model.vehicle_number = vehicle_number;
            model.average_restart_speed = average_restart_speed;
            model.average_running_position = average_running_position;
            model.average_speed = average_speed;
            model.best_lap = best_lap;
            model.best_lap = best_lap;
            model.best_lap_speed = best_lap_speed;
            model.best_lap_time = best_lap_time;
            model.vehicle_manufacturer = vehicle_manufacturer;
            model.vehicle_number = vehicle_number;
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
            model.sponsor_name = sponsor_name;
            model.starting_position = starting_position;
            model.times_passed = times_passed;
            model.quality_passes = quality_passes;
            model.quality_passes = quality_passes;
            model.is_on_track = is_on_track;
            foreach (LapsLed lapsLedSet in laps_led)
            {
                model.laps_led.Add(new LapsLedModel() { start_lap = lapsLedSet.start_lap, end_lap = lapsLedSet.end_lap });
            }           

            foreach (PitStop pitStop in pit_stops)
            {
                if (model.pit_stops.Any(p => p.pit_in_elapsed_time == pitStop.pit_in_elapsed_time))
                {
                    PitStopModel pitStopModel = model.pit_stops.Where(p => p.pit_in_elapsed_time == pitStop.pit_in_elapsed_time).FirstOrDefault();
                    pitStopModel.pit_in_elapsed_time = pitStop.pit_in_elapsed_time;
                    pitStopModel.pit_out_elapsed_time = pitStop.pit_out_elapsed_time;
                    pitStopModel.pit_in_lap_count = pitStop.pit_in_lap_count;
                    pitStopModel.pit_in_leader_lap = pitStop.pit_in_leader_lap;
                }
                else
                {
                    model.pit_stops.Add(new PitStopModel()
                    {
                        pit_in_elapsed_time = pitStop.pit_in_elapsed_time,
                        pit_out_elapsed_time = pitStop.pit_out_elapsed_time,
                        pit_in_lap_count = pitStop.pit_in_lap_count,
                        pit_in_leader_lap = pitStop.pit_in_leader_lap
                    });

                }
            }
        }
    }
}
