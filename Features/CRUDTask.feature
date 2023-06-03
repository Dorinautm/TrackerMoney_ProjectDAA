Feature: CRUD Tasks
	Realizing the CRUD operations for Task feature

@positive
Scenario: User can succesfully add a new task
	Given a logged in User is on Tasks Page
	When user clicks "Add Task" button
	And user completes the form with valid data
	| subject            | status      | priority | assignedEmployee | message        |
	| Test for SeleniumF | In Progress | Medium   | Dorina Balaur    | This is a test |
	And user clicks Save button
	Then a success message is displayed "Activity Task has been successfully created."

@positive 
Scenario: User filters tasks by Employee
	Given a logged in User is on Tasks Page
	When user clicks on Filter icon 
	And inputs the name "Dorina Balaur"
	Then are displayed only the tasks for the user "Dorina Balaur"

@positive
Scenario: User can edit a task
	Given a logged in User is on Tasks Page
	When user clicks on Edit icon
	And changes the form data
	| status   |
	| Achieved |
	And user clicks Save button
	Then a success message is displayed "Activity Task was updated successfully!"

@positive
Scenario: User can read a task
	Given a logged in User is on Tasks Page
	When user opens a task
	Then the content of the task is displayed

@positive
Scenario: User can delete a task
	Given a logged in User is on Tasks Page
	When user cliks the Delete icon
	And confirms on the pop-up
	Then a success message is displayed "Activity deleted successfully"