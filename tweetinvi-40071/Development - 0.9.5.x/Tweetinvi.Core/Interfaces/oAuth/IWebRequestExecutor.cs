using System.Net;

namespace Tweetinvi.Core.Interfaces.oAuth
{
    /// <summary>
    /// Generate a Token that can be used to perform OAuth queries
    /// </summary>
    public interface IWebRequestExecutor
    {       
        string ExecuteWebRequest(HttpWebRequest webRequest);
        string ExecuteMultipartRequest(IMultipartWebRequest multipartWebRequest);
    }
}