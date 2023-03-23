Feature: Calculator
![Calculator](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
Simple calculator for adding **two** numbers

Link to a feature: [Calculator](SpecFlowIntro/Features/Calculator.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

Background:
Given that I have a Calculator

#@true
#Scenario: Add two numbers
#	Given the first number is 50
#	And the second number is 70
#	When the two numbers are added
#	Then the result should be 120
#
#@false
#Scenario: Add two numbers false
#	Given the first number is 50
#	And the second number is 70
#	When the two numbers are added
#	Then the result should not be 125
#
Scenario Outline: Adding 2 nums together

	When <num1> and <num2> are added
	Then the result should be <result>

 Examples: 
	| num1 | num2 | result |
	| 50   | 70   | 120    |
	| 30   | 70   | 105    |
