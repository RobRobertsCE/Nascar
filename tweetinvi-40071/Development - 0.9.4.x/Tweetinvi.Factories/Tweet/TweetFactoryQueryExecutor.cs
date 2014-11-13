using System;
using System.Collections.Generic;
using Tweetinvi.Core.Injectinvi;
using Tweetinvi.Core.Interfaces.Credentials;
using Tweetinvi.Core.Interfaces.DTO;
using Tweetinvi.Core.Interfaces.QueryGenerators;
using Tweetinvi.Factories.Properties;
using Tweetinvi.Logic.DTO;

namespace Tweetinvi.Factories.Tweet
{
    public interface ITweetFactoryQueryExecutor
    {
        ITweetDTO GetTweetDTO(long tweetId);
        IEnumerable<ITweetDTO> GetTweetDTOs(IEnumerable<long> tweetIds);
        ITweetDTO CreateTweetDTO(string text);
    }

    public class TweetFactoryQueryExecutor : ITweetFactoryQueryExecutor
    {
        private readonly ITweetQueryGenerator _tweetQueryGenerator;
        private readonly ITwitterAccessor _twitterAccessor;
        private readonly IFactory<ITweetDTO> _tweetDTOUnityFactory;

        public TweetFactoryQueryExecutor(
            ITweetQueryGenerator tweetQueryGenerator,
            ITwitterAccessor twitterAccessor, 
            IFactory<ITweetDTO> tweetDTOUnityFactory)
        {
            _tweetQueryGenerator = tweetQueryGenerator;
            _twitterAccessor = twitterAccessor;
            _tweetDTOUnityFactory = tweetDTOUnityFactory;
        }

        public ITweetDTO GetTweetDTO(long tweetId)
        {
            string query = _tweetQueryGenerator.GetTweetQuery(tweetId);
            return _twitterAccessor.ExecuteGETQuery<TweetDTO>(query);
        }

        public IEnumerable<ITweetDTO> GetTweetDTOs(IEnumerable<long> tweetIds)
        {
            string query = _tweetQueryGenerator.GetTweetsQuery(tweetIds);
            return _twitterAccessor.ExecuteGETQuery<IEnumerable<TweetDTO>>(query);
        }

        public ITweetDTO CreateTweetDTO(string text)
        {
            var tweetDTO = _tweetDTOUnityFactory.Create();
            tweetDTO.Text = text;

            return tweetDTO;
        }
    }
}