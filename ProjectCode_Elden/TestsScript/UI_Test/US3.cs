
using Framework;
using NUnit.Framework;
using ProjectCode.PageObject;

namespace ProjectCode
{
    [TestFixtureSource(typeof(CrossBrowserData), nameof(CrossBrowserData.LastestConfigurations))]
    [Parallelizable(ParallelScope.Self)]

    public class US3 : TestSetup2
    {
        public US3(string browser, string osPlatform) : base(browser, osPlatform)
        {

        }
        [SetUp]
        public void Setup()
        {

        }

        [Test, Category("US3_48 - Login with 2 different Admin account from 2 different windows")]
        public void US3_48()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.InputUserInfo("admin1", "Rookiesms1");
        }


        [Test, Category("US3_49 - Search with staff code")]
        public void US3_49()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.InputUserInfo("admin1", "Rookiesms1");

            loginPage.ClickLoginButton();

            string staffCode = "SD003";
            ManageUserPage manageUserPage = new ManageUserPage(driver);
            manageUserPage.ClickManageUser();
            manageUserPage.SearchByValue(staffCode);

            Assert.That(manageUserPage.getSearchResult().Contains(staffCode), "No matched search");

        }

        [Test, Category("US3_50 - Search with username")]
        public void US3_50()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.InputUserInfo("admin1", "Rookiesms1");

            loginPage.ClickLoginButton();

            string username = "thed";
            ManageUserPage manageUserPage = new ManageUserPage(driver);
            manageUserPage.ClickManageUser();
            manageUserPage.SearchByValue(username);

            Assert.That(manageUserPage.getSearchResult().Contains(username), "No matched search");

        }

        [Test, Category("US3_51 - Search with fullname")]
        public void US3_51()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.InputUserInfo("admin1", "Rookiesms1");

            loginPage.ClickLoginButton();

            string fullname = "Ngoc";

            ManageUserPage manageUserPage = new ManageUserPage(driver);
            manageUserPage.ClickManageUser();
            manageUserPage.SearchByValue(fullname);

            Assert.That(manageUserPage.getSearchResult().Contains(fullname), "No matched search");

        }

        [Test, Category("US3_56 - Filter by Admin")]
        public void US3_56()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.InputUserInfo("admin1", "Rookiesms1");

            loginPage.ClickLoginButton();

            ManageUserPage manageUserPage = new ManageUserPage(driver);
            manageUserPage.ClickManageUser();
            manageUserPage.FilterAdmin();
            manageUserPage.getFilterResult();

            Assert.That(manageUserPage.getSearchResult().Contains("Admin"), "No matched search");

        }

        [Test, Category("US3_57 - Filter by Staff")]
        public void US3_57()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.InputUserInfo("admin1", "Rookiesms1");

            loginPage.ClickLoginButton();

            ManageUserPage manageUserPage = new ManageUserPage(driver);
            manageUserPage.ClickManageUser();
            manageUserPage.FilterStaff();
            manageUserPage.getFilterResult();

            Assert.That(manageUserPage.getSearchResult().Contains("Staff"), "No matched search");

        }

    }
}
