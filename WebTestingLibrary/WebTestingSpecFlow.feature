Feature: SpecFlowWebTesting

@ReceaverTesting
Scenario: Clicking the serch button on the receaver
	Given I am on the right page
	When I press the serch button
	Then The data apears in the table

Scenario: Adding a stock using the sender
	Given I am on the add page on the sender
	When A stock name is entered in the name box
	When A price is added in the price box
	When I click the add button
	Then the stock should apear in the table on the home page