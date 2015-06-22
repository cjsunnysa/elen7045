Feature: ScheduleWorkOrder
	In order to schedule a work order
	As a dispatcher
	I should be able to assign it a repair team by allocating it to a repair teams schedule and be able to reschedule and unschedule that work order

Scenario: Assign a work order to a repair team with no other work orders scheduled
	Given I have a work order
	| Id | Duration |
	| 0  | 24       |
	And I have a repair team with id 1 and the following schedule	
	| WorkOrderID | StartTime          | EndTime            |
	When I assign the work order to the team with id 1 for "2014-01-03 08:00"
	Then the result should be "successful"
	And the following resultant schedule for team with id 1
	| WorkOrderID | StartTime        | EndTime          |
	| 0           | 2014-01-03 08:00 | 2014-01-07 16:00 |

Scenario: Assign a work order to a repair team with no conflicting work orders scheduled
	Given I have a work order
	| Id | Duration |
	| 3  | 6        |
	And I have a repair team with id 1 and the following schedule
	| WorkOrderID | StartTime        | EndTime          |
	| 0           | 2014-01-06 08:00 | 2014-01-06 14:00 |
	| 1           | 2014-01-07 08:00 | 2014-01-08 12:00 |
	| 2           | 2014-01-08 14:00 | 2014-01-09 13:00 |
	When I assign the work order to the team with id 1 for "2014-01-09 15:00"
	Then the result should be "successful"
	And the following resultant schedule for team with id 1
	| WorkOrderID | StartTime        | EndTime          |
	| 0           | 2014-01-06 08:00 | 2014-01-06 14:00 |
	| 1           | 2014-01-07 08:00 | 2014-01-08 12:00 |
	| 2           | 2014-01-08 14:00 | 2014-01-09 13:00 |
	| 3           | 2014-01-09 15:00 | 2014-01-10 13:00 |

Scenario: Assign a work order to a repair team with conflicting work orders scheduled
	Given I have a work order
	| Id | Duration |
	| 3  | 6        |
	And I have a repair team with id 1 and the following schedule
	| WorkOrderID | StartTime        | EndTime          |
	| 0           | 2014-01-06 08:00 | 2014-01-06 14:00 |
	| 1           | 2014-01-07 08:00 | 2014-01-08 12:00 |
	| 2           | 2014-01-08 14:00 | 2014-01-09 13:00 |
	When I assign the work order to the team with id 1 for "2014-01-07 15:00"
	Then the result should be "unsuccessful"
	And the following resultant schedule for team with id 1
	| WorkOrderID | StartTime        | EndTime          |
	| 0           | 2014-01-06 08:00 | 2014-01-06 14:00 |
	| 1           | 2014-01-07 08:00 | 2014-01-08 12:00 |
	| 2           | 2014-01-08 14:00 | 2014-01-09 13:00 |
	
Scenario: Reschedule a work order allocated to a repair team with no conflicting work orders scheduled
	Given I have a work order
	| Id | Duration |
	| 0  | 6        |
	And I have a repair team with id 1 and the following schedule
	| WorkOrderID | StartTime        | EndTime          |
	| 0           | 2014-01-06 08:00 | 2014-01-06 14:00 |
	| 1           | 2014-01-07 08:00 | 2014-01-08 12:00 |
	| 2           | 2014-01-08 14:00 | 2014-01-09 13:00 |
	When I assign the work order to the team with id 1 for "2014-01-09 15:00"
	Then the result should be "successful"
	And the following resultant schedule for team with id 1
	| WorkOrderID | StartTime        | EndTime          |
	| 1           | 2014-01-07 08:00 | 2014-01-08 12:00 |
	| 2           | 2014-01-08 14:00 | 2014-01-09 13:00 |
	| 0           | 2014-01-09 15:00 | 2014-01-10 13:00 |

Scenario: Reschedule a work order allocated to a repair team with conflicting work orders scheduled
	Given I have a work order
	| Id | Duration |
	| 0  | 6        |
	And I have a repair team with id 1 and the following schedule
	| WorkOrderID | StartTime        | EndTime          |
	| 0           | 2014-01-06 08:00 | 2014-01-06 14:00 |
	| 1           | 2014-01-07 08:00 | 2014-01-08 12:00 |
	| 2           | 2014-01-08 14:00 | 2014-01-09 13:00 |
	When I assign the work order to the team with id 1 for "2014-01-07 15:00"
	Then the result should be "unsuccessful"
	And the following resultant schedule for team with id 1
	| WorkOrderID | StartTime        | EndTime          |
	| 0           | 2014-01-06 08:00 | 2014-01-06 14:00 |
	| 1           | 2014-01-07 08:00 | 2014-01-08 12:00 |
	| 2           | 2014-01-08 14:00 | 2014-01-09 13:00 |

Scenario: Unassign a work order allocated to a repair team
	Given I have a work order
	| Id | Duration |
	| 0  | 6        |
	And I have a repair team with id 1 and the following schedule
	| WorkOrderID | StartTime        | EndTime          |
	| 0           | 2014-01-06 08:00 | 2014-01-06 14:00 |
	| 1           | 2014-01-07 08:00 | 2014-01-08 12:00 |
	| 2           | 2014-01-08 14:00 | 2014-01-09 13:00 |
	When I unassign the work order
	Then the result should be "successful"
	And the following resultant schedule for team with id 1
	| WorkOrderID | StartTime        | EndTime          |
	| 1           | 2014-01-07 08:00 | 2014-01-08 12:00 |
	| 2           | 2014-01-08 14:00 | 2014-01-09 13:00 |

Scenario: Unassign a work order not allocated to a repair team
	Given I have a work order
	| Id | Duration |
	| 3  | 6        |
	And I have a repair team with id 1 and the following schedule
	| WorkOrderID | StartTime        | EndTime          |
	| 0           | 2014-01-06 08:00 | 2014-01-06 14:00 |
	| 1           | 2014-01-07 08:00 | 2014-01-08 12:00 |
	| 2           | 2014-01-08 14:00 | 2014-01-09 13:00 |
	When I unassign the work order
	Then the result should be "unsuccessful"
	And the following resultant schedule for team with id 1
	| WorkOrderID | StartTime        | EndTime          |
	| 0           | 2014-01-06 08:00 | 2014-01-06 14:00 |
	| 1           | 2014-01-07 08:00 | 2014-01-08 12:00 |
	| 2           | 2014-01-08 14:00 | 2014-01-09 13:00 |