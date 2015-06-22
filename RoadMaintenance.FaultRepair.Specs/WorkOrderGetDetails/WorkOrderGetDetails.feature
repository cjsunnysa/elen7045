Feature: WorkOrderGetDetails
	As an authorised staff member of the transport department
	I want to get the details of a captured work order
	In order to verify if it was captured correctly

@mytag
Scenario: Retrieve the details of a captured work order by ID
	Given The system has a work order
	| ID  | Description  |
	| WO1 | Work Order 1 |
	And the work order has tasks 
	| Description |
	| Task 1      |
	| Task 2      |
	| Task 3      |
	And the work order has equipment 
	| Description | Number |
	| Tool 1      | 5      |
	And the work order has material 
	| Description | Amount | Measurement |
	| Material 1  | 5      | Kg          |
	| Material 2  | 100    | Liter       |
	When I retrieve the work order details by ID "WO1" 
	Then the returned work order should have a Description of "Work Order 1", with 3 tasks, 2 materials and 1 equipment allocated
