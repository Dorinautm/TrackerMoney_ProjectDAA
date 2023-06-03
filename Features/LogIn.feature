Feature: LogIn
	Log in into Advance

@positive
Scenario: Perform Login into Advance
	Given I launch the application
	When I click Login button
	And Input the credentials
	| email                     | password                                     |
	| automation.pp@amdaris.com | 10704-observe-MODERN-products-STRAIGHT-69112 |
	And I click Next button
	And I agree on the next page
	Then I should see the Home Page