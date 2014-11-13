using System;
using System.Text;
using Tweetinvi.Controllers.Properties;
using Tweetinvi.Controllers.Shared;
using Tweetinvi.Core.Interfaces.Models.Parameters;
using Tweetinvi.Core.Interfaces.QueryGenerators;
using Tweetinvi.Core.Interfaces.QueryValidators;

namespace Tweetinvi.Controllers.Timeline
{
    public interface ITimelineQueryGenerator
    {
        // Home Timeline
        string GetHomeTimelineQuery(IHomeTimelineRequestParameters timelineRequestParameters);

        // User Timeline
        string GetUserTimelineQuery(IUserTimelineRequestParameters timelineRequestParameters);

        // Mention Timeline
        string GetMentionsTimelineQuery(IMentionsTimelineRequestParameters mentionsTimelineRequestParameters);

        // Retweets of Me Timeline
        string GetRetweetsOfMeTimelineQuery(IRetweetsOfMeTimelineRequestParameters retweetsOfMeTimelineRequestParameters);
    }

    public class TimelineQueryGenerator : ITimelineQueryGenerator
    {
        private readonly IUserQueryParameterGenerator _userQueryParameterGenerator;
        private readonly IUserQueryValidator _userQueryValidator;
        private readonly IQueryParameterGenerator _queryParameterGenerator;
        private readonly ITimelineQueryParameterGenerator _timelineQueryParameterGenerator;

        public TimelineQueryGenerator(
            IUserQueryParameterGenerator userQueryGenerator,
            IUserQueryValidator userQueryValidator,
            IQueryParameterGenerator queryParameterGenerator,
            ITimelineQueryParameterGenerator timelineQueryParameterGenerator)
        {
            _userQueryParameterGenerator = userQueryGenerator;
            _userQueryValidator = userQueryValidator;
            _queryParameterGenerator = queryParameterGenerator;
            _timelineQueryParameterGenerator = timelineQueryParameterGenerator;
        }

        // Helper

        // Home Timeline
        public string GetHomeTimelineQuery(IHomeTimelineRequestParameters timelineRequestParameters)
        {
            var homeTimelineRequestQueryParameter = GenerateHomeTimelineParameters(timelineRequestParameters);
            var includeContributorDetailsQueryParameter = GenerateIncludeContributorsDetailsParameter(timelineRequestParameters.IncludeContributorDetails);
            var timelineRequestQueryParameter = GenerateTimelineRequestParameter(timelineRequestParameters);
            var requestParameters = String.Format("{0}{1}{2}", homeTimelineRequestQueryParameter, includeContributorDetailsQueryParameter, timelineRequestQueryParameter);
            return String.Format(Resources.Timeline_GetHomeTimeline, requestParameters);
        }

        private string GenerateHomeTimelineParameters(IHomeTimelineRequestParameters timelineRequestParameters)
        {
            return _timelineQueryParameterGenerator.GenerateExcludeRepliesParameter(timelineRequestParameters.ExcludeReplies);
        }

        // User Timeline
        public string GetUserTimelineQuery(IUserTimelineRequestParameters timelineRequestParameters)
        {
            if (timelineRequestParameters == null)
            {
                throw new ArgumentNullException("Timeline request parameter cannot be null");
            }

            if (!_userQueryValidator.CanUserBeIdentified(timelineRequestParameters.UserIdentifier))
            {
                throw new ArgumentNullException("User identifier cannot be null");
            }

            var userTimelineRequestParameter = GenerateUserTimelineRequestParameters(timelineRequestParameters);
            var includeContributorDetailsQueryParameter = GenerateIncludeContributorsDetailsParameter(timelineRequestParameters.IncludeContributorDetails);
            var timelineRequestParameter = GenerateTimelineRequestParameter(timelineRequestParameters);
            var requestParameters = String.Format("{0}{1}{2}", userTimelineRequestParameter, includeContributorDetailsQueryParameter, timelineRequestParameter);

            return String.Format(Resources.Timeline_GetUserTimeline, requestParameters);
        }

        private string GenerateUserTimelineRequestParameters(IUserTimelineRequestParameters userTimelineRequestParameters)
        {
            var requestParameter = new StringBuilder();

            requestParameter.Append(_userQueryParameterGenerator.GenerateIdOrScreenNameParameter(userTimelineRequestParameters.UserIdentifier));
            requestParameter.Append(_timelineQueryParameterGenerator.GenerateIncludeRTSParameter(userTimelineRequestParameters.IncludeRTS));
            requestParameter.Append(_timelineQueryParameterGenerator.GenerateExcludeRepliesParameter(userTimelineRequestParameters.ExcludeReplies));

            return requestParameter.ToString();
        }

        // Mentions Timeline
        public string GetMentionsTimelineQuery(IMentionsTimelineRequestParameters mentionsTimelineRequestParameters)
        {
            var includeContributorDetailsQueryParameter = GenerateIncludeContributorsDetailsParameter(mentionsTimelineRequestParameters.IncludeContributorDetails);
            var timelineRequestParameter = GenerateTimelineRequestParameter(mentionsTimelineRequestParameters);
            var requestParameters = String.Format("{0}{1}", includeContributorDetailsQueryParameter, timelineRequestParameter);

            return String.Format(Resources.Timeline_GetMentionsTimeline, requestParameters);
        }
        
        // Retweets of Me Timeline
        public string GetRetweetsOfMeTimelineQuery(IRetweetsOfMeTimelineRequestParameters retweetsOfMeTimelineRequestParameters)
        {
            var includeUserEntitiesParameter = _timelineQueryParameterGenerator.GenerateIncludeUserEntitiesParameter(retweetsOfMeTimelineRequestParameters.IncludeUserEntities);
            var timelineRequestParameter = GenerateTimelineRequestParameter(retweetsOfMeTimelineRequestParameters);
            var requestParameters = string.Format("{0}{1}", timelineRequestParameter, includeUserEntitiesParameter);
               
            return String.Format(Resources.Timeline_GetRetweetsOfMeTimeline, requestParameters);
        }

        // Base Timeline Query Generator
        private string GenerateTimelineRequestParameter(ITimelineRequestParameters timelineRequestParameters)
        {
            var requestParameter = new StringBuilder();

            requestParameter.Append(_queryParameterGenerator.GenerateCountParameter(timelineRequestParameters.MaximumNumberOfTweetsToRetrieve));
            requestParameter.Append(_queryParameterGenerator.GenerateTrimUserParameter(timelineRequestParameters.TrimUser));
            requestParameter.Append(_queryParameterGenerator.GenerateSinceIdParameter(timelineRequestParameters.SinceId));
            requestParameter.Append(_queryParameterGenerator.GenerateMaxIdParameter(timelineRequestParameters.MaxId));
            requestParameter.Append(_queryParameterGenerator.GenerateIncludeEntitiesParameter(timelineRequestParameters.IncludeEntities));

            return requestParameter.ToString();
        }

        private string GenerateIncludeContributorsDetailsParameter(bool includeContributorDetails)
        {
            return _timelineQueryParameterGenerator.GenerateIncludeContributorDetailsParameter(includeContributorDetails);
        }
    }
}