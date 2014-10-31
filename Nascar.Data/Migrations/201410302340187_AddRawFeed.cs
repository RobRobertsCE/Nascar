namespace Nascar.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRawFeed : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RawFeed",
                c => new
                    {
                        RawFeedKey = c.Int(nullable: false, identity: true),
                        Timestamp = c.DateTime(nullable: false),
                        RawFeedData = c.String(),
                    })
                .PrimaryKey(t => t.RawFeedKey);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RawFeed");
        }
    }
}
