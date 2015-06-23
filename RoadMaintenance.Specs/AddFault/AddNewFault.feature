﻿Feature: AddNewFault
	In order to track and repair road faults
	As a call-center operator
	I want to add new faults

@mytag
Scenario: Add a new fault
	Given I am on the add fault page
	And I enter 'Rivonia Rd' as the street name
	And I enter 'Sandton Drive' as the cross street name
	And I enter 'Sandton' as the suburb name
	And I select 'Pothole' as the fault type
	When I press the Create button
	Then result should contain these details
	And the result has a new unique identifier
	And the result has 'Pending Investigation' as the status