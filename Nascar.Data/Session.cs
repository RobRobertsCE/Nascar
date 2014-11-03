﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Nascar.Models;

namespace Nascar.Data
{
    [Table("Session")]
    public class Session
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int session_id { get; set; }
        private int _runId = 0;
        public int run_id
        {
            get
            {
                return _runId;
            }
            set
            {
                _runId = value;
                session_id = run_id;
            }
        }
        public string session_name { get; set; }
        public int session_type { get; set; }
        public int laps_in_session { get; set; }

        public virtual IList<LiveFeed> live_feeds { get; set; }

        [ForeignKey("Race")]
        public int race_id { get; set; }
        public virtual Race Race { get; set; }

        public Session()
        {
            live_feeds = new List<LiveFeed>();
        }

        public Session(int session_id, int run_id, int race_id, string session_name, int session_type, int laps_in_session)
            : this()
        {
            this.session_id = session_id;
            this.run_id = run_id;
            this.race_id = race_id;
            this.session_name = session_name;
            this.session_type = session_type;
            this.laps_in_session = laps_in_session;
        }

        public void ApplyToModel(LiveFeedModel model)
        {
            model.race_id = race_id;
            model.run_id = run_id; //session_id
            model.run_type = session_type;
            model.run_name = session_name;
            model.laps_in_race = laps_in_session;

            //foreach (Vehicle vehicle in vehicles)
            //{
            //    if (model.vehicles.Any(v => v.vehicle_number == vehicle.vehicle_number))
            //    {
            //        VehicleModel vehicleModel = model.vehicles.Where(v => v.vehicle_number == vehicle.vehicle_number).FirstOrDefault();
            //        vehicleModel.vehicle_number = vehicle.vehicle_number;
            //        vehicleModel.average_restart_speed = vehicle.average_restart_speed;
            //        vehicleModel.average_running_position = vehicle.average_running_position;
            //        vehicleModel.average_speed = vehicle.average_speed;
            //        vehicleModel.best_lap = vehicle.best_lap;
            //        vehicleModel.best_lap = vehicle.best_lap;
            //        vehicleModel.best_lap_speed = vehicle.best_lap_speed;
            //        vehicleModel.best_lap_time = vehicle.best_lap_time;
            //        vehicleModel.vehicle_manufacturer = vehicle.vehicle_manufacturer;
            //        vehicleModel.vehicle_number = vehicle.vehicle_number;
            //        vehicleModel.vehicle_elapsed_time = vehicle.vehicle_elapsed_time;
            //        vehicleModel.fastest_laps_run = vehicle.fastest_laps_run;
            //        vehicleModel.laps_completed = vehicle.laps_completed;
            //        vehicleModel.last_lap_speed = vehicle.last_lap_speed;
            //        vehicleModel.last_lap_time = vehicle.last_lap_time;
            //        vehicleModel.passes_made = vehicle.passes_made;
            //        vehicleModel.passing_differential = vehicle.passing_differential;
            //        vehicleModel.qualifying_status = vehicle.qualifying_status;
            //        vehicleModel.running_position = vehicle.running_position;
            //        vehicleModel.delta = vehicle.delta;
            //        vehicleModel.sponsor_name = vehicle.sponsor_name;
            //        vehicleModel.starting_position = vehicle.starting_position;
            //        vehicleModel.times_passed = vehicle.times_passed;
            //        vehicleModel.quality_passes = vehicle.quality_passes;
            //        vehicleModel.quality_passes = vehicle.quality_passes;
            //        vehicleModel.is_on_track = vehicle.is_on_track;
            //        vehicleModel.laps_led = vehicle.laps_led;

            //        vehicle.Driver.ApplyToModel(vehicleModel.driver);
            //    }
            //    else
            //    {
            //        model.vehicles.Add(new VehicleModel()
            //        {
            //            vehicle_number = vehicle.vehicle_number,
            //            average_restart_speed = vehicle.average_restart_speed,
            //            average_running_position = vehicle.average_running_position,
            //            average_speed = vehicle.average_speed,
            //            best_lap = vehicle.best_lap,
            //            best_lap_speed = vehicle.best_lap_speed,
            //            best_lap_time = vehicle.best_lap_time,
            //            vehicle_manufacturer = vehicle.vehicle_manufacturer,
            //            vehicle_elapsed_time = vehicle.vehicle_elapsed_time,
            //            fastest_laps_run = vehicle.fastest_laps_run,
            //            laps_completed = vehicle.laps_completed,
            //            last_lap_speed = vehicle.last_lap_speed,
            //            last_lap_time = vehicle.last_lap_time,
            //            passes_made = vehicle.passes_made,
            //            passing_differential = vehicle.passing_differential,
            //            qualifying_status = vehicle.qualifying_status,
            //            running_position = vehicle.running_position,
            //            delta = vehicle.delta,
            //            sponsor_name = vehicle.sponsor_name,
            //            starting_position = vehicle.starting_position,
            //            times_passed = vehicle.times_passed,
            //            quality_passes = vehicle.quality_passes,
            //            is_on_track = vehicle.is_on_track,
            //            laps_led = vehicle.laps_led,
            //            driver = new DriverModel(){driver_id=vehicle.driver_id}
            //        });

            //    }
            //}
        }
    }
}
