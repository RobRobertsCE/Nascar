using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nascar.Models;

namespace Nascar.Web
{
    class SeriesUrlManager
    {
        //const string CupFeedUrl = @"http://www.nascar.com/live/feeds/series_1/4315/live_feed.json{0}";
        const string CupFeedUrl = @"http://www.nascar.com/live/feeds/series_1/4316/live_feed.json{0}";
        const string XFinityFeedUrl = @"http://www.nascar.com/live/feeds/series_2/4315/live_feed.json{0}";
       // const string TruckFeedUrl = @"http://www.nascar.com/live/feeds/series_3/4371/live_feed.json{0}";
        const string TruckFeedUrl = @"http://www.nascar.com/live/feeds/series_3/4372/live_feed.json{0}";

        public static string GetSeriesFeedUrl(SeriesName series)
        {
            string feedUrl = string.Empty;

            switch (series)
            {
                case SeriesName.Cup:
                    {
                        feedUrl = CupFeedUrl;
                        break;
                    }
                case SeriesName.XFinity:
                    {
                        feedUrl = XFinityFeedUrl;
                        break;
                    }
                case SeriesName.Truck:
                    {
                        feedUrl = TruckFeedUrl;
                        break;
                    }
                default:
                    {
                        throw new ArgumentException("series");
                    }
            }

            return feedUrl;
        }
    }
}
