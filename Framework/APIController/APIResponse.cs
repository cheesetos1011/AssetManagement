using Newtonsoft.Json;
using RestSharp;
using System.IO;
using System.Net;

namespace Framework.APIController
{
    public class APIResponse
    {

        private HttpWebResponse response;
        public string responseBody { get; set; }
        public string responseStatusCode { get; set; }
        public APIResponse(HttpWebResponse response)
        {
            this.response = response;
            GetResponseBody();
            GetResponseStatusCode();
        }

        private string GetResponseBody()
        {
            responseBody = "";
            using (var responseStream = response.GetResponseStream())
            {
                if (responseStream != null)
                {
                    using (var reader = new StreamReader(responseStream))
                    {
                        responseBody = reader.ReadToEnd();
                    }
                }
            }
            return responseBody;
        }

        private string GetResponseStatusCode()
        {
            responseStatusCode = response.StatusCode.ToString();
            return responseStatusCode;
        }
    }

}
