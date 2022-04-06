using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.APIController;
using Framework.HTMLReport;
using Newtonsoft.Json;
using static ProjectCode.DTO.User.User;

namespace ProjectCode.Services
{
    internal class AuthenticationService
    {
        public string userLoginPath = "api/authentications/login";

        private APIResponse LoginRequest(string username, string password)
        {
            APIRequest request = new APIRequest();
            APIResponse response = request.setUrl("https://rookiesgroup1.azurewebsites.net/" + userLoginPath)
                .AddHeader("content-type", "application/json")
                .AddFormData("userName", username)
                .AddFormData("password", password)
                .SetMethod("POST")
                .SendRequest();
            HTMLReporter.Pass(response.responseBody);
            return response;
        }

        public UserData Login(string username, string password)
        {
            APIResponse response = LoginRequest(username, password);
            UserData userLogin = (UserData)JsonConvert.DeserializeObject<UserData>(response.responseBody);
            return userLogin;

            /*
             AuthenticationService loginService = new AuthenticationService();
            _token = loginService.Login("admin1","Rookiesms1").token;*/
        }

    }
}
