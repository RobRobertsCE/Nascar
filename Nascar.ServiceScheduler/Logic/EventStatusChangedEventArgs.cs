using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nascar.ServiceScheduler.Logic
{
    public class EventStatusChangedEventArgs
       : EventArgs
    {
        public int scheduled_event_id;
        public string new_status;
        public string old_status;
    }
}
