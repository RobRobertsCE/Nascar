using System;
namespace Nascar.Api
{
    public interface ILiveFeedProcessor
    {
        void ProcessLiveFeed(Nascar.Models.LiveFeedModel model);
        void Display();
    }
}
