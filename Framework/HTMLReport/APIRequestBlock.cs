using AventStack.ExtentReports.MarkupUtils;
using Framework.APIController;

namespace Framework.HTMLReport
{
    public class APIRequestBlock : IMarkup
    {
        public APIRequest request { get; set; }
        public APIResponse response { get; set; }


        public string GetMarkup()
        {
            string requestUrl = request.url;
            string responseBody = response.responseBody;
            string htmlBody = "<p>Url: " + requestUrl + "<p><br></br><p> response body: " + responseBody + "</p>";

            return htmlBody;
        }
    }
}
