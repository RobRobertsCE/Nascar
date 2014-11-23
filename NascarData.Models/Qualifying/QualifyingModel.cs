using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NascarApi.Models.Qualifying
{
    public class QualifyingModel : IApiModel
    {
        public int race_id { get; set; }
        public int series_id { get; set; }
        public List<QualifyingResultModel> qualifying_results { get; set; }
    }
}
