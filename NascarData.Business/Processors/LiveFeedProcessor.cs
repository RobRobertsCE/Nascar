namespace NascarApi.Processors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NascarApi.Data;
    using NascarApi.Models;
    using NascarApi.Models.Flag;
    using NascarApi.Models.LiveFeed;
    using Newtonsoft.Json;

    public class LiveFeedProcessor : FeedProcessor<LiveFeedModel>
    {
        delegate void processModelDelegate(LiveFeedModel model);

        #region fields
        double lastElapsed = 0;
        Race currentRace;
        Run currentRun;
        RunFlagState currentRunFlagState;
        IDictionary<string, VehicleRun> VehicleRuns;
        processModelDelegate processModelHandler;
        #endregion

        #region properties
        public override ApiFeedType FeedType
        {
            get
            {
                return ApiFeedType.LiveFeed;
            }
        }
        #endregion

        #region ctor / init
        public LiveFeedProcessor(int season_id, int series_id, int race_id)
            : base(season_id, series_id, race_id)
        {
            
        }

        protected virtual void InitializeFeedProcessor()
        {
            try
            {
                this.VehicleRuns = new Dictionary<string, VehicleRun>();

                this.processModelHandler = new processModelDelegate(this.FirstProcess);

            }
            catch (Exception ex)
            {
                this.ExceptionHandler(ex);
            }
        }
        #endregion

        #region IFeedProcessor
        public override void ProcessModel(LiveFeedModel model)
        {
            try
            {
                this.processModelHandler.Invoke(model);
            }
            catch (Exception ex)
            {
                this.ExceptionHandler(ex);
            }
            finally
            {
                this.OnProcessingComplete();
            }
        }

        protected override void BeginProcessAsync(LiveFeedModel model)
        {
            this.processModelHandler.Invoke(model);
        }
        #endregion

        #region protected internal process model methods
        protected internal void FirstProcess(LiveFeedModel model)
        {
            try
            {
                this.currentRace = GetRace(model);
                this.currentRun = GetRun(model);
                this.currentRunFlagState = GetRunFlagState(model);

                this.processModelHandler = new processModelDelegate(this.Process);
                this.processModelHandler.Invoke(model);

            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                string message = ex.Message;
                var ix = ex.InnerException;
                while (null != ix.InnerException)
                {
                    message = ix.InnerException.Message;
                    ix = ix.InnerException;
                }
                LogMessage(String.Format("DATA EXCEPTION: {0}", message));
            }
            catch (Exception ex)
            {
                this.ExceptionHandler(ex);
            }
        }
        #endregion

        #region ### PROCESS RUN DATA ###
        protected internal void Process(LiveFeedModel model)
        {
            if (model.elapsed_time == lastElapsed)
            {
                LogMessage("Duplicate feed");
                return;
            }

            lastElapsed = model.elapsed_time;

            NascarDbContext context = this.Context;

            try
            {
                foreach (VehicleModel vehicle in model.vehicles)
                {
                    var vehicleRun = GetVehicleRun(vehicle);

                    ProcessLapsLed(vehicleRun, vehicle.laps_led);

                    ProcessPitStops(vehicleRun, vehicle.pit_stops);

                    ProcessVehicleLap(vehicleRun, vehicle, model.lap_number);
                }

                UpdateCurrentRun(model, currentRun);
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        protected internal void ProcessVehicleLap(VehicleRun vehicleRun, VehicleModel vehicle, int lap_number)
        {
            if (!vehicleRun.VehicleLaps.Any(vl => vl.laps_completed == vehicle.laps_completed))
            {
                var newLap = this.Context.VehicleLaps.Create();

                newLap.average_restart_speed = vehicle.average_restart_speed;
                newLap.average_running_position = vehicle.average_running_position;
                newLap.average_speed = vehicle.average_speed;
                newLap.best_lap = vehicle.best_lap;
                newLap.best_lap_speed = vehicle.best_lap_speed;
                newLap.best_lap_time = vehicle.best_lap_time;
                newLap.delta = vehicle.delta;
                newLap.fastest_laps_run = vehicle.fastest_laps_run;
                newLap.is_on_track = vehicle.is_on_track;
                newLap.lap_number = lap_number;
                newLap.laps_completed = vehicle.laps_completed;
                newLap.last_lap_speed = vehicle.last_lap_speed;
                newLap.last_lap_time = vehicle.last_lap_time;
                newLap.passes_made = vehicle.passes_made;
                newLap.passing_differential = vehicle.passing_differential;
                newLap.qualifying_status = vehicle.qualifying_status;
                newLap.quality_passes = vehicle.quality_passes;
                newLap.running_position = vehicle.running_position;
                newLap.status = vehicle.status;
                newLap.times_passed = vehicle.times_passed;
                newLap.vehicle_elapsed_time = vehicle.vehicle_elapsed_time;
                newLap.vehicle_run_id = vehicleRun.vehicle_run_id;

                vehicleRun.VehicleLaps.Add(newLap);
                this.Context.SaveChanges();
            }

        }
        protected internal void ProcessPitStops(VehicleRun vehicleRun, IList<PitStopModel> pit_stops)
        {
            foreach (PitStopModel stop in pit_stops)
            {
                var existingStop = vehicleRun.PitStops.Where(ps => ps.pit_in_lap_count == stop.pit_in_lap_count).FirstOrDefault();

                if (null == existingStop)
                {
                    var pitStop = this.Context.PitStops.Create();

                    pitStop.pit_in_lap_count = stop.pit_in_lap_count;
                    pitStop.pit_in_elapsed_time = stop.pit_in_elapsed_time;
                    pitStop.pit_out_elapsed_time = stop.pit_out_elapsed_time;
                    pitStop.pit_in_leader_lap = stop.pit_in_leader_lap;
                    pitStop.positions_gained_lossed = stop.positions_gained_lossed;

                    vehicleRun.PitStops.Add(pitStop);
                    this.Context.SaveChanges();
                }
            }
        }
        protected internal void ProcessLapsLed(VehicleRun vehicleRun, IList<LapsLedModel> laps_led)
        {
            foreach (LapsLedModel lapsLed in laps_led)
            {
                var existingLapLed = vehicleRun.VehicleLapsLeds.Where(vll => vll.start_lap == lapsLed.start_lap).FirstOrDefault();
                if (null != existingLapLed)
                {
                    if (existingLapLed.end_lap != lapsLed.end_lap)
                    {
                        existingLapLed.end_lap = lapsLed.end_lap;
                        existingLapLed.total_laps = (lapsLed.end_lap - lapsLed.start_lap);
                        this.Context.SaveChanges();
                    }
                }
                else
                {
                    var vehicleLapsLed = this.Context.VehicleLapsLeds.Create();

                    vehicleLapsLed.start_lap = lapsLed.start_lap;
                    vehicleLapsLed.end_lap = lapsLed.end_lap;
                    vehicleLapsLed.vehicle_run_id = vehicleRun.vehicle_run_id;
                    vehicleLapsLed.total_laps = (lapsLed.end_lap - lapsLed.start_lap + 1);

                    vehicleRun.VehicleLapsLeds.Add(vehicleLapsLed);
                    this.Context.SaveChanges();
                }
            }
        }
        protected internal void UpdateVehicleRun(LiveFeedModel model)
        {

        }
        #endregion

        #region get/create data classes
        protected internal Race GetRace(LiveFeedModel model)
        {
            var race = this.Context.Races.Find(model.race_id);

            if (null == race)
                race = CreateRace(model);

            return race;
        }
        protected internal Race CreateRace(LiveFeedModel model)
        {
            var newRace = this.Context.Races.Create();

            newRace.race_id = model.race_id;
            newRace.race_name = model.run_name;
            newRace.series_id = model.series_id;
            newRace.track_id = model.track_id;
            newRace.is_points_race = true;
            newRace.season_id = GetSeasonId(model);
            newRace.race_number = model.race_id;
            newRace.main_event_date = DateTime.Now;

            this.Context.Races.Add(newRace);
            this.Context.SaveChanges();

            return newRace;
        }

        protected internal Run GetRun(LiveFeedModel model)
        {
            var run = currentRace.Runs.Where(r => r.race_id == model.race_id && r.run_id == model.run_id).FirstOrDefault();

            if (null == run)
                run = CreateRun(model);
            else if (run.laps_to_go != model.laps_to_go)
                run = UpdateCurrentRun(model, run);

            return run;
        }
        protected internal Run CreateRun(LiveFeedModel model)
        {
            var newRun = this.Context.Runs.Create();

            newRun.race_id = model.race_id;
            newRun.run_id = model.run_id;
            newRun.run_type = model.run_type;
            newRun.run_name = model.run_name;
            newRun.round_number = model.run_id;
            newRun.start_timestamp = DateTime.Now;
            newRun.duration = model.laps_in_race;
            newRun.run_status = (int)SessionStatus.Running;
            newRun.laps_in_run = model.laps_in_race;
            newRun.laps_to_go = model.laps_to_go;
            newRun.time_of_day = model.time_of_day;
            newRun.number_of_caution_segments = model.number_of_caution_segments;
            newRun.number_of_caution_laps = model.number_of_caution_laps;
            newRun.number_of_lead_changes = model.number_of_lead_changes;
            newRun.number_of_leaders = model.number_of_leaders;

            this.Context.Runs.Add(newRun);
            this.Context.SaveChanges();

            this.run_id = newRun.run_id;

            return newRun;
        }
        protected internal Run UpdateCurrentRun(LiveFeedModel model, Run run)
        {
            run.laps_in_run = model.laps_in_race;
            run.laps_to_go = model.laps_to_go;
            run.time_of_day = model.time_of_day;
            run.number_of_caution_segments = model.number_of_caution_segments;
            run.number_of_caution_laps = model.number_of_caution_laps;
            run.number_of_lead_changes = model.number_of_lead_changes;
            run.number_of_leaders = model.number_of_leaders;

            if (model.flag_state == 0)
                run.run_status = (int)SessionStatus.Scheduled;
            else if (model.flag_state == 9)
                run.run_status = (int)SessionStatus.Completed;
            else
                run.run_status = (int)SessionStatus.Running;

            if (model.flag_state != currentRunFlagState.flag_state)
            {
                currentRunFlagState = GetRunFlagState(model);
            }

            this.Context.SaveChanges();

            return run;
        }

        protected internal RunFlagState GetRunFlagState(LiveFeedModel model)
        {
            if ((null != currentRunFlagState) && currentRunFlagState.elapsed_time == model.elapsed_time)
                return currentRunFlagState;

            var flagState = currentRun.RunFlagStates.Where(r => r.race_run_id == currentRun.race_run_id && r.elapsed_time == model.elapsed_time).FirstOrDefault();

            if (null == flagState)
                flagState = CreateRunFlagState(model);

            return flagState;
        }
        protected internal RunFlagState CreateRunFlagState(LiveFeedModel model)
        {
            var newFlagState = this.Context.RunFlagStates.Create();

            newFlagState.race_run_id = currentRun.race_run_id;
            newFlagState.flag_state = model.flag_state;
            newFlagState.lap_number = model.lap_number;
            newFlagState.elapsed_time = model.elapsed_time;

            this.Context.RunFlagStates.Add(newFlagState);
            this.Context.SaveChanges();

            return newFlagState;
        }
           
        protected internal Driver GetDriver(DriverModel model)
        {
            NascarDbContext context = this.Context;
            var driver = context.Drivers.Find(model.driver_id);

            if (null == driver)
                driver = CreateDriver(model);

            return driver;

        }
        protected internal Driver CreateDriver(DriverModel model)
        {
            var newDriver = this.Context.Drivers.Create();

            newDriver.driver_id = model.driver_id;
            newDriver.full_name = model.full_name;
            newDriver.first_name = TrimDriverName(model.first_name);
            newDriver.last_name = TrimDriverName(model.last_name);
            newDriver.is_in_chase = model.is_in_chase;

            this.Context.Drivers.Add(newDriver);
            this.Context.SaveChanges();

            return newDriver;
        }

        protected internal RaceVehicle GetRaceVehicle(VehicleModel vehicle)
        {
            var raceVehicle = currentRace.RaceVehicles
                .Where(rv => rv.vehicle_number == vehicle.vehicle_number)
                .FirstOrDefault();

            if (null == raceVehicle)
                raceVehicle = CreateRaceVehicle(vehicle);

            return raceVehicle;
        }
        protected internal RaceVehicle CreateRaceVehicle(VehicleModel vehicle)
        {
            var raceVehicle = this.Context.RaceVehicles.Create();

            raceVehicle.race_id = this.race_id;
            raceVehicle.vehicle_number = vehicle.vehicle_number;
            raceVehicle.sponsor_name = String.IsNullOrEmpty(vehicle.sponsor_name) ? "-" : vehicle.sponsor_name;
            raceVehicle.vehicle_type_id = this.Context.VehicleTypes.Where(t => t.vehicle_manufacturer == vehicle.vehicle_manufacturer).FirstOrDefault().vehicle_type_id;

            this.Context.RaceVehicles.Attach(raceVehicle);
            currentRace.RaceVehicles.Add(raceVehicle);
            this.Context.SaveChanges();

            return raceVehicle;
        }

        protected internal VehicleRun GetVehicleRun(VehicleModel vehicle)
        {
            if (VehicleRuns.ContainsKey(vehicle.vehicle_number))
                return VehicleRuns[vehicle.vehicle_number];

            var raceVehicle = GetRaceVehicle(vehicle);

            var vehicleRun = raceVehicle.VehicleRuns
                .Where(r => r.race_run_id == currentRun.race_run_id)
                .FirstOrDefault();

            if (null == vehicleRun)
                vehicleRun = CreateVehicleRun(raceVehicle, vehicle.driver.driver_id);

            return vehicleRun;
        }
        protected internal VehicleRun CreateVehicleRun(RaceVehicle raceVehicle, int driver_id)
        {
            var vehicleRun = this.Context.VehicleRuns.Create();

            vehicleRun.race_run_id = currentRun.race_run_id;
            vehicleRun.vehicle_id = raceVehicle.vehicle_id;
            vehicleRun.driver_id = driver_id;

            this.Context.Runs.Attach(currentRun);
            currentRun.VehicleRuns.Add(vehicleRun);
            this.Context.SaveChanges();

            VehicleRuns.Add(raceVehicle.vehicle_number, vehicleRun);

            return vehicleRun;
        }
        #endregion

        #region helper methods
        private string TrimDriverName(string name)
        {
            return name.Replace("#", "").Replace("*", "").Replace("(i)", "").Trim();
        }

        private string GetRaceName(string run_name)
        {
            if (run_name.Contains("Practice"))
            {
                return run_name.Substring(0, run_name.IndexOf("Practice") - 1).Trim();
            }
            else if (run_name.Contains("Qualifying"))
            {
                return run_name.Substring(0, run_name.IndexOf("Qualifying") - 1).Trim();
            }
            else
            {
                return run_name;
            }
        }

        protected internal int GetSeasonId(LiveFeedModel model)
        {
            return 1;
            //return DateTime.Now.Year;
        }
        #endregion
    }
}
