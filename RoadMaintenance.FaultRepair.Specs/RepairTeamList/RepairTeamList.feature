Feature: RepairTeamList
	In order to be able to schedule and allocate work orders
	As a dispatcher
	I want to be able to get a list of available repair teams and their schedules


Scenario: Teams with work orders scheduled
	Given I am a "Dispatcher" 
	And I have a repair team with id 1 and the following schedule
	| WorkOrderID | StartTime        | EndTime          |
	| 0           | 2014-01-06 08:00 | 2014-01-06 14:00 |
	| 1           | 2014-01-07 08:00 | 2014-01-08 12:00 |
	| 2           | 2014-01-08 14:00 | 2014-01-09 13:00 |
	And I have a repair team with id 2 and the following schedule
	| WorkOrderID | StartTime        | EndTime          |
	| 3           | 2014-01-06 12:00 | 2014-01-06 16:00 |
	| 4           | 2014-01-07 08:00 | 2014-01-09 12:00 |
	| 5           | 2014-01-09 14:00 | 2014-01-10 13:00 |
	| 6           | 2014-01-10 14:00 | 2014-01-10 16:00 |
	| 7           | 2014-01-13 08:00 | 2014-01-13 13:00 |
	And I have a repair team with id 3 and the following schedule
	| WorkOrderID | StartTime        | EndTime          |
	| 8           | 2014-01-06 10:00 | 2014-01-06 12:00 |
	| 9           | 2014-01-06 13:00 | 2014-01-07 10:00 |
	| 10          | 2014-01-07 12:00 | 2014-01-07 16:00 |
	| 11          | 2014-01-08 08:00 | 2014-01-08 16:00 |
	| 12          | 2014-01-09 08:00 | 2014-01-13 16:00 |
	When I request a list of repair teams
	Then I get a list of repair teams with schedules as below
	| RepairTeamID | WorkOrderID | StartTime        | EndTime          |
	| 1            | 0           | 2014-01-06 08:00 | 2014-01-06 14:00 |
	| 1            | 1           | 2014-01-07 08:00 | 2014-01-08 12:00 |
	| 1            | 2           | 2014-01-08 14:00 | 2014-01-09 13:00 |	
	| 2            | 3           | 2014-01-06 12:00 | 2014-01-06 16:00 |
	| 2            | 4           | 2014-01-07 08:00 | 2014-01-09 12:00 |
	| 2            | 5           | 2014-01-09 14:00 | 2014-01-10 13:00 |
	| 2            | 6           | 2014-01-10 14:00 | 2014-01-10 16:00 |
	| 2            | 7           | 2014-01-13 08:00 | 2014-01-13 13:00 |	
	| 3            | 8           | 2014-01-06 10:00 | 2014-01-06 12:00 |
	| 3            | 9           | 2014-01-06 13:00 | 2014-01-07 10:00 |
	| 3            | 10          | 2014-01-07 12:00 | 2014-01-07 16:00 |
	| 3            | 11          | 2014-01-08 08:00 | 2014-01-08 16:00 |
	| 3            | 12          | 2014-01-09 08:00 | 2014-01-13 16:00 |
