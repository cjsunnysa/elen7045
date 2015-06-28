Feature: GetFaultsInJurisdiction
	In order to investigate and verify faults
	As a fault investigator
	I want to get a list of faults in my jurisdiction ordered by priority in descending order


Scenario: Get faults for fault investigator
	Given I am a 'FaultInvestigator' user role 
	And The following faults exist
	| Id                                   | Street      | CrossStreet | Suburb   | PostCode | Longitude  | Latitude   | StatusId | TypeId |
	| 202947AF-130F-4494-8C50-DB84A93648E1 | Sandton Dr  | Grayston Dr | Sandton  | 2196     | 33/34/35/W | 33/34/35/N | 1        | 1      |
	| 46BF992F-B00C-4D76-BDD0-CCB6B993E8EF | 10th St     |             | Sandton  | 2196     | 33/34/35/W | 33/34/35/N | 4        | 2      |
	| 282A10B0-103E-40F9-8D01-320D002EFF9F | 8th Street  |             | Randburg | 2195     | 33/34/35/W | 33/34/35/N | 1        | 1      |
	| E5354BB8-A1BB-49AF-81C1-19BF5FEC4D12 | Hill Street | Malibongwe  | Randburg | 2195     | 33/34/35/W | 33/34/35/N | 3        | 3      |
	And my Investigator jurisdiction centrepoint longitude is "54 89 12 N"
	And my Investigator jurisdiction centrepoint latitude is "54 89 12 E"
	And my Investigator jurisdiction radius is 10 Km
	When I press the "Get faults" button
	Then the following items should be retuned
	| Id                                   | Street     | CrossStreet | Suburb   | PostCode | Longitude  | Latitude   | StatusId | TypeId | Priority | Distance |
	| 202947AF-130F-4494-8C50-DB84A93648E1 | Sandton Dr | Grayston Dr | Sandton  | 2196     | 33/34/35/W | 33/34/35/N | 1        | 1      | 1        | 2        |
	| 282A10B0-103E-40F9-8D01-320D002EFF9F | 8th Street | Germiston   | Randburg | 2195     | 33/34/35/W | 33/34/35/N | 1        | 3      | 1        | 2        | 
	