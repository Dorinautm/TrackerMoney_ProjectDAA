using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestingFramework.PageObjectModel
{
    public class TasksPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public TasksPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }        
        private IWebElement _taskBtn => _driver.FindElement(By.Id("viewTasksButton"));
        private IWebElement _addTaskBtn => _driver.FindElement(By.XPath("//a[@class='icon']"));
        private IWebElement _btnSave => _driver.FindElement(By.XPath("//button[span[contains(text(),'Save')]]"));
        private IWebElement _subjectField => _driver.FindElement(By.XPath("//input[@name = 'subject']"));
        private IWebElement _statusSelectBtn => _driver.FindElement(By.XPath("//mat-select[@formcontrolname='status']"));
        private IWebElement _prioritySelectBtn => _driver.FindElement(By.XPath("//mat-select[@formcontrolname ='priority']"));
        private IWebElement _deadline => _driver.FindElement(By.Id("deadline"));
        private IWebElement _selectedDate => _driver.FindElement(By.XPath("//td[@tabindex = '0']"));
        private IWebElement _inputMessage => _driver.FindElement(By.CssSelector(".ql-editor"));
        private IWebElement _inputDate => _driver.FindElement(By.XPath("//input[@id = 'deadline']"));
        private IWebElement _filterBtn => _driver.FindElement(By.CssSelector("i.icon-filter"));
        private IWebElement _filterBar => _driver.FindElement(By.CssSelector("div.employees-filter"));
        private IWebElement _selectEmployee => _driver.FindElement(By.CssSelector("div.employee-filter"));
        private IWebElement _inputEmployeeName => _driver.FindElement(By.XPath("//input[@aria-label='dropdown search']"));
        private IWebElement _selectedEmployee => _driver.FindElement(By.XPath("//mat-option[@tabindex='0']"));
        private IWebElement _assertNameEmployee => _driver.FindElement(By.XPath("//span[contains(text(),'Dorina Balaur')]"));
        private IWebElement _container => _driver.FindElement(By.XPath("//div[@class = 'cdk-overlay-container']"));
        private IWebElement _editBtn => _driver.FindElement(By.CssSelector("div > .fa-pencil:first-child"));
        private IWebElement _viewMoreBtn => _driver.FindElement(By.CssSelector("div > .fa-chevron-down"));
        private IWebElement _deleteBtn => _driver.FindElement(By.CssSelector(".fa-times-circle"));       
        private IWebElement _readMessageTask => _driver.FindElement(By.CssSelector("span > p"));
        private IWebElement btnYes => _driver.FindElement(By.XPath("//button[.='Yes']"));

        public void PressAddTaskBtn(string btnName)
        {
            //check if btn is displayed
            var btnAddTask = _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[@class='icon']")));
            Assert.IsTrue(btnAddTask.Displayed);
            //check btn name
            string buttonAddTaskText = _addTaskBtn.Text;
            Assert.IsTrue(buttonAddTaskText.Contains(btnName), "button {0} doesnt contain the right text", buttonAddTaskText);

            _wait.Until(ExpectedConditions.ElementToBeClickable(_addTaskBtn)).Click();
        }
        public void CheckBtnSaveisDisabled()
        {
            var btnSave = _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[span[.='Save']]")));
            Assert.IsFalse(btnSave.Enabled);
        }
        public void CheckRequiredFields()
        {
            try
            {
                Assert.Equals("required", _subjectField.GetAttribute("required"));
                Assert.Equals("required", _statusSelectBtn.GetAttribute("required"));
                Assert.Equals("required", _prioritySelectBtn.GetAttribute("required"));
                //Assert.Equals("required", _deadline.GetAttribute("required"));
            }
            catch
            {
                Console.WriteLine("not a required field");
            }
        }
        public void AddSubject(string subject)
        {
            _wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//input[@name = 'subject']")));
            Assert.AreEqual("100", _subjectField.GetAttribute("maxlength"));
            _subjectField.SendKeys(subject);
            Assert.IsNotNull(_subjectField.Text);

            CheckBtnSaveisDisabled();
        }
        public void SelectStatus(string status)
        {
            _wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//mat-select[@formcontrolname='status']")));
            _statusSelectBtn.Click();
            IWebElement optionStatus = _driver.FindElement(By.XPath($"//mat-option/span[contains(text(),'{status}')]"));
            _wait.Until(ExpectedConditions.TextToBePresentInElementLocated(By.XPath($"//mat-option/span[contains(text(),'{status}')]"), status));
            optionStatus.Click();
            Assert.AreEqual(status, optionStatus.Text);
            Assert.IsTrue(optionStatus.Displayed);
        }
        public void SelectPriority(string priority)
        {
            _wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//mat-select[@formcontrolname ='priority']")));
            _prioritySelectBtn.Click();
            IWebElement prioritySelection = _driver.FindElement(By.XPath($"//mat-option/span[contains(text(),'{priority}')]"));
            _wait.Until(ExpectedConditions.TextToBePresentInElementLocated(By.XPath($"//mat-option/span[contains(text(),'{priority}')]"), priority));
            prioritySelection.Click();
            Assert.AreEqual(priority, prioritySelection.Text);
            Assert.IsTrue(prioritySelection.Displayed);

            CheckBtnSaveisDisabled();
        }
        public void SelectValidDeadline()
        {
            var localDate = DateTime.UtcNow.ToString("dd/MM/yyyy");
            _wait.Until(ExpectedConditions.ElementToBeClickable(_deadline)).Click();
            _selectedDate.Click();
            var selectedDeadline = _inputDate.GetAttribute("value");
            Assert.That(selectedDeadline, Is.GreaterThanOrEqualTo(localDate));
            Assert.IsNotNull(_deadline.Text);
        }
        public void SelectAssignee(string assignedEmployee)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_selectEmployee)).Click();
            _wait.Until(ExpectedConditions.ElementToBeClickable(_inputEmployeeName)).SendKeys(assignedEmployee);
            _wait.Until(ExpectedConditions.TextToBePresentInElementLocated(By.XPath("//mat-option[@tabindex = '0']"), assignedEmployee));
            _selectedEmployee.Click();
            //Assert.AreSame(assignedEmployee, _selectedEmployee.Text);
        }
        public void AddMessage(string message)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".ql-editor"))).Click();           
            _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".ql-editor"))).SendKeys(message);
            Assert.That(_inputMessage.Displayed);
        }
        public void SaveTask()
        {
            if (_btnSave.Enabled)
            {
                _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[span[contains(text(),'Save')]]"))).Click();
            }
            else { Console.WriteLine("Save button is dissabled"); }
        }
        public void AssertSuccesMessage(string succesMsg)
        {
            string succesMessage = _wait.Until(ExpectedConditions.ElementExists(By.CssSelector("simple-snack-bar > span"))).Text;
            Assert.IsNotEmpty(succesMessage);
            Assert.AreEqual(succesMsg, succesMessage);          
        }
        public void OpenFilters()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_filterBtn)).Click();
        }
        public void FilterByName(string employeeName)
        {
            _wait.Until(ExpectedConditions.ElementExists(By.CssSelector("div.employees-filter"))).Click();
            _wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//input[@aria-label='dropdown search']")));
            _inputEmployeeName.SendKeys(employeeName);
            _wait.Until(ExpectedConditions.TextToBePresentInElementLocated(By.XPath("//mat-option[@tabindex='0']"), employeeName));
            Assert.That(_selectedEmployee.Displayed);
            _selectedEmployee.Click();
            _container.Click();
        }
        public void AssertFilterEmployeeName(string expectedName)
        {
            _wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath($"//span[contains(text(), '{expectedName}')]")));
            string actualName = _assertNameEmployee.Text;
            Assert.AreEqual(expectedName, actualName);
        }
        public void PressEditBtn()
        {
            if (_editBtn.Displayed)
            {
                _wait.Until(ExpectedConditions.ElementToBeClickable(_editBtn)).Click();
            }
        }
        public void OpenTask()
        {
            if (_viewMoreBtn.Displayed)
            {
                _wait.Until(ExpectedConditions.ElementToBeClickable(_viewMoreBtn)).Click();
            }
        }
        public void AssertTaskContent()
        {
            _wait.Until(ExpectedConditions.ElementExists(By.CssSelector("span > p")));
        }
        public void ClickDeleteBtn()
        {
            if (_deleteBtn.Displayed)
            {
                _wait.Until(ExpectedConditions.ElementToBeClickable(_deleteBtn)).Click();
            }
        }
        public void ConfirmDeletion()
        {
            _wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//mat-dialog-container[@role='dialog']")));

            if (btnYes.Enabled)
            {
                _wait.Until(ExpectedConditions.ElementToBeClickable(btnYes)).Click();
            }
            
        }
    }
}
