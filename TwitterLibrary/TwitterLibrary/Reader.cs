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
using Tweetinvi.Core.Interfaces.oAuth;
using Tweetinvi.Core.Interfaces.Streaminvi;
using Tweetinvi.Credentials;
using Tweetinvi.Json;
using System.Diagnostics;
using Tweetinvi;
using Tweetinvi.Core.Enum;
using Tweetinvi.Core.Extensions;
using Tweetinvi.Core.Interfaces;
using Tweetinvi.Core.Interfaces.Controllers;
using Tweetinvi.Core.Interfaces.DTO;
using Tweetinvi.Core.Interfaces.Models;
using Tweetinvi.Core.Interfaces.Models.Parameters;
using Stream = Tweetinvi.Stream;

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

            using (System.IO.Stream stream = request.GetRequestStream())
            {
                byte[] content = ASCIIEncoding.ASCII.GetBytes(postBody);
                stream.Write(content, 0, content.Length);
            }

            request.Headers.Add("Accept-Encoding", "gzip");
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            System.IO.Stream responseStream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
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

        public void GetHomeTimeline()
        {
            var oauth_token = Provider.AccessToken;
            var oauth_token_secret = Provider.AccessTokenSecret;

            var oauth_consumer_key = Provider.ApiKey;
            var oauth_consumer_secret = Provider.ApiSecret;

            TwitterCredentials.SetCredentials(oauth_token, oauth_token_secret, oauth_consumer_key, oauth_consumer_secret);

            var loggedUser = User.GetLoggedUser();

            var homeTimelineTweets = loggedUser.GetHomeTimeline();
            foreach (var tweet in homeTimelineTweets)
            {
                Console.WriteLine(tweet.Text);
            }
        }

        private const string USER_SCREEN_NAME_TO_TEST = "GoDuke4382";
        public void Twitterinvi()
        {
            var oauth_token = Provider.AccessToken;
            var oauth_token_secret = Provider.AccessTokenSecret;

            var oauth_consumer_key = Provider.ApiKey;
            var oauth_consumer_secret = Provider.ApiSecret;

            //TwitterCredentials.SetCredentials("Access_Token", "Access_Token_Secret", "Consumer_Key", "Consumer_Secret");
            TwitterCredentials.SetCredentials(oauth_token, oauth_token_secret, oauth_consumer_key, oauth_consumer_secret);

            GenerateCredentialExamples();
            UserLiveFeedExamples();
            TweetExamples();
            UserExamples();
            LoggedUserExamples();
            TimelineExamples();
            MessageExamples();
            TweetListExamples();
            GeoExamples();
            SearchExamples();
            SavedSearchesExamples();
            RateLimitExamples();
            HelpExamples();
            JsonExamples();
            StreamExamples();
            OtherFeaturesExamples();

            Console.WriteLine(@"END");
            //Console.ReadLine();
        }

        #region Examples Store

        // ReSharper disable LocalizableElement
        // ReSharper disable UnusedMember.Local

        private void GenerateCredentialExamples()
        {
            // With captcha
            //CredentialsCreator_WithCaptcha_StepByStep("CONSUMER_KEY", "CONSUMER_SECRET");
            //CredentialsCreator_WithCaptcha_SingleStep(ConfigurationManager.AppSettings["token_ConsumerKey"], ConfigurationManager.AppSettings["token_ConsumerSecret"]);

            // With callback URL
            //CredentialsCreator_CreateFromRedirectedCallbackURL_StepByStep(ConfigurationManager.AppSettings["token_ConsumerKey"], ConfigurationManager.AppSettings["token_ConsumerSecret"]);
            //CredentialsCreator_CreateFromRedirectedCallbackURL_SingleStep(ConfigurationManager.AppSettings["token_ConsumerKey"], ConfigurationManager.AppSettings["token_ConsumerSecret"]);

            //CredentialsCreator_CreateFromRedirectedVerifierCode_StepByStep(ConfigurationManager.AppSettings["token_ConsumerKey"], ConfigurationManager.AppSettings["token_ConsumerSecret"]);
            //CredentialsCreator_CreateFromRedirectedVerifierCode_SingleStep(ConfigurationManager.AppSettings["token_ConsumerKey"], ConfigurationManager.AppSettings["token_ConsumerSecret"]);
        }

        private void UserLiveFeedExamples()
        {
            //Stream_UserStreamExample();
        }

        private void TweetExamples()
        {
            // Tweet_GetExistingTweet(210462857140252672);

            // Tweet_PublishTweet(String.Format("I love tweetinvi! ({0})", Guid.NewGuid()));
            // Tweet_PublishTweetWithImage("Uploadinvi?", "YOUR_FILE_PATH.png");

            // Tweet_PublishTweetInReplyToAnotherTweet(String.Format("I love tweetinvi! ({0})", Guid.NewGuid()), 392711547081854976);
            // Tweet_PublishTweetWithGeo(String.Format("I love tweetinvi! ({0})", Guid.NewGuid()));
            // Tweet_PublishTweetWithGeo_Coordinates(String.Format("I love tweetinvi! ({0})", Guid.NewGuid()));

            // Tweet_Destroy();

            // Tweet_GetRetweets(210462857140252672);
            // Tweet_PublishRetweet(210462857140252672);

            // Tweet_GenerateOEmbedTweet();

            // Tweet_DestroyRetweet(210462857140252672);

            // Tweet_SetTweetAsFavorite(392711547081854976);
        }

        private void UserExamples()
        {
            // User_GetCurrentUser();

            // User_GetUserFromName(1478171);
            // User_GetUserFromName(USER_SCREEN_NAME_TO_TEST);

            // User_GetFavorites(USER_SCREEN_NAME_TO_TEST);

            // User_GetFriends(USER_SCREEN_NAME_TO_TEST);
            // User_GetFriendIds(USER_SCREEN_NAME_TO_TEST);
            // User_GetFriendIdsUpTo(USER_SCREEN_NAME_TO_TEST, 10000);

            // User_GetFollowers(USER_SCREEN_NAME_TO_TEST);
            // User_GetFollowerIds(USER_SCREEN_NAME_TO_TEST);
            // User_GetFollowerIdsUpTo(USER_SCREEN_NAME_TO_TEST, 10000);

            // User_GetRelationshipBetween("tweetinvitest", USER_SCREEN_NAME_TO_TEST);

            // User_BlockUser(USER_SCREEN_NAME_TO_TEST);
            // User_DownloadProfileImage(USER_SCREEN_NAME_TO_TEST);
            // User_DownloadProfileImageAsync(USER_SCREEN_NAME_TO_TEST);
            // User_GenerateProfileImageStream(USER_SCREEN_NAME_TO_TEST);
            // User_GenerateProfileImageBitmap(USER_SCREEN_NAME_TO_TEST);
        }

        private void LoggedUserExamples()
        {
            //LoggedUser_GetMultipleRelationships();
            //LoggedUser_GetIncomingRequests();
            //LoggedUser_GetOutgoingRequests();
            //LoggedUser_FollowUser(USER_SCREEN_NAME_TO_TEST);
            //LoggedUser_UnFollowUser(USER_SCREEN_NAME_TO_TEST);
            //LoggedUser_UpdateFollowAuthorizationsForUser(USER_SCREEN_NAME_TO_TEST);
            //LoggedUser_GetLatestReceivedMessages();
            //LoggedUser_GetLatestSentMessages();
            //LoggedUser_GetAccountSettings();
        }
        // tweets I sent out...
        private void TimelineExamples()
        {
            Timeline_GetHomeTimeline();
            // Timeline_GetUserTimeline(USER_SCREEN_NAME_TO_TEST);
            // Timeline_GetMentionsTimeline();
        }

        private void MessageExamples()
        {
            // TokenUser_GetLatestReceivedMessages();
            // Message_GetMessageFromId(381069551028293633);
            // Message_PublishMessage(USER_SCREEN_NAME_TO_TEST);
            // Message_PublishMessageTo(USER_SCREEN_NAME_TO_TEST);
        }

        private void TweetListExamples()
        {
            TweetList_GetUserLists();
            // TweetList_CreateList();
            // TweetList_GetExistingListById(105601767);
            // TweetList_UpdateList(105601767);
            // TweetList_DestroyList(105601767);
             TweetList_GetTweetsFromList(105601767);
            // TweetList_GetMembersOfList(105601767);
        }

        private void GeoExamples()
        {
            // Geo_GetPlaceFromId("df51dec6f4ee2b2c");
            // Trends_GetTrendsFromWoeId(1);
        }

        private void SearchExamples()
        {
            // Search_SimpleTweetSearch();
            // Search_SearchTweet();
            // Search_FilteredSearch();
        }

        private void SavedSearchesExamples()
        {
            // SavedSearch_CreateSavedSearch("tweetinvi");
            // SavedSearch_GetSavedSearches();
            // SavedSearch_GetSavedSearch(307102135);
            // SavedSearch_DestroySavedSearch(307102135);
        }

        private void RateLimitExamples()
        {
            // GetCredentialsRateLimits();
            // GetCurrentCredentialsRateLimits();
        }

        private void HelpExamples()
        {
            // GetTwitterPrivacyPolicy();
        }

        private void JsonExamples()
        {
            // Json_GetJsonForAccountRequestExample();
            // Json_GetJsonForMessageRequestExample();
            // Json_GetJsonCursorRequestExample();
            // Json_GetJsonForGeoRequestExample();
            // Json_GetJsonForHelpRequestExample();
            // Json_GetJsonForSavedSearchRequestExample();
            // Json_GetJsonForTimelineRequestExample();
            // Json_GetJsonForTrendsRequestExample();
            // Json_GetJsonForTweetRequestExample();
            // Json_GetJsonForUserRequestExample();
        }

        private void StreamExamples()
        {
            Stream_SampleStreamExample();
            // Stream_FilteredStreamExample();
            // Stream_UserStreamExample();
            // SimpleStream_Events();
        }

        private void OtherFeaturesExamples()
        {
            //Exceptions_GetExceptionsInfo();
            //ManualQuery_Example();
        }

        #endregion

        #region Credentials and Login

        // Get credentials with captcha system
        // ReSharper disable UnusedMethodReturnValue.Local
        public IOAuthCredentials CredentialsCreator_WithCaptcha_StepByStep(string consumerKey, string consumerSecret)
        {
            var applicationCredentials = Tweetinvi.CredentialsCreator.GenerateApplicationCredentials(consumerKey, consumerSecret);
            var url = Tweetinvi.CredentialsCreator.GetAuthorizationURL(applicationCredentials);
            Console.WriteLine("Go on : {0}", url);
            Console.WriteLine("Enter the captch : ");
            var captcha = Console.ReadLine();

            var newCredentials = Tweetinvi.CredentialsCreator.GetCredentialsFromVerifierCode(captcha, applicationCredentials);
            Console.WriteLine("Access Token = {0}", newCredentials.AccessToken);
            Console.WriteLine("Access Token Secret = {0}", newCredentials.AccessTokenSecret);

            return newCredentials;
        }

        private static IOAuthCredentials CredentialsCreator_WithCaptcha_SingleStep(string consumerKey, string consumerSecret)
        {
            Func<string, string> retrieveCaptcha = url =>
            {
                Console.WriteLine("Go on : {0}", url);
                Console.WriteLine("Enter the captch : ");
                return Console.ReadLine();
            };

            var newCredentials = Tweetinvi.CredentialsCreator.GetCredentialsFromCaptcha(retrieveCaptcha, consumerKey, consumerSecret);
            Console.WriteLine("Access Token = {0}", newCredentials.AccessToken);
            Console.WriteLine("Access Token Secret = {0}", newCredentials.AccessTokenSecret);

            return newCredentials;
        }

        // Get credentials with callbackURL system
        private static IOAuthCredentials CredentialsCreator_CreateFromRedirectedCallbackURL_StepByStep(string consumerKey, string consumerSecret)
        {
            var applicationCredentials = Tweetinvi.CredentialsCreator.GenerateApplicationCredentials(consumerKey, consumerSecret);
            var url = Tweetinvi.CredentialsCreator.GetAuthorizationURLForCallback(applicationCredentials, "https://tweetinvi.codeplex.com");
            Console.WriteLine("Go on : {0}", url);
            Console.WriteLine("When redirected to your website copy and paste the URL: ");

            // Enter a value like: https://tweeetinvi.codeplex.com?oauth_token={tokenValue}&oauth_verifier={verifierValue}

            var callbackURL = Console.ReadLine();

            // Here we provide the entire URL where the user has been redirected
            var newCredentials = Tweetinvi.CredentialsCreator.GetCredentialsFromCallbackURL(callbackURL, applicationCredentials);
            Console.WriteLine("Access Token = {0}", newCredentials.AccessToken);
            Console.WriteLine("Access Token Secret = {0}", newCredentials.AccessTokenSecret);

            return newCredentials;
        }

        private static IOAuthCredentials CredentialsCreator_CreateFromRedirectedVerifierCode_StepByStep(string consumerKey, string consumerSecret)
        {
            var applicationCredentials = Tweetinvi.CredentialsCreator.GenerateApplicationCredentials(consumerKey, consumerSecret);
            var url = Tweetinvi.CredentialsCreator.GetAuthorizationURLForCallback(applicationCredentials, "https://tweetinvi.codeplex.com");
            Console.WriteLine("Go on : {0}", url);
            Console.WriteLine("When redirected to your website copy and paste the value of the oauth_verifier : ");

            // For the following redirection https://tweetinvi.codeplex.com?oauth_token=UR3eTEwDXFNhkMnjqz0oFbRauvAm4YhnF67KE6hO8Q&oauth_verifier=woXaKhpDtX6vhDVPl7TU6955qdQeH3cgz6xDvRZRA4A
            // Enter the value : woXaKhpDtX6vhDVPl7TU6955qdQeH3cgz6xDvRZRA4A

            var verifierCode = Console.ReadLine();

            // Here we only provide the verifier code
            var newCredentials = Tweetinvi.CredentialsCreator.GetCredentialsFromVerifierCode(verifierCode, applicationCredentials);
            Console.WriteLine("Access Token = {0}", newCredentials.AccessToken);
            Console.WriteLine("Access Token Secret = {0}", newCredentials.AccessTokenSecret);

            return newCredentials;
        }

        private static IOAuthCredentials CredentialsCreator_CreateFromRedirectedCallbackURL_SingleStep(string consumerKey, string consumerSecret)
        {
            Func<string, string> retrieveCallbackURL = url =>
            {
                Console.WriteLine("Go on : {0}", url);
                Console.WriteLine("When redirected to your website copy and paste the URL: ");

                // Enter a value like: https://tweeetinvi.codeplex.com?oauth_token={tokenValue}&oauth_verifier={verifierValue}

                var callbackURL = Console.ReadLine();
                return callbackURL;
            };

            // Here we provide the entire URL where the user has been redirected
            var newCredentials = Tweetinvi.CredentialsCreator.GetCredentialsFromCallbackURL_UsingRedirectedCallbackURL(retrieveCallbackURL, consumerKey, consumerSecret, "https://tweetinvi.codeplex.com");
            Console.WriteLine("Access Token = {0}", newCredentials.AccessToken);
            Console.WriteLine("Access Token Secret = {0}", newCredentials.AccessTokenSecret);

            return newCredentials;
        }

        private static IOAuthCredentials CredentialsCreator_CreateFromRedirectedVerifierCode_SingleStep(string consumerKey, string consumerSecret)
        {
            Func<string, string> retrieveVerifierCode = url =>
            {
                Console.WriteLine("Go on : {0}", url);
                Console.WriteLine("When redirected to your website copy and paste the value of the oauth_verifier : ");

                // For the following redirection https://tweetinvi.codeplex.com?oauth_token=UR3eTEwDXFNhkMnjqz0oFbRauvAm4YhnF67KE6hO8Q&oauth_verifier=woXaKhpDtX6vhDVPl7TU6955qdQeH3cgz6xDvRZRA4A
                // Enter the value : woXaKhpDtX6vhDVPl7TU6955qdQeH3cgz6xDvRZRA4A

                var verifierCode = Console.ReadLine();
                return verifierCode;
            };

            // Here we provide the entire URL where the user has been redirected
            var newCredentials = Tweetinvi.CredentialsCreator.GetCredentialsFromCallbackURL_UsingRedirectedVerifierCode(retrieveVerifierCode, consumerKey, consumerSecret, "https://tweetinvi.codeplex.com");
            Console.WriteLine("Access Token = {0}", newCredentials.AccessToken);
            Console.WriteLine("Access Token Secret = {0}", newCredentials.AccessTokenSecret);

            return newCredentials;
        }
        // ReSharper restore UnusedMethodReturnValue.Local


        #endregion

        #region Tweet

        private void Tweet_GetExistingTweet(long tweetId)
        {
            var tweet = Tweet.GetTweet(tweetId);
            Console.WriteLine(tweet.Text);
        }

        private void Tweet_PublishTweet(string text)
        {
            var newTweet = Tweet.CreateTweet(text);
            newTweet.Publish();

            Console.WriteLine(newTweet.IsTweetPublished);
        }

        private void Tweet_PublishTweetWithImage(string text, string filePath, string filepath2 = null)
        {
            byte[] file1 = File.ReadAllBytes(filePath);

            // Create a tweet with a single image
            var tweet = Tweet.CreateTweetWithMedia(text, file1);

            // !! MOST ACCOUNTS ARE LIMITED TO 1 File per Tweet     !!
            // !! IF YOU ADD 2 MEDIA, YOU MAY HAVE ONLY 1 PUBLISHED !!
            if (filepath2 != null)
            {
                byte[] file2 = File.ReadAllBytes(filepath2);
                tweet.AddMedia(file2);
            }

            tweet.Publish();
        }

        private void Tweet_PublishTweetInReplyToAnotherTweet(string text, long tweetIdtoRespondTo)
        {
            var newTweet = Tweet.CreateTweet(text);
            newTweet.PublishInReplyTo(tweetIdtoRespondTo);

            Console.WriteLine(newTweet.IsTweetPublished);
        }

        private void Tweet_PublishTweetWithGeo(string text)
        {
            const double longitude = -122.400612831116;
            const double latitude = 37.7821120598956;

            var newTweet = Tweet.CreateTweet(text);
            newTweet.PublishWithGeo(longitude, latitude);

            Console.WriteLine(newTweet.IsTweetPublished);
        }

        private void Tweet_PublishTweetWithGeo_Coordinates(string text)
        {
            const double longitude = -122.400612831116;
            const double latitude = 37.7821120598956;
            var coordinates = Geo.GenerateCoordinates(longitude, latitude);

            var newTweet = Tweet.CreateTweet(text);
            newTweet.PublishWithGeo(coordinates);

            Console.WriteLine(newTweet.IsTweetPublished);
        }

        private void Tweet_PublishRetweet(long tweetId)
        {
            var tweet = Tweet.GetTweet(tweetId);
            var retweet = tweet.PublishRetweet();

            Console.WriteLine("You retweeted : '{0}'", retweet.Text);
        }

        private void Tweet_DestroyRetweet(long tweetId)
        {
            var tweet = Tweet.GetTweet(tweetId);
            var retweet = tweet.PublishRetweet();

            retweet.Destroy();
        }

        private void Tweet_GetRetweets(long tweetId)
        {
            var tweet = Tweet.GetTweet(tweetId);
            IEnumerable<ITweet> retweets = tweet.GetRetweets();

            var firstRetweeter = retweets.ElementAt(0).Creator;
            var originalTweet = retweets.ElementAt(0).RetweetedTweet;
            Console.WriteLine("{0} retweeted : '{1}'", firstRetweeter.Name, originalTweet.Text);
        }

        private void Tweet_GenerateOEmbedTweet()
        {
            var newTweet = Tweet.CreateTweet("to be oembed");
            newTweet.Publish();

            var oembedTweet = newTweet.GenerateOEmbedTweet();

            Console.WriteLine("Oembed tweet url : {0}", oembedTweet.URL);

            if (newTweet.IsTweetPublished)
            {
                newTweet.Destroy();
            }
        }

        private void Tweet_Destroy()
        {
            var newTweet = Tweet.CreateTweet("to be destroyed!");
            newTweet.Publish();
            bool isTweetPublished = newTweet.IsTweetPublished;

            if (isTweetPublished)
            {
                newTweet.Destroy();
            }

            bool tweetDestroyed = newTweet.IsTweetDestroyed;
            Console.WriteLine("Has the tweet destroyed? {0}", tweetDestroyed);
        }

        private void Tweet_SetTweetAsFavorite(long tweetId)
        {
            var tweet = Tweet.GetTweet(tweetId);
            tweet.Favourite();
            Console.WriteLine("Is tweet now favourite? -> {0}", tweet.Favourited);
        }

        #endregion

        #region User

        private void User_GetCurrentUser()
        {
            var user = User.GetLoggedUser();
            Console.WriteLine(user.ScreenName);
        }

        private void User_GetUserFromId(long userId)
        {
            var user = User.GetUserFromId(userId);
            Console.WriteLine(user.ScreenName);
        }

        private void User_GetUserFromName(string userName)
        {
            var user = User.GetUserFromScreenName(userName);
            Console.WriteLine(user.Id);
        }

        private void User_GetFriendIds(string userName)
        {
            var user = User.GetUserFromScreenName(userName);
            var friendIds = user.GetFriendIds();

            Console.WriteLine("{0} has {1} friends, here are some of them :", user.Name, user.FriendsCount);
            foreach (var friendId in friendIds)
            {
                Console.WriteLine("- {0}", friendId);
            }
        }

        private void User_GetFriendIdsUpTo(string userName, int limit)
        {
            var user = User.GetUserFromScreenName(userName);
            var friendIds = user.GetFriendIds(limit);

            Console.WriteLine("{0} has {1} friends, here are some of them :", user.Name, user.FriendsCount);
            foreach (var friendId in friendIds)
            {
                Console.WriteLine("- {0}", friendId);
            }
        }

        private void User_GetFriends(string userName)
        {
            var user = User.GetUserFromScreenName(userName);
            var friends = user.GetFriends();

            Console.WriteLine("{0} has {1} friends, here are some of them :", user.Name, user.FriendsCount);
            foreach (var friend in friends)
            {
                Console.WriteLine("- {0}", friend.Name);
            }
        }

        private void User_GetFollowerIds(string userName)
        {
            var user = User.GetUserFromScreenName(userName);
            var followerIds = user.GetFollowerIds();

            Console.WriteLine("{0} has {1} followers, here are some of them :", user.Name, user.FollowersCount);
            foreach (var followerId in followerIds)
            {
                Console.WriteLine("- {0}", followerId);
            }
        }

        private void User_GetFollowerIdsUpTo(string userName, int limit)
        {
            var user = User.GetUserFromScreenName(userName);
            var followerIds = user.GetFollowerIds(limit);

            Console.WriteLine("{0} has {1} followers, here are some of them :", user.Name, user.FollowersCount);
            foreach (var followerId in followerIds)
            {
                Console.WriteLine("- {0}", followerId);
            }
        }

        private void User_GetFollowers(string userName)
        {
            var user = User.GetUserFromScreenName(userName);
            var followers = user.GetFollowers();

            Console.WriteLine("{0} has {1} followers, here are some of them :", user.Name, user.FollowersCount);
            foreach (var follower in followers)
            {
                Console.WriteLine("- {0}", follower.Name);
            }
        }

        private void User_GetRelationshipBetween(string sourceUserName, string targetUsername)
        {
            var sourceUser = User.GetUserFromScreenName(sourceUserName);
            var targetUser = User.GetUserFromScreenName(targetUsername);

            var relationship = sourceUser.GetRelationshipWith(targetUser);
            Console.WriteLine("You are{0} following {1}", relationship.Following ? "" : " not", targetUsername);
            Console.WriteLine("You are{0} being followed by {1}", relationship.FollowedBy ? "" : " not", targetUsername);
        }

        private void User_GetFavorites(string userName)
        {
            var user = User.GetUserFromScreenName(userName);
            var favorites = user.GetFavorites();

            Console.WriteLine("{0} has {1} favorites, here are some of them :", user.Name, user.FavouritesCount);
            foreach (var favoriteTweet in favorites)
            {
                Console.WriteLine("- {0}", favoriteTweet.Text);
            }
        }

        private void User_BlockUser(string userName)
        {
            var user = User.GetUserFromScreenName(userName);

            if (user.Block())
            {
                Console.WriteLine("{0} has been blocked.", userName);
            }
            else
            {
                Console.WriteLine("{0} has not been blocked.", userName);
            }
        }

        private void User_DownloadProfileImage(string userName)
        {
            var user = User.GetUserFromScreenName(userName);
            var stream = user.GetProfileImageStream(ImageSize.bigger);
            var fileStream = new FileStream(String.Format("{0}.jpg", user.Id), FileMode.Create);
            stream.CopyTo(fileStream);

            string assemblyPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            if (assemblyPath != null)
            {
                Process.Start(assemblyPath);
            }
        }

        #endregion

        #region LoggedUser

        private void LoggedUser_GetMultipleRelationships()
        {
            var loggedUser = User.GetLoggedUser();

            var user1 = User.GetUserFromScreenName("tweetinviapi");
            var user2 = User.GetUserFromScreenName(USER_SCREEN_NAME_TO_TEST);

            var userList = new List<IUser>
            {
                user1,
                user2
            };

            var relationships = loggedUser.GetRelationshipStatesWith(userList);
            foreach (var relationship in relationships)
            {
                Console.WriteLine("You are{0} following {1}", relationship.Following ? "" : " not", relationship.TargetScreenName);
                Console.WriteLine("You are{0} being followed by {1}", relationship.FollowedBy ? "" : " not", relationship.TargetScreenName);
                Console.WriteLine();
            }
        }

        private void LoggedUser_GetIncomingRequests()
        {
            var loggedUser = User.GetLoggedUser();
            var usersRequestingFriendship = loggedUser.GetUsersRequestingFriendship();

            foreach (var user in usersRequestingFriendship)
            {
                Console.WriteLine("{0} wants to follow you!", user.Name);
            }
        }

        private void LoggedUser_GetOutgoingRequests()
        {
            var loggedUser = User.GetLoggedUser();
            var usersRequestingFriendship = loggedUser.GetUsersYouRequestedToFollow();

            foreach (var user in usersRequestingFriendship)
            {
                Console.WriteLine("You sent a request to follow {0}!", user.Name);
            }
        }

        private void LoggedUser_FollowUser(string userName)
        {
            var loggedUser = User.GetLoggedUser();
            var userToFollow = User.GetUserFromScreenName(userName);

            if (loggedUser.FollowUser(userToFollow))
            {
                Console.WriteLine("You have successfully sent a request to follow {0}", userToFollow.Name);
            }
        }

        private void LoggedUser_UnFollowUser(string userName)
        {
            var loggedUser = User.GetLoggedUser();
            var userToFollow = User.GetUserFromScreenName(userName);

            if (loggedUser.UnFollowUser(userToFollow))
            {
                Console.WriteLine("You are not following {0} anymore", userToFollow.Name);
            }
        }

        private void LoggedUser_UpdateFollowAuthorizationsForUser(string userName)
        {
            var loggedUser = User.GetLoggedUser();
            var userToFollow = User.GetUserFromScreenName(userName);

            if (loggedUser.UpdateRelationshipAuthorizationsWith(userToFollow, false, false))
            {
                Console.WriteLine("Authorizations updated");
            }
        }

        private void LoggedUser_GetLatestReceivedMessages()
        {
            var loggedUser = User.GetLoggedUser();
            var messages = loggedUser.GetLatestMessagesReceived(20);

            Console.WriteLine("Messages Received : ");
            foreach (var message in messages)
            {
                Console.WriteLine("- '{0}'", message.Text);
            }
        }

        private void LoggedUser_GetLatestSentMessages()
        {
            var loggedUser = User.GetLoggedUser();
            var messages = loggedUser.GetLatestMessagesSent(20);

            Console.WriteLine("Messages Received : ");
            foreach (var message in messages)
            {
                Console.WriteLine("- '{0}'", message.Text);
            }
        }

        private void LoggedUser_GetAccountSettings()
        {
            var loggedUser = User.GetLoggedUser();
            var settings = loggedUser.GetAccountSettings();

            // Store information
            loggedUser.AccountSettings = settings;

            Console.WriteLine("{0} uses lang : {1}", settings.ScreenName, settings.Language);
        }

        #endregion

        #region Timeline

        private void Timeline_GetUserTimeline(string username)
        {
            var user = User.GetUserFromScreenName(username);

            var timelineTweets = user.GetUserTimeline();
            foreach (var tweet in timelineTweets)
            {
                Console.WriteLine(tweet.Text);
            }
        }

        private void Timeline_GetHomeTimeline()
        {
            var loggedUser = User.GetLoggedUser();

            var homeTimelineTweets = loggedUser.GetHomeTimeline();
            foreach (var tweet in homeTimelineTweets)
            {
                Console.WriteLine(tweet.Text);
            }
        }

        private void Timeline_GetMentionsTimeline()
        {
            var loggedUser = User.GetLoggedUser();

            var mentionsTimelineTweets = loggedUser.GetMentionsTimeline();
            foreach (var mention in mentionsTimelineTweets)
            {
                Console.WriteLine(mention.Text);
            }
        }

        #endregion

        #region Message

        private void Message_GetMessageFromId(long messageId)
        {
            var message = Message.GetExistingMessage(messageId);
            Console.WriteLine("Message from {0} to {1} : {2}", message.Sender, message.Receiver, message.Text);
        }

        private void Message_DestroyMessageFromId(long messageId)
        {
            var message = Message.GetExistingMessage(messageId);
            if (message.Destroy())
            {
                Console.WriteLine("Message successfully destroyed!");
            }
        }

        private void Message_PublishMessage(string username)
        {
            var recipient = User.GetUserFromScreenName(username);
            var message = Message.CreateMessage("piloupe", recipient);

            if (message.Publish())
            {
                Console.WriteLine("Message published : {0}", message.IsMessagePublished);
            }
        }

        private void Message_PublishMessageTo(string username)
        {
            var recipient = User.GetUserFromScreenName(username);
            var message = Message.CreateMessage("piloupe");

            if (message.PublishTo(recipient))
            {
                Console.WriteLine("Message published : {0}", message.IsMessagePublished);
            }
        }

        #endregion

        #region Lists

        private void TweetList_GetUserLists()
        {
            var currentUser = User.GetLoggedUser();
            var tweetLists = TweetList.GetUserLists(currentUser, true);

            tweetLists.ForEach(list => Console.WriteLine("- {0}", list.FullName));
        }

        private void TweetList_GetExistingListById(long listId)
        {
            var tweetList = TweetList.GetExistingList(listId);
            Console.WriteLine("You have retrieved the list {0}", tweetList.Name);
        }

        private void TweetList_CreateList()
        {
            var list = TweetList.CreateList("plop", PrivacyMode.Public, "description");
            Console.WriteLine("List '{0}' has been created!", list.FullName);
        }

        private void TweetList_UpdateList(long listId)
        {
            var list = TweetList.GetExistingList(listId);
            var updateParameters = TweetList.GenerateUpdateParameters();
            updateParameters.Name = "piloupe";
            updateParameters.Description = "pilouping description";
            updateParameters.PrivacyMode = PrivacyMode.Private;
            list.Update(updateParameters);

            Console.WriteLine("List new name is : {0}", list.Name);
        }

        private void TweetList_DestroyList(long listId)
        {
            var list = TweetList.GetExistingList(listId);
            var hasBeenDestroyed = list.Destroy();
            Console.WriteLine("Tweet {0} been destroyed.", hasBeenDestroyed ? "has" : "has not");
        }

        private void TweetList_GetTweetsFromList(long listId)
        {
            var list = TweetList.GetExistingList(listId);
            var tweets = list.GetTweets();

            tweets.ForEach(t => Console.WriteLine(t.Text));
        }

        private void TweetList_GetMembersOfList(long listId)
        {
            var list = TweetList.GetExistingList(listId);
            var members = list.GetMembers();

            members.ForEach(x => Console.WriteLine(x.Name));
        }

        #endregion

        #region Geo/Trends

        private void Geo_GetPlaceFromId(string placeId)
        {
            var geoController = TweetinviContainer.Resolve<IGeoController>();
            var place = geoController.GetPlaceFromId(placeId);
            Console.WriteLine(place.Name);
        }

        private void Trends_GetTrendsFromWoeId(long woeid)
        {
            var trendsController = TweetinviContainer.Resolve<ITrendsController>();
            var placeTrends = trendsController.GetPlaceTrendsAt(woeid);
            Console.WriteLine(placeTrends.woeIdLocations.First().Name);
        }

        #endregion

        #region Search

        private void Search_SimpleTweetSearch()
        {
            // IF YOU DO NOT RECEIVE ANY TWEET, CHANGE THE PARAMETERS!
            var tweets = Search.SearchTweets("#obama");

            foreach (var tweet in tweets)
            {
                Console.WriteLine("{0}", tweet.Text);
            }
        }

        private void Search_SearchTweet()
        {
            // IF YOU DO NOT RECEIVE ANY TWEET, CHANGE THE PARAMETERS!

            var searchParameter = Search.GenerateTweetSearchParameter("obama");

            searchParameter.SetGeoCode(Geo.GenerateCoordinates(-122.398720, 37.781157), 1, DistanceMeasure.Miles);
            searchParameter.Lang = Language.English;
            searchParameter.SearchType = SearchResultType.Popular;
            searchParameter.MaximumNumberOfResults = 100;
            searchParameter.Since = new DateTime(2013, 12, 1);
            searchParameter.Until = new DateTime(2013, 12, 11);
            searchParameter.SinceId = 399616835892781056;
            searchParameter.MaxId = 405001488843284480;

            var tweets = Search.SearchTweets(searchParameter);
            tweets.ForEach(t => Console.WriteLine(t.Text));
        }

        private void Search_FilteredSearch()
        {
            var searchParameter = Search.GenerateTweetSearchParameter("#tweetinvi");
            searchParameter.TweetSearchFilter = TweetSearchFilter.OriginalTweetsOnly;

            var tweets = Search.SearchTweets(searchParameter);
            tweets.ForEach(t => Console.WriteLine(t.Text));
        }

        private void Search_SearchAndGetMoreThan100Results()
        {
            var searchParameter = Search.GenerateTweetSearchParameter("us");
            searchParameter.MaximumNumberOfResults = 200;

            var tweets = Search.SearchTweets(searchParameter);
            tweets.ForEach(t => Console.WriteLine(t.Text));
        }

        #endregion

        #region Saved Searches

        private void SavedSearch_GetSavedSearches()
        {
            var loggedUser = User.GetLoggedUser();
            var savedSearches = loggedUser.GetSavedSearches();

            Console.WriteLine("Saved Searches");
            foreach (var savedSearch in savedSearches)
            {
                Console.WriteLine("- {0} => {1}", savedSearch.Name, savedSearch.Query);
            }
        }

        private void SavedSearch_CreateSavedSearch(string query)
        {
            var savedSearch = SavedSearch.CreateSavedSearch(query);
            Console.WriteLine("Saved Search created as : {0}", savedSearch.Name);
        }

        private void SavedSearch_GetSavedSearch(long searchId)
        {
            var savedSearch = SavedSearch.GetSavedSearch(searchId);
            Console.WriteLine("Saved searched query is : '{0}'", savedSearch.Query);
        }

        private void SavedSearch_DestroySavedSearch(long searchId)
        {
            var savedSearch = SavedSearch.GetSavedSearch(searchId);

            if (SavedSearch.DestroySavedSearch(savedSearch))
            {
                Console.WriteLine("You destroyed the search successfully!");
            }
        }

        #endregion

        #region Rate Limit / Help

        private void GetCurrentCredentialsRateLimits()
        {
            var tokenRateLimits = RateLimit.GetCurrentCredentialsRateLimits();

            Console.WriteLine("Remaning Requests for GetRate : {0}", tokenRateLimits.ApplicationRateLimitStatusLimit.Remaining);
            Console.WriteLine("Total Requests Allowed for GetRate : {0}", tokenRateLimits.ApplicationRateLimitStatusLimit.Limit);
            Console.WriteLine("GetRate limits will reset at : {0} local time", tokenRateLimits.ApplicationRateLimitStatusLimit.ResetDateTime.ToLongTimeString());
        }

        private void GetCredentialsRateLimits()
        {
            var credentials = TwitterCredentials.CreateCredentials("ACCESS_TOKEN", "ACCESS_TOKEN_SECRET", "CONSUMER_KEY", "CONSUMER_SECRET");
            var tokenRateLimits = RateLimit.GetCredentialsRateLimits(credentials);

            Console.WriteLine("Remaning Requests for GetRate : {0}", tokenRateLimits.ApplicationRateLimitStatusLimit.Remaining);
            Console.WriteLine("Total Requests Allowed for GetRate : {0}", tokenRateLimits.ApplicationRateLimitStatusLimit.Limit);
            Console.WriteLine("GetRate limits will reset at : {0} local time", tokenRateLimits.ApplicationRateLimitStatusLimit.ResetDateTime.ToLongTimeString());
        }

        private void GetTwitterPrivacyPolicy()
        {
            Console.WriteLine(Help.GetTwitterPrivacyPolicy());
        }

        #endregion

        #region Json

        private void Json_GetJsonForAccountRequestExample()
        {
            string jsonResponse = AccountJson.GetLoggedUserSettingsJson();
            Console.WriteLine(jsonResponse);
        }

        private void Json_GetJsonForMessageRequestExample()
        {
            IUser user = User.GetUserFromScreenName("tweetinviapi");
            string jsonResponse = MessageJson.PublishMessage("salut", user.UserDTO);

            Console.WriteLine(jsonResponse);
        }

        private void Json_GetJsonForGeoRequestExample()
        {
            var jsonResponse = GeoJson.GetPlaceFromId("df51dec6f4ee2b2c");
            Console.WriteLine(jsonResponse);
        }

        private void Json_GetJsonForHelpRequestExample()
        {
            var jsonResponse = HelpJson.GetTokenRateLimits();
            Console.WriteLine(jsonResponse);
        }

        private void Json_GetJsonForSavedSearchRequestExample()
        {
            var jsonResponse = SavedSearchJson.GetSavedSearches();
            Console.WriteLine(jsonResponse);
        }

        private void Json_GetJsonForTimelineRequestExample()
        {
            var jsonResponse = TimelineJson.GetHomeTimeline(2);
            Console.WriteLine(jsonResponse);
        }

        private void Json_GetJsonForTrendsRequestExample()
        {
            var jsonResponse = TrendsJson.GetTrendsAt(1);
            Console.WriteLine(jsonResponse);
        }

        private void Json_GetJsonForTweetRequestExample()
        {
            var tweet = Tweet.CreateTweet("Hello there!");
            var jsonResponse = TweetJson.PublishTweet(tweet);
            Console.WriteLine(jsonResponse);
        }

        private void Json_GetJsonForUserRequestExample()
        {
            var loggedUser = User.GetLoggedUser();
            var jsonResponse = UserJson.GetFriendIds(loggedUser);
            Console.WriteLine(jsonResponse.ElementAt(0));
        }

        private void Json_GetJsonCursorRequestExample()
        {
            // This query is a cursor query
            var jsonResponses = FriendshipJson.GetUserIdsRequestingFriendship();

            foreach (var jsonResponse in jsonResponses)
            {
                Console.WriteLine(jsonResponse);
            }
        }

        #endregion

        #region Stream

        private void SimpleStream_Events()
        {
            var stream = Stream.CreateTweetStream();
            stream.TweetReceived += (sender, args) => { };
            stream.TweetDeleted += (sender, args) => { };
            stream.TweetLocationInfoRemoved += (sender, args) => { };

            stream.TweetWitheld += (sender, args) => { };
            stream.UserWitheld += (sender, args) => { };


            stream.LimitReached += (sender, args) => { };
            stream.DisconnectMessageReceived += (sender, args) => { };
            stream.WarningFallingBehindDetected += (sender, args) => { };

            stream.UnmanagedEventReceived += (sender, args) => { };
        }

        private void Stream_SampleStreamExample()
        {
            var stream = Stream.CreateSampleStream();
            stream.TweetReceived += (sender, args) =>
            {
                Console.WriteLine(args.Tweet.Text);
            };
            stream.StartStream();
        }

        private void Stream_FilteredStreamExample()
        {
            var stream = Stream.CreateFilteredStream();
            var location = Geo.GenerateLocation(-124.75, 36.8, -126.89, 32.75);

            stream.AddLocation(location);
            stream.AddTrack("tweetinvi");
            stream.AddTrack("linvi");

            stream.MatchingTweetAndLocationReceived += (sender, args) =>
            {
                var tweet = args.Tweet;
                Console.WriteLine("{0} was detected between the following tracked locations:", tweet.Id);

                IEnumerable<ILocation> matchingLocations = args.MatchedLocations;
                foreach (var matchingLocation in matchingLocations)
                {
                    Console.Write("({0}, {1}) ;", matchingLocation.Coordinate1.Latitude, matchingLocation.Coordinate1.Longitude);
                    Console.WriteLine("({0}, {1})", matchingLocation.Coordinate2.Latitude, matchingLocation.Coordinate2.Longitude);
                }
            };

            stream.StartStreamMatchingAllConditions();
        }

        private void Stream_UserStreamExample()
        {
            var userStream = Stream.CreateUserStream();

            // Tweet Published
            EventsRelatedWithTweetCreation(userStream);

            // Messages
            EventsRelatedWithMessages(userStream);

            // Favourited - Unfavourited
            EventsRelatedWithTweetAndFavourite(userStream);

            // Lists
            EventsRelatedWithLists(userStream);

            // Block - Unblock
            EventsRelatedWithBlock(userStream);

            // User Update
            userStream.LoggedUserProfileUpdated += (sender, args) =>
            {
                var newLoggedUser = args.LoggedUser;
                Console.WriteLine("Logged user '{0}' has been updated!", newLoggedUser.Name);
            };

            // Friends the stream will analyze - A UserStream cannot analyze more than 10.000 people at the same time
            userStream.FriendIdsReceived += (sender, args) =>
            {
                var friendIds = args.Value;
                Console.WriteLine(friendIds.Count());
            };

            userStream.StartStream();
        }

        private void EventsRelatedWithTweetCreation(IUserStream userStream)
        {
            userStream.TweetCreatedByAnyone += (sender, args) =>
            {
                Console.WriteLine("Tweet created by anyone");
            };

            userStream.TweetCreatedByMe += (sender, args) =>
            {
                Console.WriteLine("Tweet created by me");
            };

            userStream.TweetCreatedByAnyoneButMe += (sender, args) =>
            {
                Console.WriteLine("Tweet created by {0}", args.Tweet.Creator.Name);
            };
        }

        private void EventsRelatedWithMessages(IUserStream userStream)
        {
            userStream.MessageSent += (sender, args) => { Console.WriteLine("message '{0}' sent", args.Message.Text); };
            userStream.MessageReceived += (sender, args) => { Console.WriteLine("message '{0}' received", args.Message.Text); };
        }

        private void EventsRelatedWithTweetAndFavourite(IUserStream userStream)
        {
            // Favourite
            userStream.TweetFavouritedByAnyone += (sender, args) =>
            {
                var tweet = args.Tweet;
                var userWhoFavouritedTheTweet = args.FavouritingUser;
                Console.WriteLine("User '{0}' favourited tweet '{1}'", userWhoFavouritedTheTweet.Name, tweet.Id);
            };

            userStream.TweetFavouritedByMe += (sender, args) =>
            {
                var tweet = args.Tweet;
                var loggedUser = args.FavouritingUser;
                Console.WriteLine("Logged User '{0}' favourited tweet '{1}'", loggedUser.Name, tweet.Id);
            };

            userStream.TweetFavouritedByAnyoneButMe += (sender, args) =>
            {
                var tweet = args.Tweet;
                var userWhoFavouritedTheTweet = args.FavouritingUser;
                Console.WriteLine("User '{0}' favourited tweet '{1}'", userWhoFavouritedTheTweet.Name, tweet.Id);
            };

            // Unfavourite
            userStream.TweetUnFavouritedByAnyone += (sender, args) =>
            {
                var tweet = args.Tweet;
                var userWhoFavouritedTheTweet = args.FavouritingUser;
                Console.WriteLine("User '{0}' unfavourited tweet '{1}'", userWhoFavouritedTheTweet.Name, tweet.Id);
            };

            userStream.TweetUnFavouritedByMe += (sender, args) =>
            {
                Console.WriteLine("Tweet unfavourited by me!");
            };

            userStream.TweetUnFavouritedByAnyoneButMe += (sender, args) =>
            {
                var tweet = args.Tweet;
                var userWhoFavouritedTheTweet = args.FavouritingUser;
                Console.WriteLine("User '{0}' favourited tweet '{1}'", userWhoFavouritedTheTweet.Name, tweet.Id);
            };
        }

        private void EventsRelatedWithLists(IUserStream userStream)
        {
            userStream.ListCreated += (sender, args) =>
            {
                Console.WriteLine("List '{0}' created!", args.List.Name);
            };

            userStream.ListUpdated += (sender, args) =>
            {
                Console.WriteLine("List '{0}' updated!", args.List.Name);
            };

            userStream.ListDestroyed += (sender, args) =>
            {
                Console.WriteLine("List '{0}' destroyed!", args.List.Name);
            };

            // User Added
            userStream.LoggedUserAddedMemberToList += (sender, args) =>
            {
                var newUser = args.User;
                var list = args.List;
                Console.WriteLine("You added '{0}' to the list : '{1}'", newUser.Name, list.Name);
            };

            userStream.LoggedUserAddedToListBy += (sender, args) =>
            {
                var newUser = args.User;
                var list = args.List;
                Console.WriteLine("You haved been added to the list '{0}' by '{1}'", list.Name, newUser.Name);
            };

            // User Removed
            userStream.LoggedUserRemovedMemberFromList += (sender, args) =>
            {
                var newUser = args.User;
                var list = args.List;
                Console.WriteLine("You removed '{0}' from the list : '{1}'", newUser.Name, list.Name);
            };

            userStream.LoggedUserRemovedFromListBy += (sender, args) =>
            {
                var newUser = args.User;
                var list = args.List;
                Console.WriteLine("You haved been removed from the list '{0}' by '{1}'", list.Name, newUser.Name);
            };

            // User Subscribed
            userStream.LoggedUserSubscribedToListCreatedBy += (sender, args) =>
            {
                var list = args.List;
                Console.WriteLine("You have subscribed to the list '{0}", list.Name);
            };

            userStream.UserSubscribedToListCreatedByMe += (sender, args) =>
            {
                var list = args.List;
                var user = args.User;
                Console.WriteLine("'{0}' have subscribed to your list '{1}'", user.Name, list.Name);
            };

            // User Unsubscribed
            userStream.LoggedUserUnsubscribedToListCreatedBy += (sender, args) =>
            {
                var list = args.List;
                Console.WriteLine("You have unsubscribed from the list '{0}'", list.Name);
            };

            userStream.UserUnsubscribedToListCreatedByMe += (sender, args) =>
            {
                var list = args.List;
                var user = args.User;
                Console.WriteLine("'{0}' have unsubscribed from your list '{1}'", user.Name, list.Name);
            };
        }

        private void EventsRelatedWithBlock(IUserStream userStream)
        {
            userStream.BlockedUser += (sender, args) =>
            {
                Console.WriteLine("I blocked a '{0}'", args.User.ScreenName);
            };

            userStream.UnBlockedUser += (sender, args) =>
            {
                Console.WriteLine("I un blocked a '{0}'", args.User.ScreenName);
            };
        }

        #endregion

        #region Exception

        private void Exceptions_GetExceptionsInfo()
        {
            TwitterCredentials.Credentials = null;

            var user = User.GetLoggedUser();
            if (user == null)
            {
                var lastException = ExceptionHandler.GetLastException();
                Console.WriteLine(lastException.TwitterDescription);
            }
        }

        #endregion

        #region Manual Query

        private void ManualQuery_Example()
        {
            const string getHomeTimelineQuery = "https://api.twitter.com/1.1/statuses/home_timeline.json";

            // Execute Query can either return a json or a DTO interface
            var tweetsDTO = Tweetinvi.TwitterAccessor.ExecuteGETQuery<IEnumerable<ITweetDTO>>(getHomeTimelineQuery);
            tweetsDTO.ForEach(tweetDTO => Console.WriteLine(tweetDTO.Text));
        }

        #endregion
    }

}
