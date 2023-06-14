using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TestingFramework.Base;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace TestingFramework.Hooks
{
    [Binding]
    public sealed class Hooks 
    {
        private readonly DriverHelper _driverHelper;
        private readonly ScenarioContext scenarioContext;

        private static ExtentTest _featureName;
        private static ExtentTest _scenario;
        private static ExtentReports extentReport;

        public Hooks(DriverHelper driverHelper, ScenarioContext scenariocontext)
        {
            _driverHelper = driverHelper;
            scenarioContext = scenariocontext;
        }

        [BeforeTestRun]
        public static void InitializeReport()
        {
            var htmlReport = new ExtentHtmlReporter(@"C:\Users\dorina.balaur\Desktop\tests\DAA_Tracker\TrackerAutomationTests\ExtentREport.html");
            extentReport = new ExtentReports();
            extentReport.AttachReporter(htmlReport);
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            extentReport.Flush();
        }

        [AfterStep]
        public void InsertReportingSteps()
        {
            var stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
      
            if (scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                    _scenario.CreateNode<Given>(scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "When")
                    _scenario.CreateNode<When>(scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "Then")
                    _scenario.CreateNode<Then>(scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "And")
                    _scenario.CreateNode<And>(scenarioContext.StepContext.StepInfo.Text);
            }
            else if (scenarioContext.TestError != null)
            {
                if (stepType == "Given")
                    _scenario.CreateNode<Given>(scenarioContext.StepContext.StepInfo.Text).Fail(scenarioContext.TestError.Message);
                else if (stepType == "When")
                    _scenario.CreateNode<When>(scenarioContext.StepContext.StepInfo.Text).Fail(scenarioContext.TestError.Message);
                else if (stepType == "Then")
                    _scenario.CreateNode<Then>(scenarioContext.StepContext.StepInfo.Text).Fail(scenarioContext.TestError.Message);
            }
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            _featureName = extentReport.CreateTest(featureContext.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void Initialize()
        {
            _driverHelper.Start();
           
            _scenario = _featureName.CreateNode(scenarioContext.ScenarioInfo.Title);
        }

        [AfterScenario]
        public void TearDown()
        {
            _driverHelper.Stop();            
        }
    }
}
