using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TestingFramework.PageObjectModel;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow.Assist;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;

namespace TestingFramework.Steps
{
    [Binding]
    public class LogInSteps 
    {   
        private DriverHelper _driverHelper;
        LogInPage logInPage;

        HomePage homePage;
        public LogInSteps(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
            logInPage = new LogInPage(_driverHelper.Driver, _driverHelper.wait);

            homePage = new HomePage(_driverHelper.Driver, _driverHelper.wait);
        }

        [Given(@"I launch the application")]
        public void GivenILaunchTheApplication()
        {
            logInPage = new LogInPage(_driverHelper.Driver, _driverHelper.wait);
        }
        
        [When(@"I click Login button")]
        public void GivenIClickLoginButton()
        {
           logInPage.ClickLoginInBtn();
           logInPage.ClickLoginInBtn();
        }

        [When(@"Input the credentials")]
        public void WhenInputTheCredentials(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            logInPage.WriteEmail(data.email);
            logInPage.WritePassword(data.password);          
        }

        [When(@"I click LogIn button")]
        public void WhenIClickLogInButton()
        {
            logInPage.ClickLoginInBtnForm();
        }

        [Then(@"I should see the Home Page")]
        public void ThenIShouldSeeTheHomePage()
        {
            homePage.CheckPageTitle("FinanceTracker");
        }

    }
}
