using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nascar.ServiceScheduler.Logic
{
    public delegate void EventStatusChangedDelegate(object sender, EventStatusChangedEventArgs e);
    public delegate void LiveFeedEngineStartedDelegate(object sender, EventArgs e);
    public delegate void LiveFeedEngineStoppedDelegate(object sender, EventArgs e);
    public delegate void LiveFeedEngineErrorDelegate(object sender, Exception e);
}
