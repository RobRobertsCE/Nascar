namespace Nascar.Data.Schedule
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renameClasses : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ScheduledEvent", newName: "RaceEvent");
            RenameTable(name: "dbo.ScheduledRace", newName: "Race");
            RenameTable(name: "dbo.ScheduledSeries", newName: "Series");
            RenameTable(name: "dbo.ScheduledTrack", newName: "Track");
            RenameTable(name: "dbo.ScheduledRaceSession", newName: "RaceSession");
            RenameTable(name: "dbo.ScheduledSession", newName: "Session");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Session", newName: "ScheduledSession");
            RenameTable(name: "dbo.RaceSession", newName: "ScheduledRaceSession");
            RenameTable(name: "dbo.Track", newName: "ScheduledTrack");
            RenameTable(name: "dbo.Series", newName: "ScheduledSeries");
            RenameTable(name: "dbo.Race", newName: "ScheduledRace");
            RenameTable(name: "dbo.RaceEvent", newName: "ScheduledEvent");
        }
    }
}
