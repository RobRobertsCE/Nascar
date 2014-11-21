﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NascarApi.Models.Weather
{
    public class ObservationLocationModel
    {
        public string full { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string country_iso3166 { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string elevation { get; set; }
    }
}
