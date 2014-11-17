using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NascarData.Models.Leaderboard
{
    public class WeatherInfoModel
    {
        public string icon { get; set; }
        public double temp_f { get; set; }
        public string icon_url { get; set; }
        public string weather { get; set; }
        public string forecast_url { get; set; }
        public string ob_url { get; set; }
        public string history_url { get; set; }
    }

    // "weatherInfo":     {
    //    "icon": "clear",
    //    "temp_f": 80.7,
    //    "icon_url": "http://icons.wxug.com/i/c/k/clear.gif",
    //    "weather": "Clear",
    //    "forecast_url": "http://www.wunderground.com/US/FL/Homestead.html",
    //    "ob_url": "http://www.wunderground.com/cgi-bin/findweather/getForecast?query=25.468384,-80.518715",
    //    "history_url": "http://www.wunderground.com/weatherstation/WXDailyHistory.asp?ID=KFLHOMES5"
    //}
}
