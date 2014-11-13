using System;
using Tweetinvi.Core;

namespace Tweetinvi
{
    public class TweetinviConfig
    {
        /// <summary>
        /// Default settings used when creating a new Thread
        /// </summary>
        public static ITweetinviSettings ApplicationSettings
        {
            get { return _currentSettingsAccessor.ApplicationSettings; }
        }

        public static ITweetinviSettings CurrentSettings
        {
            get { return _currentSettingsAccessor.CurrentThreadSettings; }
        }

        private static readonly ITweetinviSettingsAccessor _currentSettingsAccessor;

        static TweetinviConfig()
        {
            _currentSettingsAccessor = TweetinviContainer.Resolve<ITweetinviSettingsAccessor>();
            _currentSettingsAccessor.CurrentThreadSettings = TweetinviContainer.Resolve<ITweetinviSettings>();
        }

        /// <summary>
        /// URL of the proxy to use when performing any request
        /// </summary>
        public static string APPLICATION_PROXY_URL
        {
            get { return ApplicationSettings.ProxyURL; }
            set { ApplicationSettings.ProxyURL = value; }
        }

        /// <summary>
        /// Value indicating whether some debug information will be printed in the console.
        /// By default it is enabled in debug and disabled in release.
        /// </summary>
        public static bool APPLICATION_SHOW_DEBUG
        {
            get { return ApplicationSettings.ShowDebug; }
            set { ApplicationSettings.ShowDebug = value; }
        }

        /// <summary>
        /// Duration in milliseconds before Tweetinvi considers that the WebRequest has failed to execute.
        /// A value of -1 indicates that the query will wait indifinitely for a response.
        /// </summary>
        public static int APPLICATION_WEB_REQUEST_TIMEOUT
        {
            get { return ApplicationSettings.WebRequestTimeout; }
            set { ApplicationSettings.WebRequestTimeout = value; }
        }

        /// <summary>
        /// URL of the proxy to use when performing any request
        /// </summary>
        public static string CURRENT_PROXY_URL
        {
            get { return CurrentSettings.ProxyURL; }
            set { CurrentSettings.ProxyURL = value; }
        }

        /// <summary>
        /// Value indicating whether some debug information will be printed in the console.
        /// By default it is enabled in debug and disabled in release.
        /// </summary>
        public static bool CURRENT_SHOW_DEBUG
        {
            get { return CurrentSettings.ShowDebug; }
            set { CurrentSettings.ShowDebug = value; }
        }

        /// <summary>
        /// Duration in milliseconds before Tweetinvi considers that the WebRequest has failed to execute.
        /// A value of -1 indicates that the query will wait indifinitely for a response.
        /// </summary>
        public static int CURRENT_WEB_REQUEST_TIMEOUT
        {
            get { return CurrentSettings.WebRequestTimeout; }
            set { CurrentSettings.WebRequestTimeout = value; }
        }
    }
}