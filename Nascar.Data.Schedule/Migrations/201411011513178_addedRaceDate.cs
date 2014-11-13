namespace Nascar.ServiceScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedRaceDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Race", "race_date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Race", "race_date");
        }
    }
}
