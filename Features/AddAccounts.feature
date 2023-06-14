Feature: Add anAccounts
	Scenarious for creating accounts

@positive
Scenario: User can Add an account
	Given a logged in user is on Home page
	And user clicks on Accounts menu tab
	When user clicks on Add Account button
	And user completes the form
	| SelectType | SelectColor | SelectCurrency | SetName       | SetInitialBalance |
	| cash       | Red         | mdl            | account_name_ | 100               |
	And clicks Add button
	Then the account is created and displayed in Accounts tab


