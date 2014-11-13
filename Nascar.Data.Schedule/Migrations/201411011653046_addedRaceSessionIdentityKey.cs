namespace Nascar.ServiceScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedRaceSessionIdentityKey : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.RaceSession");
            AlterColumn("dbo.RaceSession", "race_session_id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.RaceSession", "race_session_id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.RaceSession");
            AlterColumn("dbo.RaceSession", "race_session_id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.RaceSession", "race_session_id");
        }
    }
}
