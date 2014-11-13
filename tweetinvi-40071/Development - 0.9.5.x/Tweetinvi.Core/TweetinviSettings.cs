namespace Tweetinvi.Core
{
    public interface ITweetinviSettings
    {
        bool ShowDebug { get; set; }
        string ProxyURL { get; set; }
        int WebRequestTimeout { get; set; }

        void InitialiseFrom(ITweetinviSettings other);
        ITweetinviSettings Clone();
    }

    public class TweetinviSettings : ITweetinviSettings
    {
        public const long DEFAULT_ID = -1;

        public bool ShowDebug { get; set; }
        public string ProxyURL { get; set; }
        public int WebRequestTimeout { get; set; }

        public ITweetinviSettings Clone()
        {
            var clone = new TweetinviSettings();
            clone.ShowDebug = ShowDebug;
            clone.ProxyURL = ProxyURL;
            clone.WebRequestTimeout = WebRequestTimeout;
            return clone;
        }

        public void InitialiseFrom(ITweetinviSettings other)
        {
            ShowDebug = other.ShowDebug;
            ProxyURL = other.ProxyURL;
            WebRequestTimeout = other.WebRequestTimeout;
        }
    }
}