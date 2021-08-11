Feature: Multiplication
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the product of two numbers

@mytag
Scenario: Substract two numbers
	Given I have entered 20 into the calculator
	And I have entered 10 into the calculator
	When I press multiply
	Then the result should be 200 on the screen
