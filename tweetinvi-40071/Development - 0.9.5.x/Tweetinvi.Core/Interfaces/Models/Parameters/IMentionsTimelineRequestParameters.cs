namespace Tweetinvi.Core.Interfaces.Models.Parameters
{
    public interface IMentionsTimelineRequestParameters : ITimelineRequestParameters
    {
        bool IncludeContributorDetails { get; set; }
    }
}