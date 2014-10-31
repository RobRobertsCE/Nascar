using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nascar.Models;

namespace Nascar.Data
{
    //TODO: Remember to add left outer join to LapsLed table in SQL.
    // TODO: Make race, series, and session-specific?
    public class LiveFeedProcessor
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
        public Session CurrentSession { get; set; }
        public Race CurrentRace { get; set; }

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
                UpdateTrackSeriesRaceAndSession(model);
            }
            else
            {
                if (model.elapsed_time == LastLiveFeed.elapsed_time && model.time_of_day == LastLiveFeed.time_of_day)
                {
                    // Same as last live feed.. nothing to record.
                    return;
                }
            }

            // Add the new LIveFeed model.
            LiveFeed feedData = GetNewLiveFeed(model);
           
            // Add the vehicles 
            foreach (VehicleModel vehicleModel in model.vehicles)
            {
                Vehicle vehicle = new Vehicle(vehicleModel);
               
                feedData.vehicles.Add(vehicle);
            }

            Context.SaveChanges();                
        }

        void UpdateTrackSeriesRaceAndSession(LiveFeedModel model)
        {
            this.CurrentSeries = GetSeries(model);
            this.CurrentTrack = GetTrack(model);
            this.CurrentRace = GetRace(model);
            this.CurrentSession = GetSession(model);
        }

        // TODO: Make unique process for read/write, separate assemblies?
        // TODO: Add indicies
        // TODO: add series/race/track ids to vehicle?
        Vehicle GetVehicle(VehicleModel model)
        {
            Vehicle vehicle = Context.Vehicles
                .Where(v =>
                    v.vehicle_number == model.vehicle_number &&
                    v.Driver.driver_id == model.driver.driver_id
                    ).FirstOrDefault();

            if (null == vehicle)
            {
                vehicle = new Vehicle(model);

                Context.Vehicles.Add(vehicle);

                Context.SaveChanges();
            }

            return vehicle;
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

        Session GetSession(LiveFeedModel model)
        {
            Session session = Context.Sessions.Where(s => s.run_id == model.run_id).FirstOrDefault();

            if (null == session)
            {
                session = new Session() { run_id = model.run_id };
                session.race_id = this.CurrentRace.race_id;
                session.session_name = model.run_name;
                session.session_type = model.run_type;
                session.laps_in_session = model.laps_in_race;

                Context.Sessions.Add(session);

                Context.SaveChanges();
            }

            return session;
        }

        LiveFeed GetNewLiveFeed(LiveFeedModel model)
        {
            LiveFeed feedData = new LiveFeed(model) { Session = this.CurrentSession };            
            Context.LiveFeeds.Add(feedData);
            Context.SaveChanges();

            return feedData;
        }
    }
}
