namespace NascarApi.Processors
{
    public interface IFeedProcessor<T>
    {
        event ProcessingCompleteDelegate ProcessingComplete;
        event ProcessingErrorDelegate ProcessingError;
        event ArchivingCompleteDelegate ArchivingComplete;

        int season_id { get; }
        int series_id { get; }
        int race_id { get; }
        int run_id { get; }

        void ProcessJson(string feedJson);
        void ProcessModel(T model);
        void ProcessModelAsync(T model);
    }
}
