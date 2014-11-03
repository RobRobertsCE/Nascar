namespace Nascar.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class session_id_identity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LiveFeed", "session_id", "dbo.Session");
            DropPrimaryKey("dbo.Session");
            AlterColumn("dbo.Session", "session_id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Session", "session_id");
            AddForeignKey("dbo.LiveFeed", "session_id", "dbo.Session", "session_id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LiveFeed", "session_id", "dbo.Session");
            DropPrimaryKey("dbo.Session");
            AlterColumn("dbo.Session", "session_id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Session", "session_id");
            AddForeignKey("dbo.LiveFeed", "session_id", "dbo.Session", "session_id", cascadeDelete: true);
        }
    }
}
