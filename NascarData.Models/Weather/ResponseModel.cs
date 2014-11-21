using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NascarApi.Models.Weather
{
    public class ResponseModel
    {
        public string version { get; set; }
        public string termsofService { get; set; }
        public FeaturesModel features { get; set; }
    } 
}
