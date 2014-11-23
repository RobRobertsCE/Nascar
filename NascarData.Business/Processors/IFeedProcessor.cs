namespace NascarApi.Processors
{
    public interface IFeedProcessor
    {
        int run_id { get; }
        void ProcessJson(string feedJson);
    }
    public interface IFeedProcessorT<T> : IFeedProcessor, IFeed
    {              
        void ProcessModel(T model);
        void ProcessModelAsync(T model);
    }
}
