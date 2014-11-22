using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NascarApi
{
    public class FeedEventArgs : EventArgs
    {
        public DateTime Arrived { get; protected internal set; }
    }
}
