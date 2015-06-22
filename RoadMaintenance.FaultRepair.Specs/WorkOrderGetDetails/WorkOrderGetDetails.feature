Feature: WorkOrderGetDetails
	As an authorised staff member of the transport department
	I want to get the details of a captured work order
	In order to verify if it was captured correctly

@mytag
Scenario: Retrieve the details of a captured work order by ID
	Given I have created a work order as follows 
	| ID  | Description  |
	| WO1 | Work Order 1 |
	And The work order has the following tasks 
	| Description |
	| Task 1      |
	| Task 2      |
	| Task 3      |
	And And the work order has the following equipment 
	| Description | Number |
	| Tool 1      | 5      |
	And And the work order has the following material
	| Description | Amount | Measurement |
	| Material 1  | 5      | Kg          |
	| Material 2  | 100    | Liter       |
	When I retrieve the work order 
	Then the returned work order should have a Description of "Work Order 1"
	And the returned work order should have 3 tasks allocated
	And the returned work order should have 2 materials allocated
	And the returned work order should have 1 equipment allocated
