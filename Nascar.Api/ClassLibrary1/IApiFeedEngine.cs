using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nascar.Api
{
    public interface IApiFeedEngine
    {
        event EventFeedStartedDelegate EventFeedStarted;
        event EventFeedStoppedDelegate EventFeedStopped;

        event ApiFeedEngineStartedDelegate LiveFeedEngineStarted;
        event ApiFeedEngineStoppedDelegate LiveFeedEngineStopped;

        event ApiFeedEngineErrorDelegate LiveFeedEngineError;

        ApiEngineState State { get; }

        void Start();
        void Stop();
        void Pause();
    }
}
