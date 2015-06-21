Feature: ReallocateWorkOrder
	In order to enable me to balance workload
	As a dispatcher
	I want to be able to reallocate work orders to different teams


Scenario: Reallocate work order to team with no other work orders scheduled
	Given I have a work order with id 0	
	And I have a repair team with id 1 and the following schedule	
	| WorkOrderID | StartTime          | EndTime            |
	| 0           | "2014-01-06 08:00" | "2014-01-06 14:00" |
	| 1           | "2014-01-07 08:00" | "2014-01-08 12:00" |
	| 2           | "2014-01-08 14:00" | "2014-01-09 13:00" |
	And I have a repair team with id 2 and the following schedule		
	| WorkOrderID | StartTime          | EndTime            |		
	When I reallocate the work order to team with id 2 to start at "2014-01-06 08:00"
	Then the work order reallocation should be "successful"
	And the following resultant schedule for team with id 1
	| WorkOrderID | StartTime          | EndTime            |
	| 1           | "2014-01-07 08:00" | "2014-01-08 12:00" |
	| 2           | "2014-01-08 14:00" | "2014-01-09 13:00" |
	And the following resultant schedule for team with id 2
	| WorkOrderID | StartTime          | EndTime            |
	| 0           | "2014-01-06 08:00" | "2014-01-06 14:00" |	

Scenario: Reallocate work order to team with no conflicting work orders scheduled
	Given I have a work order with id 0	
	And I have a repair team with id 1 and the following schedule	
	| WorkOrderID | StartTime          | EndTime            |
	| 0           | "2014-01-06 08:00" | "2014-01-06 14:00" |
	| 1           | "2014-01-07 08:00" | "2014-01-08 12:00" |
	| 2           | "2014-01-08 14:00" | "2014-01-09 13:00" |
	And I have a repair team with id 2 and the following schedule		
	| WorkOrderID | StartTime          | EndTime            |	
	| 3           | "2014-01-07 08:00" | "2014-01-08 12:00" |
	| 4           | "2014-01-08 14:00" | "2014-01-09 13:00" |
	When I reallocate the work order to team with id 2 to start at "2014-01-06 08:00"
	Then the work order reallocation should be "successful"
	And the following resultant schedule for team with id 1
	| WorkOrderID | StartTime          | EndTime            |
	| 1           | "2014-01-07 08:00" | "2014-01-08 12:00" |
	| 2           | "2014-01-08 14:00" | "2014-01-09 13:00" |
	And the following resultant schedule for team with id 2
	| WorkOrderID | StartTime          | EndTime            |
	| 0           | "2014-01-06 08:00" | "2014-01-06 14:00" |
	| 3           | "2014-01-07 08:00" | "2014-01-08 12:00" |
	| 4           | "2014-01-08 14:00" | "2014-01-09 13:00" |

Scenario: Reallocate work order to team with conflicting work orders scheduled
	Given I have a work order with id 0	
	And I have a repair team with id 1 and the following schedule	
	| WorkOrderID | StartTime          | EndTime            |
	| 0           | "2014-01-06 08:00" | "2014-01-06 14:00" |
	| 1           | "2014-01-07 08:00" | "2014-01-08 12:00" |
	| 2           | "2014-01-08 14:00" | "2014-01-09 13:00" |
	And I have a repair team with id 2 and the following schedule		
	| WorkOrderID | StartTime          | EndTime            |	
	| 3           | "2014-01-06 09:00" | "2014-01-06 15:00" |
	| 4           | "2014-01-07 08:00" | "2014-01-08 12:00" |
	| 5           | "2014-01-08 14:00" | "2014-01-09 13:00" |
	When I reallocate the work order to team with id 2 to start at "2014-01-06 08:00"
	Then the work order reallocation should be "unsucessful"
	And the following resultant schedule for team with id 1
	| WorkOrderID | StartTime          | EndTime            |
	| 0           | "2014-01-06 08:00" | "2014-01-06 14:00" |
	| 1           | "2014-01-07 08:00" | "2014-01-08 12:00" |
	| 2           | "2014-01-08 14:00" | "2014-01-09 13:00" |
	And the following resultant schedule for team with id 2
	| WorkOrderID | StartTime          | EndTime            |
	| 3           | "2014-01-06 09:00" | "2014-01-06 15:00" |
	| 4           | "2014-01-07 08:00" | "2014-01-08 12:00" |
	| 5           | "2014-01-08 14:00" | "2014-01-09 13:00" |
