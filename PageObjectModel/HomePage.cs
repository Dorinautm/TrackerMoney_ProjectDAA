using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingFramework.PageObjectModel
{
    public class HomePage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public HomePage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }
        private IWebElement _taskBtn => _driver.FindElement(By.Id("viewTasksButton"));
        public void PressTaskBtn()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_taskBtn)).Click();
        }
        public void CheckPageTitle(string title)
        {
            Assert.AreEqual(title, _driver.Title);
        }
    }
}
