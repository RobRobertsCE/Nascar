using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Net;
using Nascar.Api.Models;

namespace Nascar.Api
{    
    public class LiveFeedClient 
        : ClientBase, IFeedClient, IDisposable
    {       
        public LiveFeedClient(SeriesName series, int raceId)
            : base(series, raceId)
        { }

        public override string GetData()
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

        void Dispose()
        {
            base.Dispose();
        }
    }
}
