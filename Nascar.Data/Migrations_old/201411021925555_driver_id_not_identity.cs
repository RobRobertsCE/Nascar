namespace Nascar.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class driver_id_not_identity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Vehicle", "driver_id", "dbo.Driver");
            DropPrimaryKey("dbo.Driver");
            AlterColumn("dbo.Driver", "driver_id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Driver", "driver_id");
            AddForeignKey("dbo.Vehicle", "driver_id", "dbo.Driver", "driver_id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicle", "driver_id", "dbo.Driver");
            DropPrimaryKey("dbo.Driver");
            AlterColumn("dbo.Driver", "driver_id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Driver", "driver_id");
            AddForeignKey("dbo.Vehicle", "driver_id", "dbo.Driver", "driver_id", cascadeDelete: true);
        }
    }
}
