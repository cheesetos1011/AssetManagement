using Framework;
using Framework.APIController;
using NUnit.Framework;
using ProjectCode.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCode.TestsScript
{
    [TestFixtureSource(typeof(CrossBrowserData), nameof(CrossBrowserData.LastestConfigurations))]
    [Parallelizable(ParallelScope.Self)]

    public class US3_ViewUserListAndDetails : TestSetup
    {
        public string messageId;

        public US3_ViewUserListAndDetails(string browser, string osPlatform) : base(browser, osPlatform)
        {
        }

        
        [Test, Category("API-Login")]
        // [TestCaseSource(typeof(TestCase1), "GetTestData")]
        public void LoginRequest()
        {
            AuthenticationService authenService = new AuthenticationService();
            string _token = authenService.Login("admin1", "Rookiesms1").token;
        }

        [Test, Category("Get user list")]
        public void getUserList()
        {
            UserService userService = new UserService();

            APIResponse getUser = userService.GetUserDataRequest();


        }
        

        /*
        [Test, Category("API"), Order(2)]
        // [TestCaseSource(typeof(TestCase2), "GetTestData")]
        public void GetUserData(string username, string passwword)
        {
            AuthenticationService userService = new AuthenticationService();
            APIResponse response = userService.GetUserData(username, passwword);
            // Verify UserData Id
            Assert.That(userService.idResponse(response).Equals(_MessageId), "Invalid UserId");

            // Verify UserData Response
            Assert.That(userService.UserNameResponse(response).Equals("RookiesBatch4"), "Invalid Username");
            Assert.That(userService.FirstNameResponse(response).Equals("dao"), "Invalid FirstName");
            Assert.That(userService.LastNameResponse(response).Equals("hoang"), "Invalid LastName");
            Assert.That(userService.EmailResponse(response).Equals("dao@gmail.com"), "Invalid Email");
            Assert.That(userService.PasswordResponse(response).Equals("autotest"), "Invalid Password");
            Assert.That(userService.PhoneResponse(response).Equals("012345678"), "Invalid PhoneNumber");
            TestContext.WriteLine(response.responseStatusCode + " " + response.responseStatus);
            TestContext.WriteLine(response.responseBody);
        }
        */

    }
}
