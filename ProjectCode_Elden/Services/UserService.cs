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
        public APIResponse GetUserDataRequest()
        {
            APIResponse response = new APIRequest()
                .setUrl("https://rookiesgroup1.azurewebsites.net/" + userListPath)
                .SetMethod("GET")
                .SendRequest();
            HTMLReporter.Pass(response.responseBody);
            return response;

        }

        public List<UserData> GetUsers()
        {
            APIResponse response = GetUserDataRequest();
            List<UserData> userDatas = JsonConvert.DeserializeObject<List<UserData>>(response.responseBody);
            return userDatas;
        }
    }
}
