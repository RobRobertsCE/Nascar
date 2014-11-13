namespace Nascar.Data.Schedule
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wip : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RaceEvent",
                c => new
                    {
                        scheduled_event_id = c.Int(nullable: false, identity: true),
                        track_id = c.Int(nullable: false),
                        track_name = c.String(),
                        run_id = c.Int(nullable: false),
                        run_name = c.String(),
                        series_id = c.Int(nullable: false),
                        race_id = c.Int(nullable: false),
                        session_id = c.Int(nullable: false),
                        status = c.String(),
                        enabled = c.Boolean(nullable: false),
                        scheduled_event_start = c.DateTime(nullable: false),
                        scheduled_event_end = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.scheduled_event_id);
            
            CreateTable(
                "dbo.Race",
                c => new
                    {
                        race_id = c.Int(nullable: false),
                        track_id = c.Int(nullable: false),
                        series_id = c.Int(nullable: false),
                        sequence = c.Int(nullable: false),
                        race_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.race_id)
                .ForeignKey("dbo.Series", t => t.series_id, cascadeDelete: true)
                .ForeignKey("dbo.Track", t => t.track_id, cascadeDelete: true)
                .Index(t => t.track_id)
                .Index(t => t.series_id);
            
            CreateTable(
                "dbo.Series",
                c => new
                    {
                        series_id = c.Int(nullable: false),
                        series_name = c.String(),
                    })
                .PrimaryKey(t => t.series_id);
            
            CreateTable(
                "dbo.Track",
                c => new
                    {
                        track_id = c.Int(nullable: false),
                        track_name = c.String(),
                    })
                .PrimaryKey(t => t.track_id);
            
            CreateTable(
                "dbo.RaceSession",
                c => new
                    {
                        race_session_id = c.Int(nullable: false, identity: true),
                        race_id = c.Int(nullable: false),
                        session_id = c.Int(nullable: false),
                        sequence = c.Int(nullable: false),
                        start_time = c.DateTime(nullable: false),
                        end_time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.race_session_id)
                .ForeignKey("dbo.Race", t => t.race_id, cascadeDelete: true)
                .ForeignKey("dbo.Session", t => t.session_id, cascadeDelete: true)
                .Index(t => t.race_id)
                .Index(t => t.session_id);
            
            CreateTable(
                "dbo.Session",
                c => new
                    {
                        session_id = c.Int(nullable: false),
                        session_name = c.String(),
                    })
                .PrimaryKey(t => t.session_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RaceSession", "session_id", "dbo.Session");
            DropForeignKey("dbo.RaceSession", "race_id", "dbo.Race");
            DropForeignKey("dbo.Race", "track_id", "dbo.Track");
            DropForeignKey("dbo.Race", "series_id", "dbo.Series");
            DropIndex("dbo.RaceSession", new[] { "session_id" });
            DropIndex("dbo.RaceSession", new[] { "race_id" });
            DropIndex("dbo.Race", new[] { "series_id" });
            DropIndex("dbo.Race", new[] { "track_id" });
            DropTable("dbo.Session");
            DropTable("dbo.RaceSession");
            DropTable("dbo.Track");
            DropTable("dbo.Series");
            DropTable("dbo.Race");
            DropTable("dbo.RaceEvent");
        }
    }
}
