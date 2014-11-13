using Tweetinvi.Core.Helpers;
using Tweetinvi.Core.Injectinvi;

namespace Tweetinvi.Core
{
    public class TweetinviCoreModule : ITweetinviModule
    {
        public TweetinviCoreModule(ITweetinviContainer container)
        {
            _container = container;
        }

        private static ITweetinviContainer _container;
        public static ITweetinviContainer TweetinviContainer
        {
            get { return _container; }
        }

        public void Initialize()
        {
            TweetinviContainer.RegisterGeneric(typeof(IFactory<>), typeof(Factory<>));
            TweetinviContainer.RegisterType<ITaskFactory, TaskFactory>();
            TweetinviContainer.RegisterType<ISynchronousInvoker, SynchronousInvoker>();
            TweetinviContainer.RegisterType<ITweetinviSettings, TweetinviSettings>(RegistrationLifetime.InstancePerThread);
            TweetinviContainer.RegisterType<ITweetinviSettingsAccessor, TweetinviSettingsAccessor>(RegistrationLifetime.InstancePerApplication);
        }
    }
}