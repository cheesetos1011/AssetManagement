using Framework.APIController;
using Framework.HTMLReport;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProjectCode.DTO.User.User;

namespace ProjectCode.Services
{
    public class UserService
    {

        string userListPath = "api/users/list";
        public APIResponse GetUserDataRequest(string token)
        {
            APIResponse response = new APIRequest()
                .setUrl("https://rookiesgroup1.azurewebsites.net/" + userListPath)
                .CreateRequest()
                .AddQueryParameter("location","Hanoi")
                .AddHeader("Authorization", "Bearer " + token)
                
                .SetMethod("GET")
                .SendRequest();
            HTMLReporter.Pass(response.responseBody);
            return response;

        }

        public List<Data> GetListUsers(string token)
        {
            APIResponse response = GetUserDataRequest(token);
            List<Data> userDatas = JsonConvert.DeserializeObject<List<Data>>(response.responseBody);
            return userDatas;
        }
    }
}
