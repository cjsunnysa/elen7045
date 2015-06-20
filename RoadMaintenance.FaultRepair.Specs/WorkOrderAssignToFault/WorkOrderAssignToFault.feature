Feature: WorkOrderAssignToFault
	As a work order creator
	I want to assign a work order to a fault that has been verified and does not have outstanding work orders
	In order to avoid assigning 2 work orders to the same fault

@mytag
Scenario: Assign work order to unverified fault
	Given I have a fault id 50
	And The status of the fault is not Verified
	When I query whether I can assign a work order to this fault
	Then the result should be false

Scenario: Assign work order to fault with outstanding work orders
	Given I have a fault id 51
	And The fault has outstanding work orders assigned to it
	When I query whether I can assign a work order to this fault
	Then the result should be false

Scenario: Assign work order to eligable fault
	Given I have a fault id 52 with status Verified
	And The fault has no outstanding work orders assigned to it
	When I query whether I can assign a work order to this fault
	Then the result should be true
