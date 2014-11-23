using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NascarApi.Models.Points
{
    public class PointsModel : IApiModel
    {
        public int bonus_points { get; set; }
        public string car_number { get; set; }
        public int delta_leader { get; set; }
        public int delta_next { get; set; }
        public string first_name { get; set; }
        public int driver_id { get; set; }
        public bool is_in_chase { get; set; }
        public string last_name { get; set; }
        public int membership_id { get; set; }
        public int points { get; set; }
        public int points_position { get; set; }
        public int points_earned_this_race { get; set; }
        public int wins { get; set; }
        public int top_5 { get; set; }
        public int top_10 { get; set; }
        public int poles { get; set; }
    }
}
