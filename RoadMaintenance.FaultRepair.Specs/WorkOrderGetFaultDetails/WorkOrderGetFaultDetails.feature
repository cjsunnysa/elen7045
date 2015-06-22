Feature: WorkOrderGetFaultDetails
	As a work order creator
	I want to drill down into the details of a fault by viewing the report card
	In order to get more details on the fault

@mytag
Scenario: Get report card for fault
	Given These faults were previously logged	
	| Id | Street     | CrossStreet | Suburb  | PostCode | StatusId | TypeId | Priority |
	| 1  | Sandton Dr | Grayston Dr | Sandton | 2196     | 1        | 1      | 1        |
	| 27 | 10th St    | null        | Sandton | 2195     | 1        | 2      | 1        |
	And   These report cards were created	
	| Id | Fault ID | Description             |
	| 1  | 1        | Report Card for Fault 1 |
	| 2  | 27       | Report Card for Fault 2 |
	When  I fetch the report card details for fault id 1  
	Then  The results should be
	| Id | Fault ID | Description             |
	| 1  | 1        | Report Card for Fault 1 |
