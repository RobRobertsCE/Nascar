using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nascar.Models;

namespace Nascar.Api
{
      public abstract class ClientBase : Object, IDisposable 
    {
        const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        const int GET_RANDOM_CONST = 10;

        public SeriesName Series { get; protected internal set; }

        public int RaceId { get; protected internal set; }

        protected internal virtual string FeedUrl { get; protected set; }

        public ClientBase(SeriesName series)
        {
            this.Series = series;
            this.FeedUrl = SeriesUrlManager.GetSeriesFeedUrl(series);
        }

        public ClientBase(SeriesName series, int raceId)
        {
            this.Series = series;
            this.FeedUrl = SeriesUrlManager.GetSeriesFeedUrl(series, raceId);
        }

        protected internal string GetRandom(int length)
        {
            int randomLength = length == 0 ? 10 : length;
            
            StringBuilder randomBuilder = new StringBuilder();
            for (int i = 0; i < randomLength; i++)
            {
                randomBuilder.Append("");
            }
            return String.Format("?random={0}", randomBuilder.ToString());
        }

        protected internal string GetUrl()
        {
            return string.Format(FeedUrl, GetRandom(GET_RANDOM_CONST));
        }

        public abstract string GetData();

        public void Dispose()
        {
            
        }
    }
}
