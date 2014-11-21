namespace Nascar.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixreplayview : DbMigration
    {
        public override void Up()
        {
            //DropPrimaryKey("dbo.RawFeedRecordView");
            //AddPrimaryKey("dbo.RawFeedRecordView", new[] { "race_id", "run_id" });
            //DropColumn("dbo.RawFeedRecordView", "RawFeedKey");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RawFeedRecordView", "RawFeedKey", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.RawFeedRecordView");
            AddPrimaryKey("dbo.RawFeedRecordView", "RawFeedKey");
        }
    }
}
