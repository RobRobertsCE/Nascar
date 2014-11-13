using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Nascar.Data.Schedule
{
    public class ScheduleDbContext : DbContext
    {
        public virtual DbSet<RaceEvent> RaceEvents { get; set; }
        public virtual DbSet<Race> Races { get; set; }
        public virtual DbSet<RaceSession> RaceSessions { get; set; }
        public virtual DbSet<Series> Series { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }
        public virtual DbSet<RaceView> RaceViews { get; set; }
        public virtual DbSet<RaceSessionView> RaceSessionViews { get; set; }
        public virtual DbSet<RaceEventView> RaceEventViews { get; set; }
        
        public ScheduleDbContext()
            : base("NascarData")
        {
            this.Configuration.LazyLoadingEnabled = false;
            Nascar.Data.Schedule.Configuration config = new Nascar.Data.Schedule.Configuration();
            config.RunSeed(this);
        }
    }
}

