using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace TestingFramework.Base
{  
    public static class Browser
    {
        public enum Drivers
        {
            Chrome
        }
        public static IWebDriver GetDriver(Drivers driver)
        {
            switch (driver)
            {
                case Drivers.Chrome:
                    ChromeOptions options = new ChromeOptions();
                    options.AddArguments("--incognito");
                    options.AddArgument("--start-maximized");
                    options.AddArguments("--testing");
                    options.AddArguments("--disable-translate");
                    options.AddArguments("--disable-plugins");
                    options.AddArguments("--suppress-message-center-popups");
                    return new ChromeDriver(options);
                default:
                    throw new NotImplementedException("Driver not found.");
            }                      
        }
    }
}
