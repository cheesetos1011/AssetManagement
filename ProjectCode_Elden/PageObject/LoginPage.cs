using Framework.Driver;
using OpenQA.Selenium;

namespace ProjectCode.PageObject
{
    public class LoginPage : WebDriverAction
    {
        By tf_username = By.XPath("//input[@id='username']");
        By tf_password = By.XPath("//input[@id='password']");

        By btn_login = By.XPath("//button[@type='submit']");

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }
        public void InputUserInfo(string username, string password)
        {
            SendKey(tf_username, username);
            SendKey(tf_password, password);
        }
        public void ClickLoginButton()
        {
            ClickElement(btn_login);
        }
        
    }
}
