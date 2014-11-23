namespace NascarApi.Processors
{
    using NascarApi.Models.Points;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NascarApi.Models;

    public class PointsFeedProcessor : FeedProcessor<PointsModel>
    {
        public override ApiFeedType FeedType
        {
            get
            {
                return ApiFeedType.LivePoints;
            }
        }

        public PointsFeedProcessor(int season_id, int series_id, int race_id)
            : base(season_id, series_id, race_id)
        {
            
        }

        protected override void BeginProcessAsync(PointsModel model)
        {

        }
    }
}
