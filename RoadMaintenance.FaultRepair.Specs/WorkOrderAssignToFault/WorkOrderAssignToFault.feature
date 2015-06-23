Feature: WorkOrderAssignToFault
	As an authorised staff member of the transport department
	I want to assign a work order to a fault 
	In order for the fault to be fixed

@mytag
Scenario: Assign work order to fault
	Given I have a work order with id "WO1"
	When I assign the work order to fault id 50 
	And I search for all work orders related to fault id 50
	Then The system should return work order "WO1"
