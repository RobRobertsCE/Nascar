using System;
using System.Diagnostics;
using System.Linq;
using Newtonsoft.Json;
using NascarApi.Data;
using NascarApi.Models.LiveFeed;
using System.Collections.Generic;

namespace NascarApi.Business
{
    public class FeedProcessor : IFeedProcessor
    {

        delegate void processModelDelegate(LiveFeedModel model);

        #region fields
        NascarDbContext _ctx = null;
        LiveFeedModel lastModel;
        Race currentRace;
        Run currentRun;
        processModelDelegate processModelHandler;
        #endregion

        #region properties
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
        #endregion

        #region ctor / init
        public FeedProcessor()
        {
            this.InitializeFeedProcessor();
        }
        public FeedProcessor(int series_id, int race_id)
        {
            this.series_id = series_id;
            this.race_id = race_id;

            this.InitializeFeedProcessor();
        }

        protected internal void InitializeFeedProcessor()
        {
            try
            {
                processModelHandler = new processModelDelegate(this.processFirstModel);

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
            Console.WriteLine(String.Format("{0}: {1}",DateTime.Now.ToString(), message));
        }
        #endregion

        #region public process feed methods
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
        #endregion

        #region protected internal process model methods
        protected internal void processFirstModel(LiveFeedModel model)
        {
            try
            {
                Stopwatch firstModel = new Stopwatch();
                firstModel.Start();
                currentRace = GetRace(model);
                currentRun = GetRun(model);

                this.processModelHandler = new processModelDelegate(this.processModel);

                this.processModelHandler.Invoke(model);
                firstModel.Stop();
                Console.WriteLine("FirstModel: {0} ms", firstModel.ElapsedMilliseconds.ToString());
            }
            catch (Exception ex)
            {
                this.ExceptionHandler(ex);
            }
        }

        protected internal void processModel(LiveFeedModel model)
        {

            lastModel = model;
            processRunData(model);
        }
        #endregion
        long vCnt = 0;
        double vTot = 0.0;
        double lastElapsed = 0;

        long vehicletotaltime = 0;
        long vehicleruntotaltime = 0;
        long pitstoptotaltime = 0;
        long lapsledtotaltime = 0;
        long vehiclelapstotaltime = 0;
        int vehiclecount = 0;
        int vehiclelapaddedcount = 0;
        int lapsledcount = 0;
        int pitstopcount = 0;

        Stopwatch processTimer = new Stopwatch();
        Stopwatch vehicleTimer = new Stopwatch();
        Stopwatch vehicleLookupTimer = new Stopwatch();
        Stopwatch vehicleRunTimer = new Stopwatch();
        Stopwatch vehiclelapTimer = new Stopwatch();
        Stopwatch vehiclelapAddTimer = new Stopwatch();
        Stopwatch lapsLedTimer = new Stopwatch();
        Stopwatch pitstopTimer = new Stopwatch();

        #region ### PROCESS RUN DATA ###
        protected internal void processRunData(LiveFeedModel model)
        {
            if (model.elapsed_time == lastElapsed)
            {
                LogMessage("Duplicate feed");
                return;
            }

            lastElapsed = model.elapsed_time;

            NascarDbContext context = GetContext();

            foreach (VehicleModel vehicle in model.vehicles)
            {               

                try
                {
                    var raceVehicle = currentRace.RaceVehicles.Where(rv => rv.vehicle_number == vehicle.vehicle_number & rv.race_id == model.race_id).FirstOrDefault();
                    
                    if (null == raceVehicle)
                    {
                        raceVehicle = context.RaceVehicles.Create();
                        raceVehicle.race_id = model.race_id;
                        raceVehicle.vehicle_number = vehicle.vehicle_number;
                        raceVehicle.sponsor_name = String.IsNullOrEmpty(vehicle.sponsor_name) ? "-" : vehicle.sponsor_name;
                        raceVehicle.vehicle_type_id = context.VehicleTypes.Where(t => t.vehicle_manufacturer == vehicle.vehicle_manufacturer).FirstOrDefault().vehicle_type_id;

                        context.RaceVehicles.Add(raceVehicle);
                        context.SaveChanges();
                    }

                    vehicleRunTimer.Start();
                   
                    var vehicleRun = raceVehicle.VehicleRuns.Where(r => r.race_run_id == currentRun.race_run_id).FirstOrDefault();
                    if (null == vehicleRun)
                    {
                        vehicleRun = context.VehicleRuns.Create();
                        vehicleRun.race_run_id = currentRun.race_run_id;
                        vehicleRun.vehicle_id = raceVehicle.vehicle_id;
                        vehicleRun.driver_id = GetDriver(vehicle.driver).driver_id;

                        context.Runs.Attach(currentRun);
                        currentRun.VehicleRuns.Add(vehicleRun);

                        context.SaveChanges();
                    }
                    ProcessLapsLed(vehicleRun, vehicle.laps_led);

                    ProcessPitStops(vehicleRun, vehicle.pit_stops);

                    ProcessVehicleLap(vehicleRun, vehicle, model.lap_number);
                }
                catch (Exception ex)
                {
                    ExceptionHandler(ex);
                }
            } 
        }

        void PrintTimers()
        {
            Console.WriteLine("***********************************************************");

            if (vehicleTimer.ElapsedMilliseconds > 0)
            {
                double vehicleavg = (double)vehicleTimer.ElapsedMilliseconds / (double)vehiclecount;
                Console.WriteLine(String.Format("Vehicle Average: {0} ms", vehicleavg.ToString()));
            }
            if (vehicleLookupTimer.ElapsedMilliseconds > 0)
            {
                double vehiclelookupavg = (double)vehicleLookupTimer.ElapsedMilliseconds / (double)vehiclecount;
                Console.WriteLine(String.Format("Vehicle Lookup Average: {0} ms", vehiclelookupavg.ToString()));
            }
            if (vehicleRunTimer.ElapsedMilliseconds > 0)
            {
                double vehiclerunavg = (double)vehicleRunTimer.ElapsedMilliseconds / (double)vehiclecount;
                Console.WriteLine(String.Format("VehicleRun Average: {0} ms", vehiclerunavg.ToString()));
            }
            if (vehiclelapTimer.ElapsedMilliseconds > 0)
            {
                double vehiclelapavg = (double)vehiclelapTimer.ElapsedMilliseconds / (double)vehiclecount;
                Console.WriteLine(String.Format("VehicleLaps Average: {0} ms",  vehiclelapavg.ToString()));
            }

            if (lapsledcount > 0 && lapsLedTimer.ElapsedMilliseconds > 0)
            {
                double lapsledavg = (double)lapsLedTimer.ElapsedMilliseconds / (double)lapsledcount;
                Console.WriteLine(String.Format("LapsLed Average: {0} ms", lapsledavg.ToString()));
            }
            if (pitstopcount > 0 && pitstopTimer.ElapsedMilliseconds > 0)
            {
                double pitstopdavg = (double)pitstopTimer.ElapsedMilliseconds / (double)pitstopcount;
                Console.WriteLine(String.Format("PitStops Average: {0} ms", pitstopdavg.ToString()));
            }
            if (vehiclelapaddedcount > 0 && vehiclelapAddTimer.ElapsedMilliseconds > 0)
            {
                double addedLapdavg = (double)vehiclelapAddTimer.ElapsedMilliseconds / (double)vehiclelapaddedcount;
                Console.WriteLine(String.Format("Added VehicleLap Average: {0} ms", addedLapdavg.ToString()));
            }
        }

        void ProcessVehicleLap(VehicleRun vehicleRun, VehicleModel vehicle, int lap_number)
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
        void ProcessPitStops(VehicleRun vehicleRun, IList<PitStopModel> pit_stops)
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
        void ProcessLapsLed(VehicleRun vehicleRun, IList<LapsLedModel> laps_led)
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
        #endregion

        #region get model methods
        protected internal LiveFeedModel GetFeedModel(string feedData)
        {
            return JsonConvert.DeserializeObject<LiveFeedModel>(feedData);
        }
        #endregion

        #region get data classes
        protected internal Race GetRace(LiveFeedModel model)
        {
            NascarDbContext context = GetContext();
            var race = context.Races.Find(model.race_id);

            if (null == race)
                throw new ArgumentException("Could not find that race.", "race_id");

            return race;
        }

        protected internal Run GetRun(LiveFeedModel model)
        {
            NascarDbContext context = GetContext();
            var run = context.Runs.Where(r => r.race_id == model.race_id && r.run_id == model.run_id).FirstOrDefault();

            if (null == run)
                run = CreateRun(model); ;

            return run;
        }
        protected internal Run CreateRun(LiveFeedModel model)
        {
            NascarDbContext context = GetContext();
            var newRun = context.Runs.Create();

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

            context.Runs.Add(newRun);
            context.SaveChanges();

            return newRun;
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
            NascarDbContext context = GetContext();
            var newDriver = context.Drivers.Create();

            newDriver.driver_id = model.driver_id;
            newDriver.full_name = model.full_name;
            newDriver.first_name = model.first_name;
            newDriver.last_name = model.last_name;
            newDriver.is_in_chase = model.is_in_chase;

            context.Drivers.Add(newDriver);
            context.SaveChanges();

            return newDriver;
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
