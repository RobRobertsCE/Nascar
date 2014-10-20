namespace Nascar.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLapsLed : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LapsLeds",
                c => new
                    {
                        laps_led_id = c.Int(nullable: false, identity: true),
                        vehicle_id = c.Int(nullable: false),
                        live_feed_id = c.Int(nullable: false),
                        start_lap = c.Int(nullable: false),
                        end_lap = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.laps_led_id)
                .ForeignKey("dbo.Vehicle", t => t.vehicle_id, cascadeDelete: true)
                .Index(t => t.vehicle_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LapsLeds", "vehicle_id", "dbo.Vehicle");
            DropIndex("dbo.LapsLeds", new[] { "vehicle_id" });
            DropTable("dbo.LapsLeds");
        }
    }
}
