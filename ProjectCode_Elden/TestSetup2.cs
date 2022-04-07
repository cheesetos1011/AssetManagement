using Framework.Driver;
using Framework.HTMLReport;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using ProjectCode.Services;
using System;
using System.IO;

namespace Framework
{

    public class TestSetup2 : TestSetup
    {
        public string _token { get; set; }


        public TestSetup2(string browser, string osPlatform) : base(browser, osPlatform)
        {
        }

        [SetUp]
        public void SetUp()
        {
            AuthenticationService authenService = new AuthenticationService();
            _token = authenService.Login("admin", "admin@01012000").token;
        }

    }
}
