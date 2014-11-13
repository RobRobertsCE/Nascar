using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nascar.Api.Models;

namespace Nascar.Api
{
    public class SeriesUrlManager
    {       
        const string CupFeedUrl = @"http://www.nascar.com/live/feeds/series_1/4317/live_feed.json{0}";
        const string XFinityFeedUrl = @"http://www.nascar.com/live/feeds/series_2/4325/live_feed.json{0}";
        const string TruckFeedUrl = @"http://www.nascar.com/live/feeds/series_3/4372/live_feed.json{0}";

        const string SeriesFeedUrlTemplate = @"http://www.nascar.com/live/feeds/series_{0}/{1}/live_feed.json";
        
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

        public static string GetSeriesFeedUrl(SeriesName series, int raceId)
        {
            string feedUrl = string.Empty;
            int seriesId;
            switch (series)
            {
                case SeriesName.Cup:
                    {
                        seriesId = 1;
                        break;
                    }
                case SeriesName.XFinity:
                    {
                        seriesId = 2;
                        break;
                    }
                case SeriesName.Truck:
                    {
                        seriesId = 3;
                        break;
                    }
                default:
                    {
                        throw new ArgumentException("series");
                    }
            }
            feedUrl = String.Format(SeriesFeedUrlTemplate, seriesId, raceId) + "{0}";
            return feedUrl;
        }
    }
}
