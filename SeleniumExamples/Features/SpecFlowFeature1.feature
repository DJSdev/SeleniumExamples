Feature:SearchForRedditOnGoogle
	In order to feel superior
	As an idiot
	I want to search for reddit on Google.com instead of typing reddit.com

Background:
	Given that 2 + 2 equals 4

Scenario: Search for reddit on Google
	Given I navigate to google.com
	And I type reddit into the search bar
	When I press the search button
	Then I see the result screen display
	When I click on the first result with https://www.reddit.com/ in the result
	Then I am taken to reddit.com
