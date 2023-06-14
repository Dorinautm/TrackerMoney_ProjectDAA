using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace TestingFramework.PageObjectModel
{
    public class AccountsPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public AccountsPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }
        private IWebElement _addAccountBtn => _driver.FindElement(By.XPath("(//button[normalize-space()='Add Account'])[1]"));
        private IWebElement _typeSelect => _driver.FindElement(By.XPath("(//button[normalize-space()='Select Type'])[1]"));
        private IWebElement _UpdatetypeSelect => _driver.FindElement(By.XPath("(//button[normalize-space()='cash'])[1]"));
        private IWebElement _colorSelect => _driver.FindElement(By.XPath("(//button[normalize-space()='Select Color'])[1]"));
        private IWebElement _UpdatecolorSelect => _driver.FindElement(By.XPath("(//button[normalize-space()='Red'])[1]"));
        private IWebElement _currencySelect => _driver.FindElement(By.XPath("(//button[normalize-space()='Select Currency'])[1]"));
        private IWebElement _UpdatecurrencySelect => _driver.FindElement(By.XPath("(//button[normalize-space()='mdl'])[1]"));
        private IWebElement _accName => _driver.FindElement(By.XPath("//input[@placeholder='Set Name']"));
        private IWebElement _accBalance => _driver.FindElement(By.XPath("//input[@id='initial_balance']"));
        private IWebElement _accUpdateBalance => _driver.FindElement(By.XPath("//input[@id='balance']"));
        private IWebElement _addBtn => _driver.FindElement(By.CssSelector("button[class='btn btn-outline-success']"));
        private IWebElement _cashAccCard => _driver.FindElement(By.XPath("(//div)[19]"));


        public void ClickAddAccount(string btnName)
        {
            var btn = _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//button[normalize-space()='Add Account'])[1]")));
            Assert.IsTrue(btn.Displayed);
            string btnText = _addAccountBtn.Text;
            Assert.IsTrue(btnText.Contains(btnName));

            _wait.Until(ExpectedConditions.ElementToBeClickable(_addAccountBtn)).Click();
        }

        public void SelectType(string type)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_UpdatetypeSelect)).Click();
            //_typeSelect.Click();
            _wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//div[@class='dropdown-menu show']")));
            IWebElement accountType = _driver.FindElement(By.XPath($"//a[contains(text(), '{type}')]"));
            _wait.Until(ExpectedConditions.TextToBePresentInElementLocated(By.XPath($"//a[contains(text(), '{type}')]"), type));
            accountType.Click();
            
        }
        public void UpdateSelectType(string type)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_typeSelect)).Click();
            //_typeSelect.Click();
            _wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//div[@class='dropdown-menu show']")));
            IWebElement accountType = _driver.FindElement(By.XPath($"//a[contains(text(), '{type}')]"));
            _wait.Until(ExpectedConditions.TextToBePresentInElementLocated(By.XPath($"//a[contains(text(), '{type}')]"), type));
            accountType.Click();
            
        }
        public void SelectColor(string color)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_colorSelect)).Click();
            _wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//div[@class='dropdown-menu show']")));
            IWebElement accountColor = _driver.FindElement(By.XPath($"//a[contains(text(), '{color}')]"));
            _wait.Until(ExpectedConditions.TextToBePresentInElementLocated(By.XPath($"//a[contains(text(), '{color}')]"), color));
            accountColor.Click();
            
        }
        public void UpdateSelectColor(string color)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_UpdatecolorSelect)).Click();
            _wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//div[@class='dropdown-menu show']")));
            IWebElement accountColor = _driver.FindElement(By.XPath($"//a[contains(text(), '{color}')]"));
            _wait.Until(ExpectedConditions.TextToBePresentInElementLocated(By.XPath($"//a[contains(text(), '{color}')]"), color));
            accountColor.Click();
            
        }
        public void SelectCurrency(string currency)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_currencySelect)).Click();
            _wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//div[@class='dropdown-menu show']")));
            IWebElement accountCurrency = _driver.FindElement(By.XPath($"//a[contains(text(), '{currency}')]"));
            _wait.Until(ExpectedConditions.TextToBePresentInElementLocated(By.XPath($"//a[contains(text(), '{currency}')]"), currency));
            accountCurrency.Click();
           
        }
        public void UpdateSelectCurrency(string currency)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_UpdatecurrencySelect)).Click();
            _wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//div[@class='dropdown-menu show']")));
            IWebElement accountCurrency = _driver.FindElement(By.XPath($"//a[contains(text(), '{currency}')]"));
            _wait.Until(ExpectedConditions.TextToBePresentInElementLocated(By.XPath($"//a[contains(text(), '{currency}')]"), currency));
            accountCurrency.Click();
           
        }
        public void SetName(string accountName)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_accName)).Click();
            _wait.Until(ExpectedConditions.ElementToBeClickable(_accName)).SendKeys(accountName);
        }
        public void SetBalance(int accountBalance)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_accBalance)).Click();
            _wait.Until(ExpectedConditions.ElementToBeClickable(_accBalance)).SendKeys("100");
        } 
        public void SetUpdatedBalance(int accountBalance)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_accUpdateBalance)).Click();
            _wait.Until(ExpectedConditions.ElementToBeClickable(_accUpdateBalance)).SendKeys("500");
        }
        public void ClickAddAccount()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_addBtn)).Click();
        }

        public void CheckAccountIsDisplayed()
        {
            _wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//div[@class='d-flex row']")));
            IWebElement foundAccount = _driver.FindElement(By.CssSelector("div[class='account-name']"));
        }
        public void ClickOnCashAccount()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[normalize-space()='cash']"))).Click();
      
        }
        public void ClickCashAccIsDisplayed()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[normalize-space()='cash']"))).Click();

            Actions actions = new Actions(_driver);
            actions.MoveToElement(_cashAccCard).Perform();
            _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[normalize-space()='Edit']"))).Click();
            var cashText = _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//button[normalize-space()='cash'])[1]")));
            Assert.AreEqual(cashText.Text, "cash");
        }

        public void ClickEditCashAccount()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[normalize-space()='cash']"))).Click();

            Actions actions = new Actions(_driver);
            actions.MoveToElement(_cashAccCard).Perform();
            _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[normalize-space()='Edit']"))).Click();
        }

        public void SaveUpdates()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[normalize-space()='Save changes']"))).Click();

        }
        public void ClickDeleteCashAccount()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[normalize-space()='cash']"))).Click();

            Actions actions = new Actions(_driver);
            actions.MoveToElement(_cashAccCard).Perform();
            _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[normalize-space()='Delete']"))).Click();
        }

    }
}
