using Tweetinvi.Core.Injectinvi;
using Tweetinvi.Injectinvi;

namespace Tweetinvi
{
    public static class TweetinviContainer
    {
        private static readonly ITweetinviContainer _container;

        static TweetinviContainer()
        {
            _container = new AutofacContainer();
        }

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}