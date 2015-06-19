Feature: WorkOrderViewFaults
	As a work order creator
	I want view all logged faults with their priority
	In order to choose which one to create a work order for

@mytag
Scenario: View all logged faults
	Given These faults were previously logged	
	| Id | Street     | CrossStreet | Suburb  | PostCode | StatusId | TypeId | Priority |
	| 1  | Sandton Dr | Grayston Dr | Sandton | 2196     | 1        | 1      | 1        |
	| 27 | 10th St    | null        | Sandton | 2195     | 1        | 2      | 1        |
	And   These faults were previously logged	
	| Id | Street      | CrossStreet | Suburb   | PostCode | StatusId | TypeId | Priority |
	| 47 | 8th Street  | null        | Randburg | 2195     | 1        | 3      | 2        |
	| 52 | Hill Street | null        | Randburg | 2195     | 5        | 1      | 3        |
	When  I view all logged faults 
	Then  The results should be
	| Id | Street      | CrossStreet | Suburb   | PostCode | StatusId | TypeId | Priority |
	| 1  | Sandton Dr  | Grayston Dr | Sandton  | 2196     | 1        | 1      | 1        |
	| 27 | 10th St     | null        | Sandton  | 2195     | 1        | 2      | 1        |
	| 47 | 8th Street  | null        | Randburg | 2195     | 1        | 3      | 2        |
	| 52 | Hill Street | null        | Randburg | 2195     | 5        | 1      | 3        |



