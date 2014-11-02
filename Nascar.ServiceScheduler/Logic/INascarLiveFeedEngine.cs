using System;
namespace Nascar.ServiceScheduler.Logic
{
    public interface INascarLiveFeedEngine
    {
        void Start();
        void Stop();
    }
}
