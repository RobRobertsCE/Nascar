namespace NascarApi.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class NascarDbContext : DbContext
    {
        public NascarDbContext()
            : base("name=NascarFeedData")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }
        /* Tables */
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<FeedData> FeedDatas { get; set; }
        public virtual DbSet<FeedType> FeedTypes { get; set; }
        public virtual DbSet<FlagState> FlagStates { get; set; }
        public virtual DbSet<QualifyingResult> QualifyingResults { get; set; }
        public virtual DbSet<PitStop> PitStops { get; set; }
        public virtual DbSet<Race> Races { get; set; }
        public virtual DbSet<RaceVehicle> RaceVehicles { get; set; }
        public virtual DbSet<Run> Runs { get; set; }
        public virtual DbSet<RunFlagState> RunFlagStates { get; set; }
        public virtual DbSet<RunType> RunTypes { get; set; }
        public virtual DbSet<ScheduledEvent> ScheduledEvents { get; set; }
        public virtual DbSet<Season> Seasons { get; set; }
        public virtual DbSet<Series> Series { get; set; }
        public virtual DbSet<SeriesPoints> SeriesPointsStandings { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<TeamVehicle> TeamVehicles { get; set; }
        public virtual DbSet<TeamVehicleDriver> TeamVehicleDrivers { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }
        public virtual DbSet<TrackType> TrackTypes { get; set; }
        public virtual DbSet<VehicleLap> VehicleLaps { get; set; }
        public virtual DbSet<VehicleLapsLed> VehicleLapsLeds { get; set; }
        public virtual DbSet<VehicleRun> VehicleRuns { get; set; }
        public virtual DbSet<VehicleType> VehicleTypes { get; set; }
        /* Views */
        public virtual DbSet<EventSchedule> EventSchedules { get; set; }
        public virtual DbSet<SeriesSchedule> SeriesSchedules { get; set; }
        public virtual DbSet<TeamDriver> TeamDrivers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Driver>()
                .Property(e => e.full_name)
                .IsUnicode(false);

            modelBuilder.Entity<Driver>()
                .Property(e => e.first_name)
                .IsUnicode(false);

            modelBuilder.Entity<Driver>()
                .Property(e => e.last_name)
                .IsUnicode(false);

            modelBuilder.Entity<Driver>()
                .HasMany(e => e.VehicleRuns)
                .WithRequired(e => e.Driver)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FlagState>()
                .Property(e => e.flag_state_name)
                .IsUnicode(false);

            //modelBuilder.Entity<FlagState>()
            //    .HasMany(e => e.RunLaps)
            //    .WithRequired(e => e.FlagState)
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<Race>()
                .Property(e => e.race_name)
                .IsUnicode(false);

            modelBuilder.Entity<Race>()
                .HasMany(e => e.Runs)
                .WithRequired(e => e.Race)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Race>()
                .HasMany(e => e.RaceVehicles)
                .WithRequired(e => e.Race)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RaceVehicle>()
                .Property(e => e.sponsor_name)
                .IsUnicode(false);

            modelBuilder.Entity<RaceVehicle>()
                .HasMany(e => e.TeamVehicles)
                .WithRequired(e => e.RaceVehicle)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Run>()
                .Property(e => e.run_name)
                .IsUnicode(false);

            //modelBuilder.Entity<Run>()
            //    .HasMany(e => e.RunLaps)
            //    .WithRequired(e => e.Run)
            //    .HasForeignKey(e => new { e.race_id, e.run_id })
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Run>()
            //    .HasMany(e => e.VehicleRuns)
            //    .WithRequired(e => e.Run)
            //    .HasForeignKey(e => new { e.race_id, e.run_id })
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<RunType>()
                .Property(e => e.run_type_name)
                .IsUnicode(false);

            modelBuilder.Entity<RunType>()
                .HasMany(e => e.Runs)
                .WithRequired(e => e.RunType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Season>()
                .Property(e => e.season_name)
                .IsUnicode(false);

            modelBuilder.Entity<Season>()
                .HasMany(e => e.Races)
                .WithRequired(e => e.Season)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Series>()
                .Property(e => e.series_name)
                .IsUnicode(false);

            modelBuilder.Entity<Series>()
                .HasMany(e => e.Races)
                .WithRequired(e => e.Series)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Team>()
                .Property(e => e.team_name)
                .IsUnicode(false);

            modelBuilder.Entity<Team>()
                .HasMany(e => e.TeamVehicles)
                .WithRequired(e => e.Team)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Track>()
                .Property(e => e.track_name)
                .IsUnicode(false);

            modelBuilder.Entity<Track>()
                .HasMany(e => e.Races)
                .WithRequired(e => e.Track)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TrackType>()
                .Property(e => e.track_type_name)
                .IsUnicode(false);

            modelBuilder.Entity<TrackType>()
                .HasMany(e => e.Tracks)
                .WithRequired(e => e.TrackType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VehicleRun>()
                .HasMany(e => e.PitStops)
                .WithRequired(e => e.VehicleRun)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VehicleRun>()
                .HasMany(e => e.VehicleLaps)
                .WithRequired(e => e.VehicleRun)
                .WillCascadeOnDelete(false);

            //modelBuilder.Entity<VehicleLap>()
            //   .Property(e => e.lap_number)
            //   .IsIndexed();

            modelBuilder.Entity<VehicleType>()
                .Property(e => e.vehicle_type_name)
                .IsUnicode(false);

            modelBuilder.Entity<VehicleType>()
                .Property(e => e.vehicle_manufacturer)
                .IsUnicode(false);

            modelBuilder.Entity<VehicleType>()
                .HasMany(e => e.RaceVehicles)
                .WithRequired(e => e.VehicleType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EventSchedule>()
                .Property(e => e.race_name)
                .IsUnicode(false);

            modelBuilder.Entity<EventSchedule>()
                .Property(e => e.run_name)
                .IsUnicode(false);

            modelBuilder.Entity<EventSchedule>()
                .Property(e => e.run_type_name)
                .IsUnicode(false);

            //modelBuilder.Entity<LapStatusByRaceRun>()
            //    .Property(e => e.run_name)
            //    .IsUnicode(false);

            //modelBuilder.Entity<LapStatusByRaceRun>()
            //    .Property(e => e.run_type_name)
            //    .IsUnicode(false);

            //modelBuilder.Entity<LapStatusByRaceRun>()
            //    .Property(e => e.flag_state_name)
            //    .IsUnicode(false);

            modelBuilder.Entity<SeriesSchedule>()
                .Property(e => e.season_name)
                .IsUnicode(false);

            modelBuilder.Entity<SeriesSchedule>()
                .Property(e => e.series_name)
                .IsUnicode(false);

            modelBuilder.Entity<SeriesSchedule>()
                .Property(e => e.race_name)
                .IsUnicode(false);

            modelBuilder.Entity<SeriesSchedule>()
                .Property(e => e.track_name)
                .IsUnicode(false);

            modelBuilder.Entity<SeriesSchedule>()
                .Property(e => e.track_type_name)
                .IsUnicode(false);

            modelBuilder.Entity<TeamDriver>()
                .Property(e => e.team_name)
                .IsUnicode(false);

            modelBuilder.Entity<TeamDriver>()
                .Property(e => e.series_name)
                .IsUnicode(false);

            modelBuilder.Entity<TeamDriver>()
                .Property(e => e.full_name)
                .IsUnicode(false);

            modelBuilder.Entity<TeamDriver>()
                .Property(e => e.sponsor_name)
                .IsUnicode(false);

            modelBuilder.Entity<TeamDriver>()
                .Property(e => e.vehicle_type_name)
                .IsUnicode(false);
        }
    }
}
