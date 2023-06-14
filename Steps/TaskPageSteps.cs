/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TestingFramework.PageObjectModel;

namespace TestingFramework.Steps
{
    [Binding]
    public class TaskPageSteps
    {
        private DriverHelper _driverHelper;
        TasksPage taskPage;
        HomePage homePage;
        LogInPage logInPage;
        EmailPage emailPage;
        PasswordPage pwdPage;
        public TaskPageSteps(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
            taskPage = new TasksPage(_driverHelper.Driver, _driverHelper.wait);
            homePage = new HomePage(_driverHelper.Driver, _driverHelper.wait);
            logInPage = new LogInPage(_driverHelper.Driver, _driverHelper.wait);
            emailPage = new EmailPage(_driverHelper.Driver, _driverHelper.wait);
            pwdPage = new PasswordPage(_driverHelper.Driver, _driverHelper.wait);
        }

        [Given(@"a logged in User is on Tasks Page")]
        public void GivenALoggedInUserIsOnTasksPage()
        {
            logInPage.ClickLoginInBtn();
            emailPage.WriteEmail("automation.pp@amdaris.com");
            emailPage.PressNextBtn();
            pwdPage.WritePassword("10704-observe-MODERN-products-STRAIGHT-69112");
            pwdPage.PressNextBtn();
            pwdPage.ConfirmPassword();
            homePage.PressTaskBtn();
        }

        [When(@"user clicks ""(.*)"" button")]
        public void WhenUserClicksButton(string btnName)
        {
            taskPage.PressAddTaskBtn(btnName);
        }

        [When(@"user completes the form with valid data")]
        public void WhenUserCompletesTheFormWithValidData(Table table)
        {
            taskPage.CheckRequiredFields();

            dynamic data = table.CreateDynamicInstance();
            taskPage.AddSubject(data.subject);
            taskPage.SelectStatus(data.status);
            taskPage.SelectPriority(data.priority);
            taskPage.SelectValidDeadline();
            taskPage.SelectAssignee(data.assignedEmployee);
            taskPage.AddMessage(data.message);
        }

        [When(@"user clicks Save button")]
        public void WhenUserClicksSaveButton()
        {
            taskPage.SaveTask();
        }

        [Then(@"a success message is displayed ""(.*)""")]
        public void ThenASuccessMessageIsDisplayed(string succesMessage)
        {
            Thread.Sleep(2000);
            taskPage.AssertSuccesMessage(succesMessage);
        }
        // filter feature
        [When(@"user clicks on Filter icon")]
        public void WhenUserClicksOnFilterIcon()
        {
            taskPage.OpenFilters();
        }

        [When(@"inputs the name ""(.*)""")]
        public void WhenInputsTheName(string empName)
        {
            taskPage.FilterByName(empName);
        }

        [Then(@"are displayed only the tasks for the user ""(.*)""")]
        public void ThenIsDisplayedOnlyTheTasksForTheUser(string empName)
        {
            Thread.Sleep(4000);
            taskPage.AssertFilterEmployeeName(empName);
        }
        //EDIT
        [Given(@"a logged in User ""(.*)"" is on Tasks Page")]
        public void GivenALoggedInUserIsOnTasksPage(string empName)
        {
            logInPage.ClickLoginInBtn();
            emailPage.WriteEmail("automation.pp@amdaris.com");
            emailPage.PressNextBtn();
            pwdPage.WritePassword("10704-observe-MODERN-products-STRAIGHT-69112");
            pwdPage.PressNextBtn();
            pwdPage.ConfirmPassword();
            homePage.PressTaskBtn();
            WhenUserClicksOnFilterIcon();
            WhenInputsTheName(empName);
            ThenIsDisplayedOnlyTheTasksForTheUser(empName);
        }

        [When(@"user clicks on Edit icon")]
        public void WhenUserClicksOnEditIcon()
        {
            taskPage.OpenFilters();
            taskPage.FilterByName("Dorina Balaur");
            taskPage.PressEditBtn();
        }

        [When(@"changes the form data")]
        public void WhenChangesTheFormData(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            taskPage.SelectStatus(data.status);
        }
        //READ TASK
        [When(@"user opens a task")]
        public void WhenUserOpensATask()
        {
            taskPage.OpenFilters();
            taskPage.FilterByName("Dorina Balaur");
            taskPage.OpenTask();
        }

        [Then(@"the content of the task is displayed")]
        public void ThenTheContentOfTheTaskIsDisplayed()
        {
            taskPage.AssertTaskContent();
        }
        //DELETE TASK
        [When(@"user cliks the Delete icon")]
        public void WhenUserCliksTheDeleteIcon()
        {
            taskPage.OpenFilters();
            taskPage.FilterByName("Dorina Balaur");
            taskPage.ClickDeleteBtn();
        }

        [When(@"confirms on the pop-up")]
        public void WhenConfirmsOnThePop_Up()
        {
            taskPage.ConfirmDeletion();
        }
    }
}
*/