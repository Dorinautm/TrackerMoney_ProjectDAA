using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TestingFramework.PageObjectModel;

namespace TestingFramework.Steps
{
    [Binding]
    public class AccountsSteps

    {
        private DriverHelper _driverHelper;
        HomePage homePage;
        LogInPage logInPage;
        AccountsPage accountsPage;

        public AccountsSteps(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
            homePage = new HomePage(_driverHelper.Driver, _driverHelper.wait);
            logInPage = new LogInPage(_driverHelper.Driver, _driverHelper.wait);
            accountsPage = new AccountsPage(_driverHelper.Driver, _driverHelper.wait);
        }

        [Given]
        public void GivenALoggedInUserIsOnHomePage()
        {
            logInPage.ClickLoginInBtn();
            logInPage.ClickLoginInBtn();

            logInPage.WriteEmail("dorina@mail.com");
            logInPage.WritePassword("dorina123");
            logInPage.ClickLoginInBtnForm();
        }
        
        [Given]
        public void GivenUserClicksOnAccountsMenuTab()
        {
            homePage.PressAccountBtn();

        }
        
        [When]
        public void WhenUserClicksOn_P0_Button(string addAccBtn)
        {
            accountsPage.ClickAddAccount(addAccBtn);
        }

        [When]
        public void WhenUserCompletesTheForm(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            accountsPage.SelectType(data.SelectType);
            accountsPage.SelectColor(data.SelectColor);
            accountsPage.SelectCurrency(data.SelectCurrency);
            accountsPage.SetName(data.SetName);
            accountsPage.SetBalance(data.SetInitialBalance);
        }

        [Then]
        public void ThenTheAccountIsCreatedAndDisplayedInAccountsTab()
        {
            accountsPage.CheckAccountIsDisplayed();
        }

        [When]
        public void WhenClicksAddButton()
        {
            accountsPage.ClickAddAccount();
        }
        
        [When]
        public void WhenUserClicksOnAnyAccountType()
        {
            accountsPage.ClickOnCashAccount();
        }

        [Then]
        public void ThenTheCorespondingAccountsAreDisplayed()
        {
            accountsPage.ClickCashAccIsDisplayed();
        }

        [When]
        public void WhenUserClicksOnEditButtonForAnAccount()
        {
            accountsPage.ClickEditCashAccount();

        }
        
        [When]
        public void WhenUpdatesTheForm(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            accountsPage.SelectType(data.SelectType);
            accountsPage.SelectColor(data.SelectColor);
            accountsPage.SelectCurrency(data.SelectCurrency);
            accountsPage.SetName(data.SetName);
            accountsPage.SetUpdatedBalance(data.SetInitialBalance);
        }

        [When(@"clicks Save changes button")]
        public void WhenClicksSaveChangesButton()
        {
            accountsPage.SaveUpdates();
        }


        [Then]
        public void ThenTheAccountIsUpdatedAndDisplayedInAccountsTab()
        {
            accountsPage.CheckAccountIsDisplayed();
        }

        [When(@"user clicks on Delete button for an account")]
        public void WhenUserClicksOnDeleteButtonForAnAccount()
        {
            accountsPage.ClickDeleteCashAccount();
        }

        [Then]
        public void ThenTheAccountIsNoLongerDisplayed()
        {
            Console.WriteLine("Cash acc deleted");
        }
    }
}
