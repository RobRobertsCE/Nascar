namespace Tweetinvi.Core.Interfaces.Models.Parameters
{
    public interface IRetweetsOfMeTimelineRequestParameters : ITimelineRequestParameters
    {
        bool IncludeUserEntities { get; set; }
    }
}
