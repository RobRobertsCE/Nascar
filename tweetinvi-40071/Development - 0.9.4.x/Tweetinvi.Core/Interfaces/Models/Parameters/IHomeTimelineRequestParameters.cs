namespace Tweetinvi.Core.Interfaces.Models.Parameters
{
    public interface IHomeTimelineRequestParameters : ITimelineRequestParameters
    {
        bool IncludeContributorDetails { get; set; }
        bool ExcludeReplies { get; set; }
    }
}