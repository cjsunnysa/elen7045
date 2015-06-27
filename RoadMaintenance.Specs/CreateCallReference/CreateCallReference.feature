Feature: Create a Call Reference Number
	In order to total the number of queries received for a fault
	As a Call Center Operator
	I want to be able to generate a call reference number linked to a fault

@mytag
Scenario: Generate a call reference number for a fault
	Given These faults exist
	| Id                                   | Street      | CrossStreet | Suburb   | PostCode | StatusId | TypeId | EstimatedCompletionDate |
	| 202947AF-130F-4494-8C50-DB84A93648E1 | Sandton Dr  | Grayston Dr | Sandton  | 2196     | 1        | 1      | 2015-01-01              |
	| 46BF992F-B00C-4D76-BDD0-CCB6B993E8EF | 10th St     |             | Sandton  | 2196     | 2        | 2      | 2015-02-01              |
	And the fault I am editing has the Id '202947AF-130F-4494-8C50-DB84A93648E1'
	When I press the Create Call Reference button
	Then a new call reference number should be returned
