namespace Nascar.ServiceScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedRaceDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ScheduledRace", "race_date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ScheduledRace", "race_date");
        }
    }
}
