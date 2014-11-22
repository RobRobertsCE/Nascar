namespace NascarApi.Processors
{
    using NascarApi.Models.Qualifying;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NascarApi.Models;

    public class QualifyingFeedProcessor : FeedProcessor<QualifyingModel>
    {
        public override FeedFormat FeedFormat
        {
            get
            {
                return FeedFormat.Qualifying;
            }
        }

        public QualifyingFeedProcessor(int season_id, int series_id, int race_id)
            : base(season_id, series_id, race_id)
        {

        }

        protected override void BeginProcessAsync(QualifyingModel model)
        {

        }
    }
}
