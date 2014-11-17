using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NascarData.Business
{
    public interface IFeedProcessor
    {
        int race_id { get; }
        int series_id { get;}

        void processFeedData(string feedData);
        void processFeedModel(NascarData.Models.LiveFeed.LiveFeedModel model);
    }
}
