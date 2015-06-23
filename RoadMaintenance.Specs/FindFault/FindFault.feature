Feature: FindFault
	In order to report existing fault information to callers
	As a call-center operator
	I want to be able to retrieve fault details by entering a fault identification number.

@GreenPath
Scenario: Retrieve a fault by fault identification number: correct dash format
	Given I am on the Find Fault page
	And   I enter '282A10B0-103E-40F9-8D01-320D002EFF9F' as the fault identification number
	And   These faults exist
	| Id                                   | Street      | CrossStreet | Suburb   | PostCode | StatusId | TypeId | EstimatedCompletionDate |
	| 202947AF-130F-4494-8C50-DB84A93648E1 | Sandton Dr  | Grayston Dr | Sandton  | 2196     | 1        | 1      | 2015-01-01              |
	| 46BF992F-B00C-4D76-BDD0-CCB6B993E8EF | 10th St     |             | Sandton  | 2196     | 4        | 2      | 2015-02-01              |
	| 282A10B0-103E-40F9-8D01-320D002EFF9F | 8th Street  |             | Randburg | 2195     | 1        | 3      | 2015-03-01              |
	| E5354BB8-A1BB-49AF-81C1-19BF5FEC4D12 | Hill Street | Malibongwe  | Randburg | 2195     | 5        | 1      | 2015-04-01              |
	When  I press the Find button
	Then  The results should be
	| Id                                   | Street     | CrossStreet | Suburb   | PostCode | StatusId | TypeId | EstimatedCompletionDate |
	| 282A10B0-103E-40F9-8D01-320D002EFF9F | 8th Street |             | Randburg | 2195     | 1        | 3      | 2015-03-01              |

Scenario: Retrieve a fault by fault identification number: no format
	Given I am on the Find Fault page
	And   I enter '282A10B0103E40F98D01320D002EFF9F' as the fault identification number
	And   These faults exist
	| Id                                   | Street      | CrossStreet | Suburb   | PostCode | StatusId | TypeId | EstimatedCompletionDate |
	| 202947AF-130F-4494-8C50-DB84A93648E1 | Sandton Dr  | Grayston Dr | Sandton  | 2196     | 1        | 1      | 2015-01-01              |
	| 46BF992F-B00C-4D76-BDD0-CCB6B993E8EF | 10th St     |             | Sandton  | 2196     | 4        | 2      | 2015-02-01              |
	| 282A10B0-103E-40F9-8D01-320D002EFF9F | 8th Street  |             | Randburg | 2195     | 1        | 3      | 2015-03-01              |
	| E5354BB8-A1BB-49AF-81C1-19BF5FEC4D12 | Hill Street | Malibongwe  | Randburg | 2195     | 5        | 1      | 2015-04-01              |
	When  I press the Find button
	Then  The results should be
	| Id                                   | Street     | CrossStreet | Suburb   | PostCode | StatusId | TypeId | EstimatedCompletionDate |
	| 282A10B0-103E-40F9-8D01-320D002EFF9F | 8th Street |             | Randburg | 2195     | 1        | 3      | 2015-03-01              |

Scenario: Retrieve a fault by fault identification number: lower case letters
	Given I am on the Find Fault page
	And   I enter '282a10b0-103e-40f9-8d01-320d002eff9f' as the fault identification number
	And   These faults exist
	| Id                                   | Street      | CrossStreet | Suburb   | PostCode | StatusId | TypeId | EstimatedCompletionDate |
	| 202947AF-130F-4494-8C50-DB84A93648E1 | Sandton Dr  | Grayston Dr | Sandton  | 2196     | 1        | 1      | 2015-01-01              |
	| 46BF992F-B00C-4D76-BDD0-CCB6B993E8EF | 10th St     |             | Sandton  | 2196     | 4        | 2      | 2015-02-01              |
	| 282A10B0-103E-40F9-8D01-320D002EFF9F | 8th Street  |             | Randburg | 2195     | 1        | 3      | 2015-03-01              |
	| E5354BB8-A1BB-49AF-81C1-19BF5FEC4D12 | Hill Street | Malibongwe  | Randburg | 2195     | 5        | 1      | 2015-04-01              |
	When  I press the Find button
	Then  The results should be
	| Id                                   | Street     | CrossStreet | Suburb   | PostCode | StatusId | TypeId | EstimatedCompletionDate |
	| 282A10B0-103E-40F9-8D01-320D002EFF9F | 8th Street |             | Randburg | 2195     | 1        | 3      | 2015-03-01              |