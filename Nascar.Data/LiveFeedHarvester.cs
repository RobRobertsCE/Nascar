using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nascar.Data
{
    public class LiveFeedHarvester
    {
        private NascarDbContext _context = null;
        protected internal virtual NascarDbContext Context
        {
            get
            {
                if (null == _context)
                    _context = new NascarDbContext();

                return _context;
            }
        }

        public string LastRawFeed { get; protected internal set; }
        
        public LiveFeedHarvester()
        {
            LastRawFeed = String.Empty;
            _context = new NascarDbContext();
        }

        public void ProcessLiveFeed(string data)
        {
            if (this.LastRawFeed == data) return;
            this.LastRawFeed = data;
            _context.RawFeeds.Add(new RawFeed(data));
            _context.SaveChanges();
        }

    }
}
