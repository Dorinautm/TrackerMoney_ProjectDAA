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
        public IWebElement _logInBtn => _Driver.FindElement(By.CssSelector("button[type='button']"));
       // public IWebElement _passEmail => _Driver.FindElement(By.XPath("(//input[@placeholder='Enter your e-mail...'])[1]"));
        //public IWebElement _passPassword => _Driver.FindElement(By.XPath("(//input[@placeholder='Enter your password...'])[1]"));
        public IWebElement _logInCredentialsBtn => _Driver.FindElement(By.XPath("(//button[@class='btn btn-outline-success'])[1]"));
        

        public void ClickLoginInBtn()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_logInBtn)).Click();
        }

        public void WriteEmail(string email)
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//input[@placeholder='Enter your e-mail...'])[1]"))).SendKeys(email);
        }
        public void WritePassword(string password)
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//input[@placeholder='Enter your password...'])[1]"))).SendKeys(password);
        }
        public void ClickLoginInBtnForm()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_logInCredentialsBtn)).Click();
        }
    }
}
