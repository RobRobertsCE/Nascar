using NascarApi.Models.Points;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NascarApi
{
    public class PointsFeedProcessor : FeedProcessor<PointsModel>
    {
        public PointsFeedProcessor(int season_id, int series_id, int race_id)
            : base(season_id, series_id, race_id)
        {
            
        }

        public override void ProcessModel(PointsModel model)
        {
            throw new NotImplementedException();
        }
    }
}
