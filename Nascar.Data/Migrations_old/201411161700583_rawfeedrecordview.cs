namespace Nascar.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rawfeedrecordview : DbMigration
    {
        public override void Up()
        {
        //    CreateTable(
        //        "dbo.RawFeedRecord",
        //        c => new
        //            {
        //                RawFeedRecordId = c.Int(nullable: false, identity: true),
        //                FeedTimestamp = c.DateTime(nullable: false),
        //                race_id = c.Int(nullable: false),
        //                run_id = c.Int(nullable: false),
        //                data = c.String(),
        //                lap_number = c.Int(nullable: false),
        //                flag_state = c.Int(nullable: false),
        //                elapsed_time = c.Double(nullable: false),
        //                RawFeedKey = c.Int(nullable: false),
        //                rowversion = c.Int(nullable: false),
        //            })
        //        .PrimaryKey(t => t.RawFeedRecordId);
            
        //    CreateTable(
        //        "dbo.RawFeedRecordView",
        //        c => new
        //            {
        //                RawFeedKey = c.Int(nullable: false),
        //                race_id = c.Int(nullable: false),
        //                run_id = c.Int(nullable: false),
        //                series_id = c.Int(nullable: false),
        //                track_id = c.Int(nullable: false),
        //                run_type = c.Int(nullable: false),
        //                run_name = c.String(),
        //                run_type_name = c.String(),
        //                series_name = c.String(),
        //                track_name = c.String(),
        //                date_time = c.DateTime(nullable: false),
        //                feed_count = c.Int(nullable: false),
        //            })
        //        .PrimaryKey(t => t.RawFeedKey);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RawFeedRecordView");
            DropTable("dbo.RawFeedRecord");
        }
    }
}
