using Tweetinvi.Core.Injectinvi;
using Tweetinvi.Core.Interfaces.Credentials;
using Tweetinvi.Core.Interfaces.DTO.QueryDTO;
using Tweetinvi.Credentials.QueryDTO;
using Tweetinvi.WebLogic;

namespace Tweetinvi.Credentials
{
    public class TweetinviCredentialsModule : ITweetinviModule
    {
        private readonly ITweetinviContainer _container;

        public TweetinviCredentialsModule(ITweetinviContainer container)
        {
            _container = container;
        }

        public void Initialize()
        {
            _container.RegisterType<ITwitterAccessor, TwitterAccessor>(RegistrationLifetime.InstancePerThread);
            _container.RegisterType<ICredentialsAccessor, CredentialsAccessor>(RegistrationLifetime.InstancePerThread);

            _container.RegisterType<ICredentialsCreator, CredentialsCreator>();
            _container.RegisterType<IWebTokenCreator, WebTokenCreator>();
            _container.RegisterType<ICursorQueryHelper, CursorQueryHelper>();
            _container.RegisterType<ITemporaryCredentials, TemporaryCredentials>();
        }
    }
}