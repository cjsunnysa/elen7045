Feature: WorkOrderCreation
	As an authorised staff member of the transport department
	I want to capture a work order for a logged fault

@mytag
Scenario: Create a basic work order
	Given I have the following work orders in the system
	| Description  |
	| Work Order 1 |
	When I create and add a work order 
	| Description  |
	| Work Order 2 |
	Then the result should be a new work order number
	And the work orders in the system should be 
	| Description  |
	| Work Order 1 |
	| Work Order 2 |

Scenario: Create a complex work order with tasks, equipment and materials
    Given I have no work orders in the system
	When I created a work order as follows 
	| Description  |
	| Work Order 2 |
	And I add the following tasks 
	| Description |
	| Task 1      |
	| Task 2      |
	| Task 3      |
	And I add the following equipment 
	| Description | Number |
	| Tool 1      | 5      |
	And I add the following material
	| Description | Amount | Measurement |
	| Material 1  | 5      | Kg          |
	| Material 2  | 100    | Liter       |
	Then the result should be a new work order number created
	And there should be 1 work order in the system

Scenario: An UnAuthorised person try to create work order
	Given My user has "Role 1" as a role, but not "WorkOrderCreationRole"
	When I try and create a work order 
	| Description  |
	| Work Order 2 |
	Then the result should be access denied


