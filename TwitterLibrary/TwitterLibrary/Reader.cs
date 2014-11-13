using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TwitterLibrary
{
    public class TwitterReader
    {
        public void ReadHttpWebRequest()
        {
            //Oauth Keys (Replace with values that are obtained from registering the application
            var oauth_consumer_key = Provider.ApiKey;
            var oauth_consumer_secret = Provider.ApiSecret;
            //Token URL
            var oauth_url = "https://api.twitter.com/oauth2/token";
            var headerFormat = "Basic {0}";
            var authHeader = string.Format(headerFormat,
            Convert.ToBase64String(Encoding.UTF8.GetBytes(Uri.EscapeDataString(oauth_consumer_key) + ":" +
            Uri.EscapeDataString((oauth_consumer_secret)))
            ));

            var postBody = "grant_type=client_credentials";

            ServicePointManager.Expect100Continue = false;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(oauth_url);
            request.Headers.Add("Authorization", authHeader);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";

            using (Stream stream = request.GetRequestStream())
            {
                byte[] content = ASCIIEncoding.ASCII.GetBytes(postBody);
                stream.Write(content, 0, content.Length);
            }

            request.Headers.Add("Accept-Encoding", "gzip");
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            Stream responseStream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
            using (var reader = new StreamReader(responseStream))
            {

                JavaScriptSerializer js = new JavaScriptSerializer();
                var objText = reader.ReadToEnd();
                JObject o = JObject.Parse(objText);
                Console.WriteLine(objText);
            }
        }

        public void ReadHttpClient()
        {
            //Oauth Keys (Replace with values that are obtained from registering the application
            var oauth_consumer_key = Provider.ApiKey;
            var oauth_consumer_secret = Provider.ApiSecret;
            //Token URL
            var oauth_url = "https://api.twitter.com/oauth2/token";

            var postBody = "grant_type=client_credentials";

            var client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Basic",
                Convert.ToBase64String(
                    Encoding.ASCII.GetBytes(
                        string.Format("{0}:{1}", Uri.EscapeDataString(oauth_consumer_key),
                                      Uri.EscapeDataString(oauth_consumer_secret)))));

            client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Encoding", "gzip");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Host", "api.twitter.com");

            var content = new StringContent(postBody);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            HttpResponseMessage response = client.PostAsync(oauth_url, content).Result;
            response.EnsureSuccessStatusCode();

            using (var responseStream = response.Content.ReadAsStreamAsync())
            using (var decompressedStream = new GZipStream(responseStream.Result, CompressionMode.Decompress))
            using (var streamReader = new StreamReader(decompressedStream))
            {
                var rawJWt = streamReader.ReadToEnd();
                var jwt = JsonConvert.DeserializeObject(rawJWt);
                Console.WriteLine(rawJWt);
            }
        }

        public string DoIt()
        {
            // oauth application keys
            //oauth_token = "our API Key";
            //oauth_token_secret = "Your API Secret Key";
            var oauth_token = Provider.AccessToken;
            var oauth_token_secret = Provider.AccessTokenSecret;

            var oauth_consumer_key = Provider.ApiKey;
            var oauth_consumer_secret = Provider.ApiSecret;

            // oauth implementation details
            var oauth_version = "1.0";
            var oauth_signature_method = "HMAC-SHA1";

            // unique request details
            var oauth_nonce = Convert.ToBase64String(
            new ASCIIEncoding().GetBytes(DateTime.Now.Ticks.ToString()));
            var timeSpan = DateTime.UtcNow
            - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            var oauth_timestamp = Convert.ToInt64(timeSpan.TotalSeconds).ToString();

            // message api details
            //var status = "Updating status via REST API if this works";

            //var resource_url = "https://api.twitter.com/1.1/followers/ids.json";
            //var resource_url = "https://api.twitter.com/1.1/favorites/list.json";
            //var resource_url = "https://api.twitter.com/1.1/statuses/retweets/21947795900469248.json";
            //var screen_name = "twitterapi";

            var resource_url = "https://api.twitter.com/1.1/statuses/user_timeline.json";
            var screen_name = "GoDuke4382";// "name of Twitter Acoount (eg: seenu)";

            // create oauth signature
            var baseFormat = "oauth_consumer_key={0}&oauth_nonce={1}&oauth_signature_method={2}" +
            "&oauth_timestamp={3}&oauth_token={4}&oauth_version={5}&screen_name={6}";

            var baseString = string.Format(baseFormat,
            oauth_consumer_key,
            oauth_nonce,
            oauth_signature_method,
            oauth_timestamp,
            oauth_token,
            oauth_version,
            Uri.EscapeDataString(screen_name)
            );

            baseString = string.Concat("GET&", Uri.EscapeDataString(resource_url), "&", Uri.EscapeDataString(baseString));

            var compositeKey = string.Concat(Uri.EscapeDataString(oauth_consumer_secret),
            "&", Uri.EscapeDataString(oauth_token_secret));

            string oauth_signature;
            using (HMACSHA1 hasher = new HMACSHA1(ASCIIEncoding.ASCII.GetBytes(compositeKey)))
            {
                oauth_signature = Convert.ToBase64String(
                hasher.ComputeHash(ASCIIEncoding.ASCII.GetBytes(baseString)));
            }

            // create the request header
            var headerFormat = "OAuth oauth_nonce=\"{0}\", oauth_signature_method=\"{1}\", " +
            "oauth_timestamp=\"{2}\", oauth_consumer_key=\"{3}\", " +
            "oauth_token=\"{4}\", oauth_signature=\"{5}\", " +
            "oauth_version=\"{6}\"";

            var authHeader = string.Format(headerFormat,
            Uri.EscapeDataString(oauth_nonce),
            Uri.EscapeDataString(oauth_signature_method),
            Uri.EscapeDataString(oauth_timestamp),
            Uri.EscapeDataString(oauth_consumer_key),
            Uri.EscapeDataString(oauth_token),
            Uri.EscapeDataString(oauth_signature),
            Uri.EscapeDataString(oauth_version)
            );


            // make the request

            ServicePointManager.Expect100Continue = false;

            var postBody = "screen_name=" + Uri.EscapeDataString(screen_name);//
            resource_url += "?" + postBody;
            Console.WriteLine(resource_url);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(resource_url);
            request.Headers.Add("Authorization", authHeader);
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";

            WebResponse response = request.GetResponse();
            string responseData = new StreamReader(response.GetResponseStream()).ReadToEnd();
            response.Close();
            return responseData;
        }
    }
}
