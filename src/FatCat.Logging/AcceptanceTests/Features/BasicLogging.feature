Feature: BasicLogging
	In to do basic logging with no configuration
	As a developer
	I want to be able to log messages to a text file wih just referencing the FatCat.Logging.dll and no configuration required

Background: 
    Given I have nothing setup in the configuration
    Given the application has no log files

Scenario: First write will create the file based on the application name
    When I write message "This is the first message"
    Then a file is created matching the name of the application

Scenario: Write will create a file with only one line and a simple message
    When I write message "This is the first message"
    Then the file contains only one line
    And the file contains the message "This is the first message"