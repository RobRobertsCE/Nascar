namespace Nascar.ServiceScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedRaceSessions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RaceSession", "start_time", c => c.DateTime(nullable: false));
            AddColumn("dbo.RaceSession", "end_time", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RaceSession", "end_time");
            DropColumn("dbo.RaceSession", "start_time");
        }
    }
}
