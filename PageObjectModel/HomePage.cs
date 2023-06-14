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
        private IWebElement _accountsBtn => _driver.FindElement(By.XPath("//button[normalize-space()='Accounts']"));
        private IWebElement _titlepage => _driver.FindElement(By.CssSelector("a[class='active'] h4"));
        public void PressAccountBtn()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_accountsBtn)).Click();
        }
        public void CheckPageTitle(string title)
        {
            var titleDisplayed = _wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("a[class='active'] h4")));
            Assert.IsTrue(titleDisplayed.Displayed);

            string titleText = _titlepage.Text;
            Assert.IsTrue(titleText.Contains(title), "Title {0} doesnt contain the right text", titleText);

        }
    }
}
