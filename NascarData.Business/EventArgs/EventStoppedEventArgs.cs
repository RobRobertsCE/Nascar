using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NascarApi
{
    public class EventStoppedEventArgs : EventArgs
    {
        public int scheduled_event_id { get; set; }
        public int race_id { get; set; }
    }
}
