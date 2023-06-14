Feature: DeleteAccount
	Delete account

@positive
Scenario: User can Delete an account
	Given a logged in user is on Home page
	And user clicks on Accounts menu tab
	When user clicks on Delete button for an account
	Then the account is no longer displayed