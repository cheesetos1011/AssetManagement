using Framework.Driver;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace ProjectCode.PageObject
{
    public class ManageUserPage : WebDriverAction
    {
        By link_ManageUser = By.XPath("//a[@href='/users']");

        By searchBox = By.XPath("//input[@id='searching']");

        By table_user = By.XPath("//div[@class='table-responsive']");

        By dropdown = By.XPath("//select[@style='border-radius: 1px;']");
        By option_Admin = By.XPath("//option[@value='1']");
        By option_Staff = By.XPath("//option[@value='2']");

        public ManageUserPage(IWebDriver driver) : base(driver)
        {
        }

        public void ClickManageUser()
        {
            ClickElement(link_ManageUser);
        }

        public void SearchByValue(string value)
        {
            SendKey(searchBox, value);
        }

        public string getSearchResult()
        {
            return GetText(table_user);
        }

        public void FilterAdmin()
        {
            ClickElement(dropdown);
            ClickElement(option_Admin);
        }

        public void FilterStaff()
        {
            ClickElement(dropdown);
            ClickElement(option_Staff);
        }

        public string getFilterResult()
        {
            return GetText(table_user);
        }
    }
}

