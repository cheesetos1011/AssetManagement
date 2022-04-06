using Framework.APIController;
using Framework.HTMLReport;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Net;
using System.Text;
using System.IO;

namespace Framework.APIController
{
    public class APIRequest
    {
        public HttpWebRequest request;
        public string url { get; set; }
        public int queryParamCount { get; set; }
        public string requestBody { get; set; }
        public string formData { get; set; }

        public APIRequest setUrl(string url)
        {
            this.url = url;
            return this;
        }
        public APIRequest setBaseUrl(string url)
        {
            this.url = url;
            return this;
        }


        public APIRequest CreateRequest()
        {
            this.url = url;
            request = (HttpWebRequest)WebRequest.Create(url);
            return this;
        }

        public APIRequest()
        {
            url = "";
            formData = "";
            requestBody = "";
            queryParamCount = 0;
        }

        public APIRequest AddHeader(string key, string value)
        {
            request.Headers.Add(key, value);
            return this;
        }
        /*
        public APIRequest AddRequestParameter(string key, string value)
        {
            if (url.Contains("?"))
            {
                url = url + "?" + key + "=" + value;
            }
            else
            {
                url = url + "&" + key + "=" + value;
            }
            return this;
        }
        */

        public APIRequest AddQueryParameter(string key, string value)
        {
            if (queryParamCount == 0)
            {
                url = url + "?" + key + "=" + value;
                queryParamCount++;
            }
            else
            {
                url = url + "&" + key + "=" + value;
            }
            return this;
        }

        public APIRequest AddFormData(string key, string value)
        {
            if (formData.Equals("") || formData == null)
            {
                formData += key + "=" + value;
            }
            else if (!formData.Equals(""))
            {
                formData += "&" + key + "=" + value;
            }
            return this;
        }

        public APIRequest SendContentType(string name)
        {
            request.ContentType = name;
            return this;
        }

        public APIRequest AddRequestBody(string body)
        {
            this.requestBody = body;
            return this;
        }

        public APIRequest SetMethod(string method)
        {
            request.Method = method;
            return this;
        }

        public APIRequest Get()
        {
            request.Method = "GET";
            APIResponse response = SendRequest();
            return this;
        }
        public APIRequest Post()
        {
            request.Method = "POST";
            APIResponse response = SendRequest();
            return this;
        }
        public APIRequest Put()
        {
            request.Method = "PUT";
            APIResponse response = SendRequest();
            return this;
        }
        public APIRequest Delete()
        {
            request.Method = "DELETE";
            APIResponse response = SendRequest();
            return this;
        }


        public APIResponse SendRequest()
        {
            if (request.Method == "GET")
            {
                requestBody = null;
            }
            else
            {
                if (requestBody != null)
                {
                    byte[] byteArray = Encoding.UTF8.GetBytes(requestBody);
                    request.ContentLength = byteArray.Length;
                    using (Stream dataStream = request.GetRequestStream())
                    {
                        dataStream.Write(byteArray, 0, byteArray.Length);
                        dataStream.Flush();
                        dataStream.Close();
                    }
                }
                if (!formData.Equals(""))
                {
                    byte[] byteArray = Encoding.UTF8.GetBytes(requestBody);
                    request.ContentLength = byteArray.Length;
                    using (Stream dataStream = request.GetRequestStream())
                    {
                        dataStream.Write(byteArray, 0, byteArray.Length);
                        dataStream.Flush();
                        dataStream.Close();
                    }
                }
            }
            try
            {
                IAsyncResult asyncResult = request.BeginGetResponse(null, null);
                asyncResult.AsyncWaitHandle.WaitOne();
                var httpResponse = (HttpWebResponse)request.EndGetResponse(asyncResult);
                APIResponse response = new APIResponse(httpResponse);
                HTMLReporter.Pass(this, response);
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
