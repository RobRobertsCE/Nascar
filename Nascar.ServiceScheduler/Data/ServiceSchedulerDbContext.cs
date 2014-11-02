using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace Nascar.ServiceScheduler.Data
{
    public class ServiceSchedulerDbContext : DbContext
    {
        public virtual DbSet<ScheduledEvent> ScheduledEvents { get; set; }
        public virtual DbSet<ScheduledRace> ScheduledRaces { get; set; }
        public virtual DbSet<ScheduledRaceSession> ScheduledRaceSessions { get; set; }
        public virtual DbSet<ScheduledSeries> ScheduledRaceSeries { get; set; }
        public virtual DbSet<ScheduledSession> ScheduledSessions { get; set; }
        public virtual DbSet<ScheduledTrack> ScheduledTracks { get; set; }
        
        public ServiceSchedulerDbContext()
            : base()
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
    }
}

