using NascarApi.Models.Qualifying;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NascarApi
{
    public class QualifyingFeedProcessor : FeedProcessor<QualifyingModel>
    {
        public QualifyingFeedProcessor(int season_id, int series_id, int race_id)
            : base(season_id, series_id, race_id)
        {
            
        }

        public override void ProcessModel(QualifyingModel model)
        {
            throw new NotImplementedException();
        }
    }
}
