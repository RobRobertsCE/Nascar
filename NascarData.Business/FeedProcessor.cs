using System;
using System.Collections.Generic;
using System.Linq;
using NascarApi.Data;
using NascarApi.Models.Flag;
using NascarApi.Models.LiveFeed;
using Newtonsoft.Json;

namespace NascarApi.Business
{
    public class FeedProcessor : IFeedProcessor
    {
        delegate void processModelDelegate(LiveFeedModel model);

        #region fields
        double lastElapsed = 0;
        NascarDbContext _ctx = null;
        Race currentRace;
        Run currentRun;
        RunFlagState currentRunFlagState;
        IDictionary<string, VehicleRun> VehicleRuns;
        processModelDelegate processModelHandler;
        #endregion

        #region properties
        int runId;
        public int run_id
        {
            get { return runId; }
            private set { runId = value; }
        }

        int raceId;
        public int race_id
        {
            get { return raceId; }
            private set { raceId = value; }
        }

        int seriesId;
        public int series_id
        {
            get { return seriesId; }
            private set { seriesId = value; }
        }

        int seasonId;
        public int season_id
        {
            get { return seasonId; }
            private set { seasonId = value; }
        }

        string messageHeader = String.Empty;
        protected virtual string MessageHeader
        {
            get
            {
                if (String.IsNullOrEmpty(messageHeader))
                    messageHeader = String.Format("SeasonId:{0, -5}, SeriesId:{1, -2}, RaceId:{2, -5}, RunId{3, -3} {4}", this.season_id.ToString(), this.series_id.ToString(), this.race_id.ToString(), this.run_id.ToString(), DateTime.Now.ToString());

                return messageHeader;
            }
        }
        #endregion

        #region ctor / init
        public FeedProcessor()
        {
            this.InitializeFeedProcessor();
        }
        public FeedProcessor(int season_id, int series_id, int race_id)
        {
            this.season_id = season_id;
            this.series_id = series_id;
            this.race_id = race_id;

            this.InitializeFeedProcessor();
        }

        protected internal void InitializeFeedProcessor()
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

        #region common
        protected virtual void ExceptionHandler(Exception ex)
        {
            LogMessage(ex.ToString());
        }

        protected virtual void LogMessage(string message)
        {
            Console.WriteLine(String.Format("{0}: {1}", MessageHeader, message));
        }

        #endregion

        #region IFeedProcessor
        public void processFeedData(string feedData)
        {
            try
            {
                this.processFeedModel(this.GetFeedModel(feedData));
            }
            catch (Exception ex)
            {
                this.ExceptionHandler(ex);
            }
        }
        public void processFeedModel(LiveFeedModel model)
        {
            try
            {
                this.processModelHandler.Invoke(model);
            }
            catch (Exception ex)
            {
                this.ExceptionHandler(ex);
            }
        }

        public void processLiveFlag(string liveFlagData)
        {
            try
            {
                processLiveFlagModel(GetFlagModel(liveFlagData));
            }
            catch (Exception ex)
            {
                this.ExceptionHandler(ex);
            }
        }
        public void processLiveFlagModel(FlagModel model)
        {
            currentRunFlagState = UpdateRunFlagState(model);
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

            NascarDbContext context = GetContext();

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
                var newLap = GetContext().VehicleLaps.Create();

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
                GetContext().SaveChanges();
            }

        }
        protected internal void ProcessPitStops(VehicleRun vehicleRun, IList<PitStopModel> pit_stops)
        {
            foreach (PitStopModel stop in pit_stops)
            {
                var existingStop = vehicleRun.PitStops.Where(ps => ps.pit_in_lap_count == stop.pit_in_lap_count).FirstOrDefault();

                if (null == existingStop)
                {
                    var pitStop = GetContext().PitStops.Create();

                    pitStop.pit_in_lap_count = stop.pit_in_lap_count;
                    pitStop.pit_in_elapsed_time = stop.pit_in_elapsed_time;
                    pitStop.pit_out_elapsed_time = stop.pit_out_elapsed_time;
                    pitStop.pit_in_leader_lap = stop.pit_in_leader_lap;
                    pitStop.positions_gained_lossed = stop.positions_gained_lossed;

                    vehicleRun.PitStops.Add(pitStop);
                    GetContext().SaveChanges();
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
                        GetContext().SaveChanges();
                    }
                }
                else
                {
                    var vehicleLapsLed = GetContext().VehicleLapsLeds.Create();

                    vehicleLapsLed.start_lap = lapsLed.start_lap;
                    vehicleLapsLed.end_lap = lapsLed.end_lap;
                    vehicleLapsLed.vehicle_run_id = vehicleRun.vehicle_run_id;
                    vehicleLapsLed.total_laps = (lapsLed.end_lap - lapsLed.start_lap + 1);

                    vehicleRun.VehicleLapsLeds.Add(vehicleLapsLed);
                    GetContext().SaveChanges();
                }
            }
        }
        protected internal void UpdateVehicleRun(LiveFeedModel model)
        {

        }
        #endregion

        #region get model methods
        protected internal LiveFeedModel GetFeedModel(string feedData)
        {
            return JsonConvert.DeserializeObject<LiveFeedModel>(feedData);
        }
        protected internal FlagModel GetFlagModel(string flagFeedData)
        {
            return JsonConvert.DeserializeObject<FlagModel>(flagFeedData);
        }
        #endregion

        #region get/create data classes
        protected internal Race GetRace(LiveFeedModel model)
        {
            var race = GetContext().Races.Find(model.race_id);

            if (null == race)
                race = CreateRace(model);

            return race;
        }
        protected internal Race CreateRace(LiveFeedModel model)
        {
            var newRace = GetContext().Races.Create();

            newRace.race_id = model.race_id;
            newRace.race_name = model.run_name;
            newRace.series_id = model.series_id;
            newRace.track_id = model.track_id;
            newRace.is_points_race = true;
            newRace.season_id = GetSeasonId(model);
            newRace.race_number = model.race_id;
            newRace.main_event_date = DateTime.Now;

            GetContext().Races.Add(newRace);
            GetContext().SaveChanges();

            return newRace;
        }

        protected internal Run FindRun(int race_id, int run_id)
        {
            return currentRace.Runs.Where(r => r.race_id == race_id && r.run_id == run_id).FirstOrDefault();
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
            var newRun = GetContext().Runs.Create();

            newRun.race_id = model.race_id;
            newRun.run_id = model.run_id;
            newRun.run_type = model.run_type;
            newRun.run_name = model.run_name;
            newRun.round_number = model.run_id;
            newRun.start_timestamp = DateTime.Now;
            newRun.duration = model.laps_in_race;
            newRun.run_status = (int)RunStatus.Running;
            newRun.laps_in_run = model.laps_in_race;
            newRun.laps_to_go = model.laps_to_go;
            newRun.time_of_day = model.time_of_day;
            newRun.number_of_caution_segments = model.number_of_caution_segments;
            newRun.number_of_caution_laps = model.number_of_caution_laps;
            newRun.number_of_lead_changes = model.number_of_lead_changes;
            newRun.number_of_leaders = model.number_of_leaders;

            GetContext().Runs.Add(newRun);
            GetContext().SaveChanges();

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
                run.run_status = (int)RunStatus.Scheduled;
            else if (model.flag_state == 9)
                run.run_status = (int)RunStatus.Completed;
            else
                run.run_status = (int)RunStatus.Running;

            if (model.flag_state != currentRunFlagState.flag_state)
            {
                currentRunFlagState = GetRunFlagState(model);
            }

            GetContext().SaveChanges();

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
            var newFlagState = GetContext().RunFlagStates.Create();

            newFlagState.race_run_id = currentRun.race_run_id;
            newFlagState.flag_state = model.flag_state;
            newFlagState.lap_number = model.lap_number;
            newFlagState.elapsed_time = model.elapsed_time;

            GetContext().RunFlagStates.Add(newFlagState);
            GetContext().SaveChanges();

            return newFlagState;
        }

        /// <summary>
        /// TO BE USED BY LIVE_FLAG FEED. DOES NOT UPDATE currentRunFlagState property.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        protected internal RunFlagState UpdateRunFlagState(FlagModel model)
        {
            if (null == currentRun)
            {
                currentRun = FindRun(this.race_id, this.run_id);
                if (null == currentRun) return null;
            }

            RunFlagState flagState = GetContext().RunFlagStates.Where(s => s.race_run_id == currentRun.race_run_id && s.elapsed_time == model.elapsed_time).FirstOrDefault();

            if (null == flagState)
            {
                flagState = GetContext().RunFlagStates.Create();

                flagState.race_run_id = currentRun.race_run_id;
                flagState.flag_state = model.flag_state;
                flagState.lap_number = model.lap_number;
                flagState.elapsed_time = model.elapsed_time;
                flagState.comment = model.comment;
                flagState.beneficiary = model.beneficiary;
                flagState.time_of_day = model.time_of_day;

                GetContext().RunFlagStates.Attach(flagState);
                currentRun.RunFlagStates.Add(flagState);
                GetContext().SaveChanges();
            }
            else if (flagState.comment != model.comment || flagState.beneficiary != model.beneficiary)
            {
                flagState.comment = model.comment;
                flagState.beneficiary = model.beneficiary;
                GetContext().SaveChanges();
            }

            return flagState;
        }

        protected internal Driver GetDriver(DriverModel model)
        {
            NascarDbContext context = GetContext();
            var driver = context.Drivers.Find(model.driver_id);

            if (null == driver)
                driver = CreateDriver(model);

            return driver;

        }
        protected internal Driver CreateDriver(DriverModel model)
        {
            var newDriver = GetContext().Drivers.Create();

            newDriver.driver_id = model.driver_id;
            newDriver.full_name = model.full_name;
            newDriver.first_name = TrimDriverName(model.first_name);
            newDriver.last_name = TrimDriverName(model.last_name);
            newDriver.is_in_chase = model.is_in_chase;

            GetContext().Drivers.Add(newDriver);
            GetContext().SaveChanges();

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
            var raceVehicle = GetContext().RaceVehicles.Create();

            raceVehicle.race_id = this.race_id;
            raceVehicle.vehicle_number = vehicle.vehicle_number;
            raceVehicle.sponsor_name = String.IsNullOrEmpty(vehicle.sponsor_name) ? "-" : vehicle.sponsor_name;
            raceVehicle.vehicle_type_id = GetContext().VehicleTypes.Where(t => t.vehicle_manufacturer == vehicle.vehicle_manufacturer).FirstOrDefault().vehicle_type_id;

            GetContext().RaceVehicles.Attach(raceVehicle);
            currentRace.RaceVehicles.Add(raceVehicle);
            GetContext().SaveChanges();

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
            var vehicleRun = GetContext().VehicleRuns.Create();

            vehicleRun.race_run_id = currentRun.race_run_id;
            vehicleRun.vehicle_id = raceVehicle.vehicle_id;
            vehicleRun.driver_id = driver_id;

            GetContext().Runs.Attach(currentRun);
            currentRun.VehicleRuns.Add(vehicleRun);
            GetContext().SaveChanges();

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

        #region get context
        NascarDbContext GetContext()
        {
            if (null == _ctx)
                _ctx = new NascarDbContext();

            return _ctx;
        }
        #endregion
    }
}
