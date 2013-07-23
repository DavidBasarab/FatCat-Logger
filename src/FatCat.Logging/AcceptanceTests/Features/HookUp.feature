Feature: Basic Hook'em
	In order to amake sure everything is set up for the test to run
	As a developer
	I want to make sure all I need to run all the acceptance tests are up and running.

@hookup
Scenario: Basic specflow run
	Given I have specflow referenced
    When I run this test
	Then each step is executed

@hookup
Scenario: Will be able to write to file system.
    Given have access to the file system
    When a file is written to the sytem
    Then the file is written to the file system

@hookup
Scenario: Will be able to delete from the file system
    Given a file is written to the system
    When a file is deleted from the system
    Then the file is deleted