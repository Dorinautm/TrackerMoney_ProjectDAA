﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingFramework.PageObjectModel
{
    public class PasswordPage
    {
        private readonly WebDriverWait _wait;
        private readonly IWebDriver _driver;

        public PasswordPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }
        private IWebElement _passwordField => _driver.FindElement(By.XPath("//input[@name='passwd']"));
        private IWebElement _nextBtn => _driver.FindElement(By.XPath("//input[@type='submit']"));
        private IWebElement _confirmBtn => _driver.FindElement(By.XPath("//input[@type='submit']"));

        public void WritePassword(string password)
        {
            //_wait.Until(ExpectedConditions.ElementToBeClickable(_passwordField)).SendKeys(password);           
            _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@name='passwd']"))).SendKeys(password);
        }
        public void PressNextBtn()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_nextBtn)).Click();
        }
        public void ConfirmPassword()
        {
            _wait.Until(ExpectedConditions.ElementExists(By.XPath("//input[@type='submit']"))).Click();
        }
    }
}
