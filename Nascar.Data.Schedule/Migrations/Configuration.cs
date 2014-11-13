
namespace Nascar.Data.Schedule
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<ScheduleDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Nascar.Data.Schedule.ScheduleDbContext";
        }

        public void RunSeed(ScheduleDbContext context)
        {
            Seed(context);
        }

        protected override void Seed(ScheduleDbContext context)
        {
            try
            {


                context.Tracks.AddOrUpdate<Track>(
                    t => t.track_id,
                    new Track { track_id = 14, track_length = 0.533, track_name = "Bristol Motor Speedway" },
                    new Track { track_id = 22, track_length = 0.526, track_name = "Martinsville Speedway" },
                    new Track { track_id = 26, track_length = 0.75, track_name = "Richmond Int'l Raceway" },
                    new Track { track_id = 39, track_length = 1.5, track_name = "Chicagoland Speedway" },
                    new Track { track_id = 41, track_length = 1.5, track_name = "Kansas Speedway" },
                    new Track { track_id = 42, track_length = 1.5, track_name = "Las Vegas Motor Speedway" },
                    new Track { track_id = 43, track_length = 1.5, track_name = "Texas Motor Speedway" },
                    new Track { track_id = 61, track_length = 1.5, track_name = "Kentucky Speedway" },
                    new Track { track_id = 82, track_length = 2.66, track_name = "Talladega Superspeedway" },
                    new Track { track_id = 84, track_length = 1, track_name = "Phoenix International Raceway" },
                    new Track { track_id = 103, track_length = 1, track_name = "Dover Int'l Speedway" },
                    new Track { track_id = 111, track_length = 1.54, track_name = "Atlanta Motor Speedway" },
                    new Track { track_id = 133, track_length = 2, track_name = "Michigan Int'l Speedway" },
                    new Track { track_id = 157, track_length = 2.45, track_name = "Watkins Glen Int'l" },
                    new Track { track_id = 162, track_length = 1.5, track_name = "Charlotte Motor Speedway" },
                    new Track { track_id = 208, track_length = 0.5, track_name = "Eldora Speedway" },
                    new Track { track_id = 209, track_length = 2.459, track_name = "Canadian Tire Motorsport Park" }
                );

                context.SaveChanges();

                context.Series.AddOrUpdate<Series>(
                    s => s.series_id,
                    new Series { series_id = 1, series_name = "Sprint Cup Series" },
                    new Series { series_id = 2, series_name = "Nationwide Series" },
                    new Series { series_id = 3, series_name = "Camping World Truck Series" });

                context.SaveChanges();

                context.Sessions.AddOrUpdate<Session>(
                  s => s.session_id,
                  new Session { session_id = 1, session_name = "Practice" },
                  new Session { session_id = 2, session_name = "Qualifying" },
                  new Session { session_id = 3, session_name = "Race" });

                context.SaveChanges();

                context.Races.AddOrUpdate<Race>(
                    r => r.race_id,
                    new Race { race_id = 4306, series_id = 1, track_id = 133 },
                    new Race { race_id = 4307, series_id = 1, track_id = 14 },
                    new Race { race_id = 4308, series_id = 1, track_id = 111 },
                    new Race { race_id = 4309, series_id = 1, track_id = 26 },
                    new Race { race_id = 4310, series_id = 1, track_id = 39 },
                    new Race { race_id = 4312, series_id = 1, track_id = 103 },
                    new Race { race_id = 4313, series_id = 1, track_id = 41 },
                    new Race { race_id = 4314, series_id = 1, track_id = 162 },
                    new Race { race_id = 4315, series_id = 1, track_id = 82 },
                    new Race { race_id = 4316, series_id = 1, track_id = 22 },
                    new Race { race_id = 4317, series_id = 1, track_id = 43 },
                    new Race { race_id = 4320, series_id = 1, track_id = 84 },
                    new Race { race_id = 4341, series_id = 2, track_id = 157 },
                    new Race { race_id = 4343, series_id = 2, track_id = 14 },
                    new Race { race_id = 4344, series_id = 2, track_id = 111 },
                    new Race { race_id = 4345, series_id = 2, track_id = 26 },
                    new Race { race_id = 4346, series_id = 2, track_id = 39 },
                    new Race { race_id = 4347, series_id = 2, track_id = 61 },
                    new Race { race_id = 4348, series_id = 2, track_id = 103 },
                    new Race { race_id = 4349, series_id = 2, track_id = 41 },
                    new Race { race_id = 4350, series_id = 2, track_id = 162 },
                    new Race { race_id = 4351, series_id = 2, track_id = 43 },
                    new Race { race_id = 4352, series_id = 2, track_id = 84 },
                    new Race { race_id = 4363, series_id = 3, track_id = 208 },
                    new Race { race_id = 4365, series_id = 3, track_id = 133 },
                    new Race { race_id = 4366, series_id = 3, track_id = 14 },
                    new Race { race_id = 4367, series_id = 3, track_id = 209 },
                    new Race { race_id = 4369, series_id = 3, track_id = 39 },
                    new Race { race_id = 4370, series_id = 3, track_id = 42 },
                    new Race { race_id = 4371, series_id = 3, track_id = 82 },
                    new Race { race_id = 4372, series_id = 3, track_id = 22 },
                    new Race { race_id = 4373, series_id = 3, track_id = 43 },
                    new Race { race_id = 4374, series_id = 3, track_id = 84 });

                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
