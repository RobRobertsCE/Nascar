using System;

namespace Nascar.Web
{
    public class FeedEventArgs
       : EventArgs
    {
        public DateTime Arrived { get; protected internal set; }
    }
}
