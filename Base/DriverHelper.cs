using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using static TestingFramework.Base.Browser;

namespace TestingFramework
{
    public class DriverHelper
    {
        public IWebDriver Driver { get; set; }
        public WebDriverWait wait;
        public string baseUrl = "https://projectplanappweb-stage.azurewebsites.net/login";

        public void GotoUrl()
        {
            //_webDriver.Navigate().GoToUrl(baseUrl);
            if (Driver.Url != baseUrl)
            {
                Driver.Url = baseUrl;
            }
        }
        public void Start()
        {
            Driver = GetDriver(Drivers.Chrome);
            GotoUrl();

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(70);
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(50));
        }
        public void Stop()
        {
            Driver.Close();
            Driver.Quit();
        }
    }
}
