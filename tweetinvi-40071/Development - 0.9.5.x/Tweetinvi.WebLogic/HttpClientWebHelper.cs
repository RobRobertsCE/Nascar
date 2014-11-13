using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Tweetinvi.Core;
using Tweetinvi.WebLogic.Utils;

namespace Tweetinvi.WebLogic
{
    public interface IHttpClientWebHelper
    {
        HttpClient GenerateHttpClientFromWebRequest(WebRequest webRequest);
        HttpResponseMessage GetResponseMessageFromWebRequest(WebRequest webRequest);

        Task<HttpResponseMessage> GetResponseMessageFromWebRequestAsync(WebRequest webRequest);
    }

    public class HttpClientWebHelper : IHttpClientWebHelper
    {
        private readonly ITweetinviSettingsAccessor _tweetinviSettingsAccessor;

        public HttpClientWebHelper(ITweetinviSettingsAccessor tweetinviSettingsAccessor)
        {
            _tweetinviSettingsAccessor = tweetinviSettingsAccessor;
        }

        public HttpClient GenerateHttpClientFromWebRequest(WebRequest webRequest)
        {
            var handler = new HttpClientHandler
            {
                UseCookies = false,
                UseDefaultCredentials = false,
            };

            if (!string.IsNullOrEmpty(_tweetinviSettingsAccessor.ProxyURL))
            {
                handler.Proxy = new WebProxy(_tweetinviSettingsAccessor.ProxyURL);
                handler.UseProxy = true;
            }

            var httpClient = new HttpClient(handler);

            var webRequestHeaders = webRequest.Headers;
            foreach (var headerKey in webRequestHeaders.AllKeys)
            {
                httpClient.DefaultRequestHeaders.Add(headerKey, webRequestHeaders[headerKey]);
            }

            return httpClient;
        }

        public HttpResponseMessage GetResponseMessageFromWebRequest(WebRequest webRequest)
        {
            var requestTask = GetResponseMessageFromWebRequestAsync(webRequest);

            if (_tweetinviSettingsAccessor.WebRequestTimeout > 0)
            {
                var resultingTask = TaskEx.WhenAny(requestTask, TaskEx.Delay(_tweetinviSettingsAccessor.WebRequestTimeout)).Result;
                if (resultingTask == requestTask)
                {
                    return requestTask.Result;
                }

                throw new TimeoutException("The operation could not complete");
            }

            return requestTask.Result;
        }

        public async Task<HttpResponseMessage> GetResponseMessageFromWebRequestAsync(WebRequest webRequest)
        {
            var httpClient = GenerateHttpClientFromWebRequest(webRequest);
            var httpMethod = new HttpMethod(webRequest.Method);
            return await httpClient.SendAsync(new HttpRequestMessage(httpMethod, webRequest.RequestUri));
        }
    }
}