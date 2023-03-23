Feature: Login Feature
    As a client I can log into the website
# BeforeAll: I open the login page

Scenario: Successfully Log into E2E scenario
Given I open the login page
When I enter the username "tomsmith"
And I enter the password "SuperSecretPassword!"
And I click on the login button
Then A successful message is displayed

Scenario: Unsuccessfully username Log into E2E scenario
Given I open the login page
When I enter the username ""
And I enter the password "SuperSecretPassword!"
And I click on the login button
Then A unsuccessful username message is displayed

# Scenario: Unsuccessfully password Log into E2E scenario
# Given I open the login page
# When I enter the username "tomsmith"
# And I enter the password ""
# And I click on the login button
# Then A unsuccessful password message is displayed