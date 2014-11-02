namespace Nascar.ServiceScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedRaceSessions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ScheduledRaceSession", "start_time", c => c.DateTime(nullable: false));
            AddColumn("dbo.ScheduledRaceSession", "end_time", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ScheduledRaceSession", "end_time");
            DropColumn("dbo.ScheduledRaceSession", "start_time");
        }
    }
}
