Feature: AddNewFault
	In order to track and repair road faults
	As a call-center operator
	I want to add new faults

@mytag
Scenario: Add a new fault
	Given I am a 'CallCenterOperator' user role
	And I enter 'Rivonia Rd' as the street name
	And I enter 'Sandton Drive' as the cross street name
	And I enter 'Sandton' as the suburb name
	And I enter 'Pothole formed with water spewing onto the road.' as the description
	And I select 'Normal' as the fault priority
	And I select 'Pothole' as the fault type
	When I press the Create button
	And I perform a find for this fault id
	Then result should contain these details
	And the result has 'Pending Investigation' as the status
