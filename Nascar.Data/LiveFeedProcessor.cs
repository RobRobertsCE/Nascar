using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nascar.Models;

namespace Nascar.Data
{
    //TODO: Remember to add left outer join to LapsLed table in SQL.
    // TODO: Make race, series, and session-specific?
    public class LiveFeedProcessor : Nascar.Data.ILiveFeedProcessor
    {
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

        public LiveFeedProcessor()
        {
            LiveFeedList = new List<LiveFeedModel>();
            LastLiveFeed = new LiveFeedModel();
        }

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
                    v.vehicle_number == model.vehicle_number &&
                    v.Driver.driver_id == model.driver.driver_id
                    ).FirstOrDefault();

            if (null == vehicle)
            {
                vehicle = new Vehicle(model);
                vehicle.live_feed_id = feedData.live_feed_id;
                vehicle.Driver = GetDriver(model.driver,vehicle);

                feedData.vehicles.Add(vehicle);

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

            if (null==driver)
            {
                driver = new Driver(model);
                Context.Drivers.Add(driver);
                Context.SaveChanges();
            }

            return driver;
        }

        void GetLapsLed()
        {

        }

        void GetPitStops()
        {

        }

        void ILiveFeedProcessor.Display()
        {
            throw new NotImplementedException();
        }
    }
}
