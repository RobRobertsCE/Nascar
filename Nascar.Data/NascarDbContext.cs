using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace Nascar.Data
{
    public class NascarDbContext : DbContext
    {
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<PitStop> PitStops { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<Race> Races { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<Series> RaceSeries { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }
        public virtual DbSet<LiveFeed> LiveFeeds { get; set; }
        public virtual DbSet<LapsLed> LapsLedList { get; set; }
        public virtual DbSet<RawFeed> RawFeeds { get; set; }

        public NascarDbContext()
            : base()
        {

        }
    }
}
