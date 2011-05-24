Scenario: Logging Interface will expose a Log.Message

	Given I want to log a message
	When I load the FatCat-Logger .dll
	Then I should have a method to log a message

Scenario: Logging Interface will expose a Log.Message with a string for a message

	Given I want to log a message
	When I load the FatCat-Logger .dll
	Then I should have a method to log a message taking a string

Scenario: Logging Interface will expose a Log.Message with a arguments

	Given I want to log a message
	When I load the FatCat-Logger .dll
	Then I should have a method to log a message taking a arguments