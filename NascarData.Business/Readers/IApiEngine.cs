namespace NascarApi
{
    using NascarApi.Readers;

    public interface IApiEngine
    {
        event ApiEngineStartedDelegate ApiEngineStarted;
        event ApiEngineStoppedDelegate ApiEngineStopped;
        event ApiEngineErrorDelegate ApiFeedEngineError;
        event ApiResultDelegate ApiResult;

        ApiEngineState State { get; }

        void Start();
        void Stop();
    }
}
