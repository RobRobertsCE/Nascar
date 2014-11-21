namespace Nascar.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRaceAndRunToVehicle : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Vehicle", "live_feed_id", "dbo.LiveFeed");
            DropIndex("dbo.Vehicle", new[] { "live_feed_id" });
            AddColumn("dbo.Vehicle", "race_id", c => c.Int(nullable: false));
            AddColumn("dbo.Vehicle", "run_id", c => c.Int(nullable: false));
            CreateIndex("dbo.Vehicle", new[] { "race_id", "run_id" });
            AddForeignKey("dbo.Vehicle", new[] { "race_id", "run_id" }, "dbo.Run", new[] { "race_id", "run_id" }, cascadeDelete: true);
            DropColumn("dbo.LapsLed", "live_feed_id");
            DropColumn("dbo.Vehicle", "live_feed_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehicle", "live_feed_id", c => c.Int(nullable: false));
            AddColumn("dbo.LapsLed", "live_feed_id", c => c.Int(nullable: false));
            DropForeignKey("dbo.Vehicle", new[] { "race_id", "run_id" }, "dbo.Run");
            DropIndex("dbo.Vehicle", new[] { "race_id", "run_id" });
            DropColumn("dbo.Vehicle", "run_id");
            DropColumn("dbo.Vehicle", "race_id");
            CreateIndex("dbo.Vehicle", "live_feed_id");
            AddForeignKey("dbo.Vehicle", "live_feed_id", "dbo.LiveFeed", "live_feed_id", cascadeDelete: true);
        }
    }
}
