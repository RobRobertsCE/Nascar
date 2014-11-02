namespace Nascar.ServiceScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTracksDialogs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ScheduledRace",
                c => new
                    {
                        race_id = c.Int(nullable: false),
                        track_id = c.Int(nullable: false),
                        series_id = c.Int(nullable: false),
                        sequence = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.race_id)
                .ForeignKey("dbo.ScheduledSeries", t => t.series_id, cascadeDelete: true)
                .ForeignKey("dbo.ScheduledTrack", t => t.track_id, cascadeDelete: true)
                .Index(t => t.track_id)
                .Index(t => t.series_id);
            
            CreateTable(
                "dbo.ScheduledSeries",
                c => new
                    {
                        series_id = c.Int(nullable: false),
                        series_name = c.String(),
                    })
                .PrimaryKey(t => t.series_id);
            
            CreateTable(
                "dbo.ScheduledTrack",
                c => new
                    {
                        track_id = c.Int(nullable: false),
                        track_name = c.String(),
                    })
                .PrimaryKey(t => t.track_id);
            
            CreateTable(
                "dbo.ScheduledRaceSession",
                c => new
                    {
                        race_session_id = c.Int(nullable: false),
                        race_id = c.Int(nullable: false),
                        session_id = c.Int(nullable: false),
                        sequence = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.race_session_id)
                .ForeignKey("dbo.ScheduledRace", t => t.race_id, cascadeDelete: true)
                .ForeignKey("dbo.ScheduledSession", t => t.session_id, cascadeDelete: true)
                .Index(t => t.race_id)
                .Index(t => t.session_id);
            
            CreateTable(
                "dbo.ScheduledSession",
                c => new
                    {
                        session_id = c.Int(nullable: false),
                        session_name = c.String(),
                    })
                .PrimaryKey(t => t.session_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ScheduledRaceSession", "session_id", "dbo.ScheduledSession");
            DropForeignKey("dbo.ScheduledRaceSession", "race_id", "dbo.ScheduledRace");
            DropForeignKey("dbo.ScheduledRace", "track_id", "dbo.ScheduledTrack");
            DropForeignKey("dbo.ScheduledRace", "series_id", "dbo.ScheduledSeries");
            DropIndex("dbo.ScheduledRaceSession", new[] { "session_id" });
            DropIndex("dbo.ScheduledRaceSession", new[] { "race_id" });
            DropIndex("dbo.ScheduledRace", new[] { "series_id" });
            DropIndex("dbo.ScheduledRace", new[] { "track_id" });
            DropTable("dbo.ScheduledSession");
            DropTable("dbo.ScheduledRaceSession");
            DropTable("dbo.ScheduledTrack");
            DropTable("dbo.ScheduledSeries");
            DropTable("dbo.ScheduledRace");
        }
    }
}
