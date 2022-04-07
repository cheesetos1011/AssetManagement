using AventStack.ExtentReports.MarkupUtils;
using Framework.APIController;
using Framework.HTMLReport;

namespace Framework.HTMLReport
{
    public class MarkupHelperPlus
    {
        public static IMarkup CreateRequestInfor(APIRequest request, APIResponse response)
        {
            APIRequestBlock markup = new APIRequestBlock();
            markup.request = request;
            markup.response = response;
            return markup;

        }
    }
}
