using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NascarApi.Readers;

namespace NascarApi
{
    public delegate void EventFeedStartedDelegate(object sender, EventStartedEventArgs e);

    public delegate void EventFeedStoppedDelegate(object sender, EventStoppedEventArgs e);

    public delegate void ApiEngineStartedDelegate(object sender, EventArgs e);

    public delegate void ApiEngineStoppedDelegate(object sender, EventArgs e);

    public delegate void ApiEngineErrorDelegate(object sender, Exception e);


    public delegate void LiveFeedRawDataHandler(object sender, string rawData);

    public delegate void LiveFeedDataLoadedHandler(object sender, EventArgs e);

    public delegate void LiveFeedStartedHandler(object sender, EventArgs e);

    public delegate void LiveFeedStoppedHandler(object sender, EventArgs e);

    public delegate void ApiResultDelegate(object sender, ApiFeedType feedType, string jsonResult);
    public delegate void AsyncApiResultDelegate(object sender, string jsonResult);

    public delegate void ApiModelEventDelegate<T>(object sender, ApiModelEventArgs<T> e);    

    public delegate void LiveFeedEventDelegate(object sender, LiveFeedModelEventArgs e);
    public delegate void LeaderboardEventDelegate(object sender, LeaderboardModelEventArgs e);

}
