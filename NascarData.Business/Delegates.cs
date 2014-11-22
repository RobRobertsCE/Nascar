using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NascarApi
{
    public delegate void EventFeedStartedDelegate(object sender, EventStartedEventArgs e);

    public delegate void EventFeedStoppedDelegate(object sender, EventStoppedEventArgs e);

    public delegate void ApiFeedEngineStartedDelegate(object sender, EventArgs e);

    public delegate void ApiFeedEngineStoppedDelegate(object sender, EventArgs e);

    public delegate void ApiFeedEngineErrorDelegate(object sender, Exception e);

    public delegate void LiveFeedEventHandler(object sender, LiveFeedEventArgs e);

    public delegate void LiveFeedRawDataHandler(object sender, string rawData);

    public delegate void LiveFeedDataLoadedHandler(object sender, EventArgs e);

    public delegate void LiveFeedStartedHandler(object sender, EventArgs e);

    public delegate void LiveFeedStoppedHandler(object sender, EventArgs e);
}
