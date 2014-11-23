namespace NascarApi.Readers
{
    using System;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Threading;

    /// <summary>
    /// Provides access to a NASCAR API Feed for a specific series event.
    /// </summary>
    public abstract class ApiClient : IApiClient
    {
#if DEBUG
        private bool TEST_MODE = false;
        private bool TEST_ERROR_MODE = false;
#endif
        #region events
        /// <summary>
        /// Fires when the json string is received from the api.
        /// </summary>
        public event ApiResultDelegate DataReceived;
        protected virtual void OnDataReceived(string json)
        {
            if (null != DataReceived)
                DataReceived.Invoke(this, this.Feed, json);
        }
        #endregion

        #region constants
        const string CharacterList = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        const int DEFAULT_RANDOM_LENGTH = 10;
        #endregion

        #region fields
        ApiAsyncClient asyncClient = null;
        #endregion

        #region public properties
        public SeriesType Series { get; protected set; }
        public int RaceId { get; protected set; }
        public ApiFeedType Feed { get; protected set; }
        #endregion

        #region protected properties
        protected virtual string FeedUrl { get; private set; }
        #endregion

        #region ctor
        public ApiClient(SeriesType seriesType, int raceId, int season, SessionType sessionType)
        {
            this.Feed = ApiFeedType.Leaderboard;
            this.Series = seriesType;
            this.RaceId = raceId;

            this.FeedUrl = ApiUrlManager.GetLeaderboardApiUrl(seriesType, raceId, season.ToString(), sessionType);

            asyncClient = new ApiAsyncClient();
            asyncClient.AsyncCallComplete += asyncClient_AsyncCallComplete;
        }
        public ApiClient(SeriesType seriesType, int raceId, ApiFeedType feedType)
        {
            this.Feed = feedType;
            this.Series = seriesType;
            this.RaceId = raceId;

            if (feedType == ApiFeedType.Leaderboard)
                throw new Exception("Cant use for Leaderboard feed!");

            this.FeedUrl = ApiUrlManager.GetApiUrl(feedType, seriesType, raceId);

            asyncClient = new ApiAsyncClient();
            asyncClient.AsyncCallComplete += asyncClient_AsyncCallComplete;
        }
        #endregion

        #region ExceptionHandler
        protected virtual void ExceptionHandler(Exception exception)
        {
            Console.WriteLine(exception.Message);
            throw exception;
        }
        #endregion

        #region GetData
        public virtual string GetData()
        {
            string url = GetUrl();
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "text/json";
            httpWebRequest.Method = "GET";
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                return streamReader.ReadToEnd();
            }
        }
        #endregion

        #region BeginGetDataAsync
        public virtual void BeginGetDataAsync()
        {
#if DEBUG
            if (TEST_ERROR_MODE)
            {
                TestErrorMode();
                return;
            }
            if (TEST_MODE)
            {
                TestMode();
                return;
            }
#endif
            string url = GetUrl();
            asyncClient.BeginGetAsync(url);
        }
        void asyncClient_AsyncCallComplete(object sender, string jsonResponse)
        {
            this.OnDataReceived(jsonResponse);
        }
#if DEBUG
        private void TestErrorMode()
        {
            throw new Exception("FOO BABY!!1!11!11");
        }
        private void TestMode()
        {
            this.OnDataReceived(Properties.Resources.LiveFeedJson_1_4315);
            //asyncClient.BeginGetAsync(@"http://www.jayski.com");
        }
#endif
        #endregion

        #region protected methods
        protected string GetRandom(int length)
        {
            int randomLength = length == 0 ? DEFAULT_RANDOM_LENGTH : length;
            StringBuilder randomBuilder = new StringBuilder();
            Random randomGenerator = new Random();
            for (int i = 0; i < randomLength; i++)
            {
                int randomIdx = randomGenerator.Next(0, CharacterList.Length - 1);
                randomBuilder.Append(CharacterList.Substring(randomIdx, 1));
            }
            return String.Format("?random={0}", randomBuilder.ToString());
        }
        protected string GetUrl()
        {
            return string.Format("{0}{1}", FeedUrl, GetRandom(DEFAULT_RANDOM_LENGTH));
        }
        #endregion

        #region IDisposable Support
        public void Dispose()
        {
            if (null != asyncClient)
            {
                asyncClient.AsyncCallComplete -= asyncClient_AsyncCallComplete;
                asyncClient.Dispose();
            }
        }
        #endregion

        #region async support classes
        // The RequestState class passes data across async calls.
        class ApiRequestState
        {
            const int BufferSize = 1024;
            public StringBuilder RequestData;
            public byte[] BufferRead;
            public WebRequest Request;
            public Stream ResponseStream;
            // Create Decoder for appropriate enconding type.
            public Decoder StreamDecode = Encoding.UTF8.GetDecoder();

            public ApiRequestState()
            {
                BufferRead = new byte[BufferSize];
                RequestData = new StringBuilder(String.Empty);
                Request = null;
                ResponseStream = null;
            }
        }
        // ClientGetAsync issues the async request.
        class ApiAsyncClient : IDisposable
        {
            public event AsyncApiResultDelegate AsyncCallComplete;
            protected virtual void OnAsyncCallComplete(string jsonResponse)
            {
                if (null != AsyncCallComplete)
                    AsyncCallComplete.Invoke(this, jsonResponse);
            }

            public ManualResetEvent allDone = new ManualResetEvent(false);
            const int BUFFER_SIZE = 1024;

            public void BeginGetAsync(string apiEndpointUrl)
            {
                try
                {
                    // Get the URI from the command line.
                    Uri httpSite = new Uri(apiEndpointUrl);
                    Console.WriteLine(httpSite);


                    // Create the request object.
                    WebRequest wreq = WebRequest.Create(httpSite);

                    // Create the state object.
                    ApiRequestState rs = new ApiRequestState();

                    // Put the request into the state object so it can be passed around.
                    rs.Request = wreq;

                    // Issue the async request.
                    IAsyncResult r = (IAsyncResult)wreq.BeginGetResponse(
                       new AsyncCallback(RespCallback), rs);

                    // Wait until the ManualResetEvent is set so that the application 
                    // does not exit until after the callback is called.
                    allDone.WaitOne();

                    Console.WriteLine(rs.RequestData.ToString());

                    OnAsyncCallComplete(rs.RequestData.ToString());
                }
                catch (Exception ex)
                {
                    allDone.Set();
                    Console.WriteLine(ex.ToString());
                }
            }

            private void RespCallback(IAsyncResult ar)
            {
                try
                {
                    // Get the RequestState object from the async result.
                    ApiRequestState rs = (ApiRequestState)ar.AsyncState;

                    // Get the WebRequest from RequestState.
                    WebRequest req = rs.Request;

                    // Call EndGetResponse, which produces the WebResponse object
                    //  that came from the request issued above.
                    WebResponse resp = req.EndGetResponse(ar);

                    //  Start reading data from the response stream.
                    Stream ResponseStream = resp.GetResponseStream();

                    // Store the response stream in RequestState to read 
                    // the stream asynchronously.
                    rs.ResponseStream = ResponseStream;

                    //  Pass rs.BufferRead to BeginRead. Read data into rs.BufferRead
                    IAsyncResult iarRead = ResponseStream.BeginRead(rs.BufferRead, 0,
                       BUFFER_SIZE, new AsyncCallback(ReadCallBack), rs);
                }
                catch (Exception ex)
                {
                    allDone.Set();
                    Console.WriteLine(ex.ToString());
                }
            }

            private void ReadCallBack(IAsyncResult asyncResult)
            {
                try
                {
                    // Get the RequestState object from AsyncResult.
                    ApiRequestState rs = (ApiRequestState)asyncResult.AsyncState;

                    // Retrieve the ResponseStream that was set in RespCallback. 
                    Stream responseStream = rs.ResponseStream;

                    // Read rs.BufferRead to verify that it contains data. 
                    int read = responseStream.EndRead(asyncResult);
                    if (read > 0)
                    {
                        // Prepare a Char array buffer for converting to Unicode.
                        Char[] charBuffer = new Char[BUFFER_SIZE];

                        // Convert byte stream to Char array and then to String.
                        // len contains the number of characters converted to Unicode.
                        int len =
                           rs.StreamDecode.GetChars(rs.BufferRead, 0, read, charBuffer, 0);

                        String str = new String(charBuffer, 0, len);

                        // Append the recently read data to the RequestData stringbuilder
                        // object contained in RequestState.
                        rs.RequestData.Append(
                           Encoding.ASCII.GetString(rs.BufferRead, 0, read));

                        // Continue reading data until 
                        // responseStream.EndRead returns –1.
                        IAsyncResult ar = responseStream.BeginRead(
                           rs.BufferRead, 0, BUFFER_SIZE,
                           new AsyncCallback(ReadCallBack), rs);
                    }
                    else
                    {
                        if (rs.RequestData.Length > 0)
                        {
                            //  Display data to the console.
                            string strContent;
                            strContent = rs.RequestData.ToString();
                        }
                        // Close down the response stream.
                        responseStream.Close();
                        // Set the ManualResetEvent so the main thread can exit.
                        allDone.Set();
                    }
                }
                catch (Exception ex)
                {
                    allDone.Set();
                    Console.WriteLine(ex.ToString());
                }

                return;
            }

            public void Dispose()
            {
                if (null != allDone)
                {
                    allDone.Set();
                    allDone.Dispose();
                }
            }
        }
        #endregion
    }
}
