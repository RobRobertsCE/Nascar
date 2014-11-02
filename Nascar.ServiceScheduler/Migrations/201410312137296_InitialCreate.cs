namespace Nascar.ServiceScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ScheduledEvent",
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ScheduledEvent");
        }
    }
}
