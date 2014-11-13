using System;
using System.Linq;
using NascarData.Models;
using Newtonsoft.Json;

namespace NascarData.Business
{
    public class FeedProcessor : IFeedProcessor
    {

        delegate void processModelDelegate(LiveFeedModel model);

        #region fields
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
                lastModel = model;

                currentRace = GetRace(model);
                currentRun = GetRun(model);

                this.processModelHandler = new processModelDelegate(this.processModel);
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
        protected internal void processRunData(LiveFeedModel model)
        {
            NascarDbContext context = GetContext();

            foreach (VehicleModel vehicle in model.vehicles)
            {
                var raceVehicle = context.RaceVehicles.Where(v => v.vehicle_number.ToString() == vehicle.vehicle_number && v.race_id == model.race_id).FirstOrDefault();
                if (null == raceVehicle)
                {
                    raceVehicle = context.RaceVehicles.Create();
                    raceVehicle.race_id = model.race_id;
                    raceVehicle.vehicle_number = Convert.ToInt32(vehicle.vehicle_number);
                    raceVehicle.sponsor_name = vehicle.sponsor_name;
                    raceVehicle.vehicle_type_id = context.VehicleTypes.Where(t=>t.vehicle_manufacturer == vehicle.vehicle_manufacturer).FirstOrDefault().vehicle_type_id ;

                    context.RaceVehicles.Add(raceVehicle);
                    context.SaveChanges();
                }

                var vehicleRun = currentRun.VehicleRuns.Where(r => r.vehicle_number.ToString() == vehicle.vehicle_number && r.driver_id == vehicle.driver.driver_id).FirstOrDefault();

                if (null == vehicleRun)
                {
                    vehicleRun = context.VehicleRuns.Create();
                    vehicleRun.race_id = currentRun.race_id;
                    vehicleRun.run_id = currentRun.run_id;
                    vehicleRun.vehicle_number = Convert.ToInt32(vehicle.vehicle_number);
                    vehicleRun.driver_id = GetDriver(vehicle.driver).driver_id;

                    context.Runs.Attach(currentRun);
                    currentRun.VehicleRuns.Add(vehicleRun);

                    context.SaveChanges();
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
            newRun.run_name = model.run_name.Substring(0, 50);
            newRun.round_number = model.run_id;
            newRun.start_timestamp = DateTime.Now;
            newRun.duration = model.laps_in_race;
            newRun.is_running = true;
            newRun.flag_state_id = model.flag_state;
            newRun.laps_in_race = model.laps_in_race;
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

        //protected internal RaceVehicle GetRaceVehicle(VehicleModel model)
        //{

        //}
        //protected internal RaceVehicle CreateRaceVehicle(VehicleModel model)
        //{

        //}
        #endregion

        #region get context
        NascarDbContext _ctx = null;
        NascarDbContext GetContext()
        {
            if (null == _ctx)
                _ctx = new NascarDbContext();

            return _ctx;
        }
        #endregion

        #region common
        protected internal void ExceptionHandler(Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        #endregion
    }
}
