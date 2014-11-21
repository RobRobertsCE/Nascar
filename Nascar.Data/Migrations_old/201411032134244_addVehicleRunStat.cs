namespace Nascar.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addVehicleRunStat : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VehicleRunStat",
                c => new
                    {
                        vehicle_stat_id = c.Int(nullable: false, identity: true),
                        race_id = c.Int(nullable: false),
                        run_id = c.Int(nullable: false),
                        lap_number = c.Int(nullable: false),
                        average_restart_speed = c.Double(nullable: false),
                        average_running_position = c.Double(nullable: false),
                        average_speed = c.Double(nullable: false),
                        best_lap = c.Int(nullable: false),
                        best_lap_speed = c.Double(nullable: false),
                        best_lap_time = c.Double(nullable: false),
                        vehicle_elapsed_time = c.Double(nullable: false),
                        fastest_laps_run = c.Int(nullable: false),
                        laps_completed = c.Int(nullable: false),
                        last_lap_speed = c.Double(nullable: false),
                        last_lap_time = c.Double(nullable: false),
                        passes_made = c.Int(nullable: false),
                        passing_differential = c.Int(nullable: false),
                        qualifying_status = c.Int(nullable: false),
                        running_position = c.Int(nullable: false),
                        status = c.Int(nullable: false),
                        delta = c.Double(nullable: false),
                        times_passed = c.Int(nullable: false),
                        quality_passes = c.Int(nullable: false),
                        is_on_track = c.Boolean(nullable: false),
                        vehicle_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.vehicle_stat_id)
                .ForeignKey("dbo.Vehicle", t => t.vehicle_id, cascadeDelete: true)
                .Index(t => t.vehicle_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehicleRunStat", "vehicle_id", "dbo.Vehicle");
            DropIndex("dbo.VehicleRunStat", new[] { "vehicle_id" });
            DropTable("dbo.VehicleRunStat");
        }
    }
}
