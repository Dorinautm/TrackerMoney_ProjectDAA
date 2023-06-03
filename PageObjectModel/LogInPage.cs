using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingFramework.Base;

namespace TestingFramework.PageObjectModel
{
    public class LogInPage
    {
        private readonly WebDriverWait _wait;
        private readonly IWebDriver _Driver;

        public LogInPage(IWebDriver driver, WebDriverWait wait)
        {
            _Driver = driver;
            _wait = wait;
        }
        public IWebElement logInBtn => _Driver.FindElement(By.CssSelector("div .button > span"));

        public void ClickLoginInBtn()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(logInBtn)).Click();
        }
    }
}
