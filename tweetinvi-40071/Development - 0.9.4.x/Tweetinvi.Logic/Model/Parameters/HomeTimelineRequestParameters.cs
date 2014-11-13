using Tweetinvi.Core.Interfaces.Models.Parameters;

namespace Tweetinvi.Logic.Model.Parameters
{
    public class HomeTimelineRequestParameters : TimelineRequestParameters, IHomeTimelineRequestParameters
    {
        public HomeTimelineRequestParameters()
        {
            IncludeContributorDetails = false;
            ExcludeReplies = false;
        }

        public bool IncludeContributorDetails { get; set; }
        public bool ExcludeReplies { get; set; }
    }
}