using System;
namespace Nascar.Data
{
    public interface ILiveFeedProcessor
    {
        void ProcessLiveFeed(Nascar.Models.LiveFeedModel model);
        void Display();
    }
}
