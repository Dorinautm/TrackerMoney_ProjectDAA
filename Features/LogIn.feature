Feature: LogIn
	Log in into Advance

@positive
Scenario: Perform Login into TrackerApp
	Given I launch the application
	When I click Login button
	And Input the credentials
	| email             | password  |
	| dorina@mail.com	| dorina123 |
	And I click LogIn button
	Then I should see the Home Page