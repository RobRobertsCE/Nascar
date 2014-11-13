using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nascar.Data;
using Nascar.Api.Models;

namespace Nascar.Api
{
    public class LiveFeedProcessor : ILiveFeedProcessor
    {
        #region properties
        private NascarDbContext _context = null;
        protected internal virtual NascarDbContext Context
        {
            get
            {
                if (null == _context)
                    _context = new NascarDbContext();

                return _context;
            }
        }

        public IList<LiveFeedModel> LiveFeedList { get; protected internal set; }
        public LiveFeedModel LastLiveFeed { get; protected internal set; }
        public Track CurrentTrack { get; set; }
        public Series CurrentSeries { get; set; }
        public Race CurrentRace { get; set; }
        public Run CurrentRun { get; set; }
        #endregion

        #region ctor
        public LiveFeedProcessor()
        {
            LiveFeedList = new List<LiveFeedModel>();
            LastLiveFeed = new LiveFeedModel();
        }
        #endregion

        #region Process Feed
        public void ProcessLiveFeed(LiveFeedModel model)
        {
            this.LiveFeedList.Add(model);

            this.processFeed(model);

            this.LastLiveFeed = model;
        }

        void processFeed(LiveFeedModel model)
        {
            if ((model.series_id != LastLiveFeed.series_id) || (model.run_id != LastLiveFeed.run_id) || (model.track_id != LastLiveFeed.track_id) || (model.race_id != LastLiveFeed.race_id))
            {
                UpdateTrackSeriesRaceAndRun(model);
            }
            else
            {
                if (model.elapsed_time == LastLiveFeed.elapsed_time && model.time_of_day == LastLiveFeed.time_of_day)
                {
                    return;
                }
            }

            LiveFeed feedData = GetLiveFeed(model);

            foreach (VehicleModel vehicleModel in model.vehicles)
            {
                Vehicle vehicle = GetVehicle(vehicleModel, feedData);
            }
        }

        void UpdateTrackSeriesRaceAndRun(LiveFeedModel model)
        {
            this.CurrentSeries = GetSeries(model);
            this.CurrentTrack = GetTrack(model);
            this.CurrentRace = GetRace(model);
            this.CurrentRun = GetRun(model);
        }
        #endregion

        #region GET data methods
        Series GetSeries(LiveFeedModel model)
        {
            Series series = Context.RaceSeries.Where(s => s.series_id == model.series_id).FirstOrDefault();

            if (null == series)
            {
                series = new Series(model.series_id, ((SeriesName)model.series_id).ToString());

                Context.RaceSeries.Add(series);

                Context.SaveChanges();
            }

            return series;
        }

        Race GetRace(LiveFeedModel model)
        {
            Race race = Context.Races.Where(s => s.race_id == model.race_id).FirstOrDefault();

            if (null == race)
            {
                race = new Race() { race_id = model.race_id };
                race.series_id = this.CurrentSeries.series_id;
                race.track_id = this.CurrentTrack.track_id;

                Context.Races.Add(race);

                Context.SaveChanges();
            }

            return race;
        }

        Track GetTrack(LiveFeedModel model)
        {
            Track track = Context.Tracks.Where(s => s.track_id == model.track_id).FirstOrDefault();

            if (null == track)
            {
                track = new Track() { track_id = model.track_id, track_length = model.track_length, track_name = model.track_name };

                Context.Tracks.Add(track);

                Context.SaveChanges();
            }

            return track;
        }

        Run GetRun(LiveFeedModel model)
        {
            Run run = CurrentRace.Runs.Where(s => s.run_id == model.run_id && s.race_id == model.race_id).FirstOrDefault();
            if (null == run)
            {
                run = new Run()
                {
                    run_id = model.run_id,
                    race_id = model.race_id,
                    run_name = model.run_name,
                    run_type = model.run_type,
                    laps_in_race = model.laps_in_race
                };
                Context.Runs.Add(run);
                Context.SaveChanges();
            }
            return run;
        }

        LiveFeed GetLiveFeed(LiveFeedModel model)
        {
            LiveFeed feed = Context.LiveFeeds
              .Where(f =>
                  f.race_id == model.race_id &&
                  f.run_id == model.run_id
                  ).FirstOrDefault();

            if (null == feed)
            {
                feed = new LiveFeed(model);
                this.CurrentRun.live_feeds.Add(feed);
                Context.SaveChanges();
            }

            return feed;
        }

        Vehicle GetVehicle(VehicleModel model, LiveFeed feedData)
        {
            Vehicle vehicle = Context.Vehicles
                .Where(v =>
                    v.race_id == feedData.race_id &&
                    v.run_id == feedData.run_id &&
                    v.vehicle_number == model.vehicle_number &&
                    v.Driver.driver_id == model.driver.driver_id
                    ).FirstOrDefault();

            if (null == vehicle)
            {
                vehicle = new Vehicle(model, feedData.race_id, feedData.run_id, feedData.lap_number);

                vehicle.Driver = GetDriver(model.driver, vehicle);

                CurrentRun.vehicles.Add(vehicle);

                Context.SaveChanges();
            }
            else
            {
                if (!(vehicle.vehicle_elapsed_time == model.vehicle_elapsed_time))
                {
                    vehicle.qualifying_status = model.qualifying_status;
                    vehicle.status = model.status;
                    vehicle.is_on_track = model.is_on_track;

                    vehicle.average_restart_speed = model.average_restart_speed;
                    vehicle.average_running_position = model.average_running_position;

                    vehicle.average_speed = model.average_speed;
                    vehicle.best_lap = model.best_lap;
                    vehicle.best_lap_speed = model.best_lap_speed;
                    vehicle.best_lap_time = model.best_lap_time;
                    vehicle.vehicle_elapsed_time = model.vehicle_elapsed_time;

                    vehicle.fastest_laps_run = model.fastest_laps_run;
                    vehicle.laps_completed = model.laps_completed;
                    vehicle.last_lap_speed = model.last_lap_speed;
                    vehicle.last_lap_time = model.last_lap_time;

                    vehicle.passes_made = model.passes_made;
                    vehicle.passing_differential = model.passing_differential;
                    vehicle.running_position = model.running_position;
                    vehicle.delta = model.delta;
                    vehicle.times_passed = model.times_passed;
                    vehicle.quality_passes = model.quality_passes;

                    Context.SaveChanges();
                }
            }

            if (!vehicle.stats.Any(s => s.lap_number == feedData.lap_number))
            {
                vehicle.stats.Add(new VehicleRunStat(model, feedData.race_id, feedData.run_id, feedData.lap_number));
                Context.SaveChanges();
            }

            return vehicle;
        }

        Driver GetDriver(DriverModel model, Vehicle vehicle)
        {
            Driver driver = Context.Drivers
                .Where(d =>
                    d.driver_id == vehicle.driver_id
                    ).FirstOrDefault();

            if (null == driver)
            {
                driver = new Driver(model);
                Context.Drivers.Add(driver);
                Context.SaveChanges();
            }

            return driver;
        }

        #endregion

        #region ILiveFeedProcessor.Display
        void ILiveFeedProcessor.Display()
        {
            Console.WriteLine("ILiveFeedProcessor.Display NOT IMPLEMENTED"); ;
        }
        #endregion
    }
}
