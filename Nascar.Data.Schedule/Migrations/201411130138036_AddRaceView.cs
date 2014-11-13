namespace Nascar.Data.Schedule
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRaceView : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RaceTrackAndSeries",
                c => new
                    {
                        race_id = c.Int(nullable: false),
                        track_id = c.Int(nullable: false),
                        track_name = c.String(),
                        series_id = c.Int(nullable: false),
                        series_name = c.String(),
                        race_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.race_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RaceTrackAndSeries");
        }
    }
}
