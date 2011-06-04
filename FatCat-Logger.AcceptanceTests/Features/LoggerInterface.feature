﻿Scenario: Logging Interface will expose a Log.Message

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

Scenario: Logging Interface will expose a Log.Exception for logging exceptions

    Given I want to log an exception
    When I load the FatCat-Logger .dll
    Then I should have a method to log an exception

Scenario: Logging Interface will expose a Log.Exception for logging exceptions and accept an exception

    Given I want to log an exception
    When I load the FatCat-Logger .dll
    Then I should have a method to log an exception and accepts an exception

Scenario: Logging Interface will expose a Log.EventViewer for logging messages to the event viewer

    Given I want to log an event viewer message
    When I load the FatCat-Logger .dll
    Then I should have a method to log to the event viewer

Scenario: Logging Interface will expose a Log.EventViewer accepting a event viewer id, message, and arguments

    Given I want to log an event viewer message
    When I load the FatCat-Logger .dll
    Then I should have a method to log to the event viewer accepting an event viewer id, message, and arguments

Scenario: Logging Interface has a Log Level Enumeration
    
    Given I have an enumeration named LogLevel
    When I select [name]
    Then the number value is [value]

Examples:
|name|value|
|Exceptions|0|
|Errors|1|
|Warnings|2|
|Low|3|
|Medium|4|
|High|5|
|Full|6|
|Super|7|
|Debug|8|
