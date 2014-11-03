namespace Nascar.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRun2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Session", "race_id", "dbo.Race");
            DropForeignKey("dbo.LiveFeed", "session_id", "dbo.Session");
            DropIndex("dbo.LiveFeed", new[] { "session_id" });
            DropIndex("dbo.Session", new[] { "race_id" });
            CreateTable(
                "dbo.Run",
                c => new
                    {
                        race_id = c.Int(nullable: false),
                        run_id = c.Int(nullable: false),
                        run_name = c.String(),
                        run_type = c.Int(nullable: false),
                        laps_in_race = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.race_id, t.run_id })
                .ForeignKey("dbo.Race", t => t.race_id, cascadeDelete: true)
                .Index(t => t.race_id);
            
            AddColumn("dbo.LiveFeed", "race_id", c => c.Int(nullable: false));
            AddColumn("dbo.LiveFeed", "run_id", c => c.Int(nullable: false));
            CreateIndex("dbo.LiveFeed", new[] { "race_id", "run_id" });
            AddForeignKey("dbo.LiveFeed", new[] { "race_id", "run_id" }, "dbo.Run", new[] { "race_id", "run_id" }, cascadeDelete: true);
            DropColumn("dbo.LiveFeed", "session_id");
            DropTable("dbo.Session");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Session",
                c => new
                    {
                        session_id = c.Int(nullable: false, identity: true),
                        run_id = c.Int(nullable: false),
                        session_name = c.String(),
                        session_type = c.Int(nullable: false),
                        laps_in_session = c.Int(nullable: false),
                        race_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.session_id);
            
            AddColumn("dbo.LiveFeed", "session_id", c => c.Int(nullable: false));
            DropForeignKey("dbo.LiveFeed", new[] { "race_id", "run_id" }, "dbo.Run");
            DropForeignKey("dbo.Run", "race_id", "dbo.Race");
            DropIndex("dbo.Run", new[] { "race_id" });
            DropIndex("dbo.LiveFeed", new[] { "race_id", "run_id" });
            DropColumn("dbo.LiveFeed", "run_id");
            DropColumn("dbo.LiveFeed", "race_id");
            DropTable("dbo.Run");
            CreateIndex("dbo.Session", "race_id");
            CreateIndex("dbo.LiveFeed", "session_id");
            AddForeignKey("dbo.LiveFeed", "session_id", "dbo.Session", "session_id", cascadeDelete: true);
            AddForeignKey("dbo.Session", "race_id", "dbo.Race", "race_id", cascadeDelete: true);
        }
    }
}
