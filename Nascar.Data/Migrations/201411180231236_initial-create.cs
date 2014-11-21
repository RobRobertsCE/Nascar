namespace Nascar.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialcreate : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.Driver",
            //    c => new
            //        {
            //            driver_id = c.Int(nullable: false),
            //            full_name = c.String(),
            //            first_name = c.String(),
            //            last_name = c.String(),
            //            is_in_chase = c.Boolean(nullable: false),
            //        })
            //    .PrimaryKey(t => t.driver_id);
            
            //CreateTable(
            //    "dbo.LapsLed",
            //    c => new
            //        {
            //            laps_led_id = c.Int(nullable: false, identity: true),
            //            vehicle_id = c.Int(nullable: false),
            //            start_lap = c.Int(nullable: false),
            //            end_lap = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.laps_led_id)
            //    .ForeignKey("dbo.Vehicle", t => t.vehicle_id, cascadeDelete: true)
            //    .Index(t => t.vehicle_id);
            
            //CreateTable(
            //    "dbo.LiveFeed",
            //    c => new
            //        {
            //            live_feed_id = c.Int(nullable: false, identity: true),
            //            race_id = c.Int(nullable: false),
            //            run_id = c.Int(nullable: false),
            //            elapsed_time = c.Double(nullable: false),
            //            lap_number = c.Int(nullable: false),
            //            flag_state = c.Int(nullable: false),
            //            laps_to_go = c.Int(nullable: false),
            //            time_of_day = c.Double(nullable: false),
            //            number_of_caution_segments = c.Int(nullable: false),
            //            number_of_caution_laps = c.Int(nullable: false),
            //            number_of_lead_changes = c.Int(nullable: false),
            //            number_of_leaders = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.live_feed_id)
            //    .ForeignKey("dbo.Run", t => new { t.race_id, t.run_id }, cascadeDelete: true)
            //    .Index(t => new { t.race_id, t.run_id });
            
            //CreateTable(
            //    "dbo.Run",
            //    c => new
            //        {
            //            race_id = c.Int(nullable: false),
            //            run_id = c.Int(nullable: false),
            //            run_name = c.String(),
            //            run_type = c.Int(nullable: false),
            //            laps_in_race = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => new { t.race_id, t.run_id })
            //    .ForeignKey("dbo.Race", t => t.race_id, cascadeDelete: true)
            //    .Index(t => t.race_id);
            
            //CreateTable(
            //    "dbo.Race",
            //    c => new
            //        {
            //            race_id = c.Int(nullable: false),
            //            race_name = c.String(),
            //            track_id = c.Int(nullable: false),
            //            series_id = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.race_id)
            //    .ForeignKey("dbo.Series", t => t.series_id, cascadeDelete: true)
            //    .ForeignKey("dbo.Track", t => t.track_id, cascadeDelete: true)
            //    .Index(t => t.track_id)
            //    .Index(t => t.series_id);
            
            //CreateTable(
            //    "dbo.Series",
            //    c => new
            //        {
            //            series_id = c.Int(nullable: false),
            //            series_name = c.String(),
            //        })
            //    .PrimaryKey(t => t.series_id);
            
            //CreateTable(
            //    "dbo.Track",
            //    c => new
            //        {
            //            track_id = c.Int(nullable: false),
            //            track_length = c.Double(nullable: false),
            //            track_name = c.String(),
            //        })
            //    .PrimaryKey(t => t.track_id);
            
            //CreateTable(
            //    "dbo.Vehicle",
            //    c => new
            //        {
            //            vehicle_id = c.Int(nullable: false, identity: true),
            //            race_id = c.Int(nullable: false),
            //            run_id = c.Int(nullable: false),
            //            vehicle_number = c.String(),
            //            sponsor_name = c.String(),
            //            starting_position = c.Int(nullable: false),
            //            vehicle_manufacturer = c.String(),
            //            qualifying_status = c.Int(nullable: false),
            //            is_on_track = c.Boolean(nullable: false),
            //            status = c.Int(nullable: false),
            //            average_restart_speed = c.Double(nullable: false),
            //            average_running_position = c.Double(nullable: false),
            //            average_speed = c.Double(nullable: false),
            //            best_lap = c.Int(nullable: false),
            //            best_lap_speed = c.Double(nullable: false),
            //            best_lap_time = c.Double(nullable: false),
            //            vehicle_elapsed_time = c.Double(nullable: false),
            //            fastest_laps_run = c.Int(nullable: false),
            //            laps_completed = c.Int(nullable: false),
            //            last_lap_speed = c.Double(nullable: false),
            //            last_lap_time = c.Double(nullable: false),
            //            passes_made = c.Int(nullable: false),
            //            passing_differential = c.Int(nullable: false),
            //            running_position = c.Int(nullable: false),
            //            delta = c.Double(nullable: false),
            //            times_passed = c.Int(nullable: false),
            //            quality_passes = c.Int(nullable: false),
            //            driver_id = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.vehicle_id)
            //    .ForeignKey("dbo.Driver", t => t.driver_id, cascadeDelete: true)
            //    .ForeignKey("dbo.Run", t => new { t.race_id, t.run_id }, cascadeDelete: true)
            //    .Index(t => new { t.race_id, t.run_id })
            //    .Index(t => t.driver_id);
            
            //CreateTable(
            //    "dbo.PitStop",
            //    c => new
            //        {
            //            pit_stop_id = c.Int(nullable: false, identity: true),
            //            pit_in_lap_count = c.Int(nullable: false),
            //            vehicle_number = c.String(),
            //            positions_gained_lossed = c.Int(nullable: false),
            //            pit_in_elapsed_time = c.Double(nullable: false),
            //            pit_in_leader_lap = c.Int(nullable: false),
            //            pit_out_elapsed_time = c.Double(nullable: false),
            //            vehicle_id = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.pit_stop_id)
            //    .ForeignKey("dbo.Vehicle", t => t.vehicle_id, cascadeDelete: true)
            //    .Index(t => t.vehicle_id);
            
            //CreateTable(
            //    "dbo.VehicleRunStat",
            //    c => new
            //        {
            //            vehicle_stat_id = c.Int(nullable: false, identity: true),
            //            race_id = c.Int(nullable: false),
            //            run_id = c.Int(nullable: false),
            //            lap_number = c.Int(nullable: false),
            //            average_restart_speed = c.Double(nullable: false),
            //            average_running_position = c.Double(nullable: false),
            //            average_speed = c.Double(nullable: false),
            //            best_lap = c.Int(nullable: false),
            //            best_lap_speed = c.Double(nullable: false),
            //            best_lap_time = c.Double(nullable: false),
            //            vehicle_elapsed_time = c.Double(nullable: false),
            //            fastest_laps_run = c.Int(nullable: false),
            //            laps_completed = c.Int(nullable: false),
            //            last_lap_speed = c.Double(nullable: false),
            //            last_lap_time = c.Double(nullable: false),
            //            passes_made = c.Int(nullable: false),
            //            passing_differential = c.Int(nullable: false),
            //            qualifying_status = c.Int(nullable: false),
            //            running_position = c.Int(nullable: false),
            //            status = c.Int(nullable: false),
            //            delta = c.Double(nullable: false),
            //            times_passed = c.Int(nullable: false),
            //            quality_passes = c.Int(nullable: false),
            //            is_on_track = c.Boolean(nullable: false),
            //            vehicle_id = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.vehicle_stat_id)
            //    .ForeignKey("dbo.Vehicle", t => t.vehicle_id, cascadeDelete: true)
            //    .Index(t => t.vehicle_id);
            
            //CreateTable(
            //    "dbo.RawFeedRecord",
            //    c => new
            //        {
            //            RawFeedRecordId = c.Int(nullable: false, identity: true),
            //            FeedTimestamp = c.DateTime(nullable: false),
            //            race_id = c.Int(nullable: false),
            //            run_id = c.Int(nullable: false),
            //            data = c.String(),
            //            lap_number = c.Int(nullable: false),
            //            flag_state = c.Int(nullable: false),
            //            elapsed_time = c.Double(nullable: false),
            //            RawFeedKey = c.Int(nullable: false),
            //            rowversion = c.Binary(),
            //        })
            //    .PrimaryKey(t => t.RawFeedRecordId);
            
            //CreateTable(
            //    "dbo.RawFeedRecordView",
            //    c => new
            //        {
            //            race_id = c.Int(nullable: false),
            //            run_id = c.Int(nullable: false),
            //            series_id = c.Int(nullable: false),
            //            track_id = c.Int(nullable: false),
            //            run_type = c.Int(nullable: false),
            //            run_name = c.String(),
            //            run_type_name = c.String(),
            //            series_name = c.String(),
            //            track_name = c.String(),
            //            date_time = c.DateTime(nullable: false),
            //            feed_count = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => new { t.race_id, t.run_id });
            
            //CreateTable(
            //    "dbo.RawFeed",
            //    c => new
            //        {
            //            RawFeedKey = c.Int(nullable: false, identity: true),
            //            Timestamp = c.DateTime(nullable: false),
            //            RawFeedData = c.String(),
            //        })
            //    .PrimaryKey(t => t.RawFeedKey);
            
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.LiveFeed", new[] { "race_id", "run_id" }, "dbo.Run");
            //DropForeignKey("dbo.VehicleRunStat", "vehicle_id", "dbo.Vehicle");
            //DropForeignKey("dbo.Vehicle", new[] { "race_id", "run_id" }, "dbo.Run");
            //DropForeignKey("dbo.PitStop", "vehicle_id", "dbo.Vehicle");
            //DropForeignKey("dbo.LapsLed", "vehicle_id", "dbo.Vehicle");
            //DropForeignKey("dbo.Vehicle", "driver_id", "dbo.Driver");
            //DropForeignKey("dbo.Run", "race_id", "dbo.Race");
            //DropForeignKey("dbo.Race", "track_id", "dbo.Track");
            //DropForeignKey("dbo.Race", "series_id", "dbo.Series");
            //DropIndex("dbo.VehicleRunStat", new[] { "vehicle_id" });
            //DropIndex("dbo.PitStop", new[] { "vehicle_id" });
            //DropIndex("dbo.Vehicle", new[] { "driver_id" });
            //DropIndex("dbo.Vehicle", new[] { "race_id", "run_id" });
            //DropIndex("dbo.Race", new[] { "series_id" });
            //DropIndex("dbo.Race", new[] { "track_id" });
            //DropIndex("dbo.Run", new[] { "race_id" });
            //DropIndex("dbo.LiveFeed", new[] { "race_id", "run_id" });
            //DropIndex("dbo.LapsLed", new[] { "vehicle_id" });
            //DropTable("dbo.RawFeed");
            //DropTable("dbo.RawFeedRecordView");
            //DropTable("dbo.RawFeedRecord");
            //DropTable("dbo.VehicleRunStat");
            //DropTable("dbo.PitStop");
            //DropTable("dbo.Vehicle");
            //DropTable("dbo.Track");
            //DropTable("dbo.Series");
            //DropTable("dbo.Race");
            //DropTable("dbo.Run");
            //DropTable("dbo.LiveFeed");
            //DropTable("dbo.LapsLed");
            //DropTable("dbo.Driver");
        }
    }
}
