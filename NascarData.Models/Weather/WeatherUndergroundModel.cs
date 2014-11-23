﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NascarApi.Models.Weather
{
    public class WeatherUndergroundModel : IApiModel
    {
        public ResponseModel response { get; set; }
        public CurrentObservationModel current_observation { get; set; }
    }

    // {"response":{"version":"0.1","termsofService":"http://www.wunderground.com/weather/api/d/terms.html","features":{"conditions":1}},"current_observation":{"image":{"url":"http://icons.wxug.com/graphics/wu2/logo_130x80.png","title":"Weather Underground","link":"http://www.wunderground.com"},"display_location":{"full":"Martinsville, VA","city":"Martinsville","state":"VA","state_name":"Virginia","country":"US","country_iso3166":"US","zip":"24112","magic":"1","wmo":"99999","latitude":"36.68505096","longitude":"-79.86512756","elevation":"314.00000000"},"observation_location":{"full":"Patrick Henry Mall Area, Martinsville, Virginia","city":"Patrick Henry Mall Area, Martinsville","state":"Virginia","country":"US","country_iso3166":"US","latitude":"36.687080","longitude":"-79.858276","elevation":"1020 ft"},"estimated":{},"station_id":"KVAMARTI4","observation_time":"Last Updated on October 25, 11:45 PM EDT","observation_time_rfc822":"Sat, 25 Oct 2014 23:45:50 -0400","observation_epoch":"1414295150","local_time_rfc822":"Sat, 25 Oct 2014 23:58:17 -0400","local_epoch":"1414295897","local_tz_short":"EDT","local_tz_long":"America/New_York","local_tz_offset":"-0400","weather":"Clear","temperature_string":"59.9 F (15.5 C)","temp_f":59.9,"temp_c":15.5,"relative_humidity":"68%","wind_string":"Calm","wind_dir":"SW","wind_degrees":234,"wind_mph":0.0,"wind_gust_mph":"2.0","wind_kph":0,"wind_gust_kph":"3.2","pressure_mb":"1012","pressure_in":"29.90","pressure_trend":"-","dewpoint_string":"49 F (9 C)","dewpoint_f":49,"dewpoint_c":9,"heat_index_string":"NA","heat_index_f":"NA","heat_index_c":"NA","windchill_string":"NA","windchill_f":"NA","windchill_c":"NA","feelslike_string":"59.9 F (15.5 C)","feelslike_f":"59.9","feelslike_c":"15.5","visibility_mi":"10.0","visibility_km":"16.1","solarradiation":"--","UV":"0","precip_1hr_string":"0.00 in ( 0 mm)","precip_1hr_in":"0.00","precip_1hr_metric":" 0","precip_today_string":"0.00 in (0 mm)","precip_today_in":"0.00","precip_today_metric":"0","icon":"clear","icon_url":"http://icons.wxug.com/i/c/k/nt_clear.gif","forecast_url":"http://www.wunderground.com/US/VA/Martinsville.html","history_url":"http://www.wunderground.com/weatherstation/WXDailyHistory.asp?ID=KVAMARTI4","ob_url":"http://www.wunderground.com/cgi-bin/findweather/getForecast?query=36.687080,-79.858276","nowcast":""}}
}
