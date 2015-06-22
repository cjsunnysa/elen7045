Feature: WorkOrderList
	In order to be able to schedule and allocate work orders
	As a dispatcher
	I want to be able to get a list of unallocated work orders

Scenario: All work orders are scheduled
	Given these work orders exist
	| Id | Status    |
	| 0  | scheduled |
	| 1  | scheduled |
	| 2  | scheduled |
	| 3  | scheduled |
	| 4  | scheduled |
	When I request a list of unscheduled work orders
	Then I receive no work orders

Scenario: All work orders are unscheduled
	Given these work orders exist
	| Id | Status |
	| 0  | issued |
	| 1  | issued |
	| 2  | issued |
	| 3  | issued |
	| 4  | issued |
	When I request a list of unscheduled work orders
	Then I receive these work orders
	| Id | Status |
	| 0  | issued |
	| 1  | issued |
	| 2  | issued |
	| 3  | issued |
	| 4  | issued |

Scenario: Work orders with mixed statuses
	Given these work orders exist
	| Id | Status   |
	| 0  | issued   |
	| 1  | created  |
	| 2  | issued   |
	| 3  | issued   |
	| 4  | verified |
	| 5  | closed   |
	When I request a list of unscheduled work orders
	Then I receive these work orders
	| Id | Status |
	| 0  | issued |
	| 2  | issued |
	| 3  | issued |