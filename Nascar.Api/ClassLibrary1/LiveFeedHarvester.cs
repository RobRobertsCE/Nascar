using Nascar.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nascar.Api
{
    public class LiveFeedHarvester : IApiFeedProcessor
    {
        private NascarDbContext _context = null;       

        public string LastFeedData { get; protected internal set; }

        public LiveFeedHarvester()
        {
            LastFeedData = String.Empty;
            _context = new NascarDbContext();
        }

        public void ProcessFeedData(string data)
        {
            if (this.LastFeedData == data) return;
            this.LastFeedData = data;
            _context.RawFeeds.Add(new RawFeed(data));
            _context.SaveChanges();
        }
    }
}
