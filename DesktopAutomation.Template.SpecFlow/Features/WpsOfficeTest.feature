Feature: Demo

@demo 
Scenario: I format text
	When I launch WPS Office
	When I want to create document
	When I choose empty document
	When I enter 'Hello world' into editor '3' times
	When I make all text bold and underlining
	When I make center alignment and '5' spacing
	When I close WPS Office