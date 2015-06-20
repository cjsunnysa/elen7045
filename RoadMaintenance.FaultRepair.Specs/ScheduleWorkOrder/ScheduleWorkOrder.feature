Feature: ScheduleWorkOrder
	In order to schedule a work order
	As a dispatcher
	I should be able to assign it a repair team by allocating it to a repair teams schedule and be able to reschedule and unschedule that work order

Scenario: Allocate a work order to a repair team with no other work orders scheduled
	Given I have a work order
	| Id | Duration |
	| 0  | 24       |
	And I have a repair team with id 1 and the following schedule	
	| WorkOrderID | StartTime          | EndTime            |
	When I schedule the work order for "2014-01-03 08:00"
	Then the work order scheduling should be "succesful" 
	And the following resultant schedule for team with id 1
	| WorkOrderID | StartTime         | EndTime           |
	| 0           | "2014-01-3 08:00" | "2014-01-5 16:00" |

Scenario: Allocate a work order to a repair team with no conflicting work orders scheduled
	Given I have a work order
	| Id | Duration |
	| 3  | 6        |
	And I have a repair team with id 1 and the following schedule
	| WorkOrderID | StartTime          | EndTime            |
	| 0           | "2014-01-06 08:00" | "2014-01-06 14:00" |
	| 1           | "2014-01-07 08:00" | "2014-01-08 12:00" |
	| 2           | "2014-01-08 14:00" | "2014-01-09 13:00" |
	When I schedule the work order for "2014-01-09 15:00"
	Then the work order scheduling should be "succesful"
	And the following resultant schedule for team with id 1
	| WorkOrderID | StartTime          | EndTime            |
	| 0           | "2014-01-06 08:00" | "2014-01-06 14:00" |
	| 1           | "2014-01-07 08:00" | "2014-01-08 12:00" |
	| 2           | "2014-01-08 14:00" | "2014-01-09 13:00" |
	| 3           | "2014-01-9 15:00"  | "2014-01-10 13:00" |

Scenario: Allocate a work order to a repair team with conflicting work orders scheduled
	Given I have a work order
	| Id | Duration |
	| 3  | 6        |
	And I have a repair team with id 1 and the following schedule
	| WorkOrderID | StartTime          | EndTime            |
	| 0           | "2014-01-06 08:00" | "2014-01-06 14:00" |
	| 1           | "2014-01-07 08:00" | "2014-01-08 12:00" |
	| 2           | "2014-01-08 14:00" | "2014-01-09 13:00" |
	When I schedule the work order for "2014-01-07 15:00"
	Then the work order scheduling should be "unsuccesful"
	And the following resultant schedule for team with id 1
	| WorkOrderID | StartTime          | EndTime            |
	| 0           | "2014-01-06 08:00" | "2014-01-06 14:00" |
	| 1           | "2014-01-07 08:00" | "2014-01-08 12:00" |
	| 2           | "2014-01-08 14:00" | "2014-01-09 13:00" |
	
Scenario: Reschedule a work order allocated to a repair team with no conflicting work orders scheduled
	Given I have a work order
	| Id | Duration |
	| 0  | 6        |
	And I have a repair team with id 1 and the following schedule
	| WorkOrderID | StartTime          | EndTime            |
	| 0           | "2014-01-06 08:00" | "2014-01-06 14:00" |
	| 1           | "2014-01-07 08:00" | "2014-01-08 12:00" |
	| 2           | "2014-01-08 14:00" | "2014-01-09 13:00" |
	When I schedule the work order for "2014-01-09 15:00"
	Then the work order scheduling should be "succesful"
	And the following resultant schedule for team with id 1
	| WorkOrderID | StartTime          | EndTime            |
	| 1           | "2014-01-07 08:00" | "2014-01-08 12:00" |
	| 2           | "2014-01-08 14:00" | "2014-01-09 13:00" |
	| 0           | "2014-01-09 15:00" | "2014-01-10 13:00" |

Scenario: Reschedule a work order allocated to a repair team with conflicting work orders scheduled
	Given I have a work order
	| Id | Duration |
	| 0  | 6        |
	And I have a repair team with id 1 and the following schedule
	| WorkOrderID | StartTime          | EndTime            |
	| 0           | "2014-01-06 08:00" | "2014-01-06 14:00" |
	| 1           | "2014-01-07 08:00" | "2014-01-08 12:00" |
	| 2           | "2014-01-08 14:00" | "2014-01-09 13:00" |
	When I schedule the work order for "2014-01-07 15:00"
	Then the work order scheduling should be "unsuccesful"
	And the following resultant schedule for team with id 1
	| WorkOrderID | StartTime          | EndTime            |
	| 1           | "2014-01-07 08:00" | "2014-01-08 12:00" |
	| 2           | "2014-01-08 14:00" | "2014-01-09 13:00" |
	| 0           | "2014-01-09 15:00" | "2014-01-10 13:00" |

Scenario: Unschedule a work order allocated to a repair team
	Given I have a work order
	| Id | Duration |
	| 0  | 6        |
	And I have a repair team with id 1 and the following schedule
	| WorkOrderID | StartTime          | EndTime            |
	| 0           | "2014-01-06 08:00" | "2014-01-06 14:00" |
	| 1           | "2014-01-07 08:00" | "2014-01-08 12:00" |
	| 2           | "2014-01-08 14:00" | "2014-01-09 13:00" |
	When I unschedule the work order
	Then the work order unscheduling should be "succesful"
	And the following resultant schedule for team with id 1
	| WorkOrderID | StartTime          | EndTime            |
	| 1           | "2014-01-07 08:00" | "2014-01-08 12:00" |
	| 2           | "2014-01-08 14:00" | "2014-01-09 13:00" |

Scenario: Unschedule a work order not allocated to a repair team
	Given I have a work order
	| Id | Duration |
	| 3  | 6        |
	And I have a repair team with id 1 and the following schedule
	| WorkOrderID | StartTime          | EndTime            |
	| 0           | "2014-01-06 08:00" | "2014-01-06 14:00" |
	| 1           | "2014-01-07 08:00" | "2014-01-08 12:00" |
	| 2           | "2014-01-08 14:00" | "2014-01-09 13:00" |
	When I unschedule the work order
	Then the work order unscheduling should be "unsuccesful"
	And the following resultant schedule for team with id 1
	| WorkOrderID | StartTime          | EndTime            |
	| 1           | "2014-01-07 08:00" | "2014-01-08 12:00" |
	| 2           | "2014-01-08 14:00" | "2014-01-09 13:00" |
	| 0           | "2014-01-09 15:00" | "2014-01-10 13:00" |