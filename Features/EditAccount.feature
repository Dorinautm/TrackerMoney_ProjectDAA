Feature: EditAccount
	Edits account

@positive
Scenario: User can Edit an account
	Given a logged in user is on Home page
	And user clicks on Accounts menu tab
	When user clicks on Edit button for an account
	And updates the form
	| SelectType | SelectColor | SelectCurrency | SetName       | SetInitialBalance |
	| debitcard  | purple      | mdl            | account_name  | 200               |
	And clicks Save changes button
	Then the account is updated and displayed in Accounts tab