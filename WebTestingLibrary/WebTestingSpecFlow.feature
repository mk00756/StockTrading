Feature: Sender and revcever testing
@Sender
Scenario: Add a stock
	Given I am on the add stock page
	And I have eenter a stock name and a stock price
	When I press the add button
	Then the stock shopuld apear in the table on the home page

Scenario: Update a Stock
	Given I am on the update stock page
	And I have eenter a stock name and a stock price
	When I press the update button button
	Then the stock price shuld update on the hopme page

Scenario: Remove Stock
	Given I am on the delete page
	And I have enterd a stock to delet
	When I click the delete button
	Then The strock should have been removed from the table

@Receaver
	Scenario: Serching for a stock
	Given I am on the home page of the receaver
	And I have entered in a stock to serch for
	When I click the serch buton
	Then The text should show the name of the stock I serched for