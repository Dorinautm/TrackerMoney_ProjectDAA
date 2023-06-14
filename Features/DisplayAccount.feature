Feature: DisplayAccount
	Displays an account

@positive
Scenario: User can view an account
	Given a logged in user is on Home page
	And user clicks on Accounts menu tab
	When user clicks on any account type
	Then the coresponding accounts are displayed