namespace Nascar.ServiceScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedRaceSessionIdentityKey : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ScheduledRaceSession");
            AlterColumn("dbo.ScheduledRaceSession", "race_session_id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.ScheduledRaceSession", "race_session_id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ScheduledRaceSession");
            AlterColumn("dbo.ScheduledRaceSession", "race_session_id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ScheduledRaceSession", "race_session_id");
        }
    }
}
