Feature: WorkOrderFaultNotModified
	As a work order creator
	I want to know if a fault is currently being modified by another user
    In order to avoid attaching the work order to that fault

@mytag
Scenario: Fault is being modified
	Given Fault ID 10 is being modified by another user	
	When  I enquire whether Fault ID 10 is being modified 
	Then  The result should be true

Scenario: Fault is not being modified
	Given Fault ID 11 is not being modified by another user	
	When  I enquire whether Fault ID 11 is being modified 
	Then  The result should be false

