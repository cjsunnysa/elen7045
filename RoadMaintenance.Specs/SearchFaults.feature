Feature: SearchFaults
	In order to ensure existing faults aren't duplicated
	As a call center operator
	I want to enter a street address, suburb or postal code and receive a list of all open and recently closed faults surrounding that address.

@mytag
Scenario: Find open and recently closed faults by street name
	Given I am on the Fault Search page
	And   I enter '8th Street' as the street name
	And   These faults exist	
	| Id | Latitude   | Longitude | Street     | Suburb   | PostCode | StatusId | Status              | TypeId | Type          | EstimatedCompletionDate | DateCompleted |
	| 1  | null       | null      | 8th St     | Sandton  | 2196     | 1        | Awaiting Inspection | 1      | Pothole       | null                    | null          |
	| 27 | null       | null      | 10th St    | Sandton  | 2195     | 1        | Awaiting Inspection | 1      | Pothole       | null                    | null          |
	| 47 | -26.160226 | 27.975857 | 8th Street | Randburg | 2195     | 5        | Repaired            | 3      | Traffic Light | 15-05-2015              | 16-05-2015    |
	| 50 | -26.160226 | 27.975857 | 8th Str    | Randburg | 2195     | 5        | Repaired            | 4      | Road Marking  | 01-05-2015              | 01-05-2015    |
	When  I press the Search button
	Then  The results should be
	| Id | Latitude   | Longitude | Street     | Suburb   | PostCode | StatusId | Status              | TypeId | Type          | EstimatedCompletionDate | DateCompleted |
	| 1  | null       | null      | 8th St     | Sandton  | 2196     | 1        | Awaiting Inspection | 1      | Pothole       | null                    | null          |
	| 47 | -26.160226 | 27.975857 | 8th Street | Randburg | 2195     | 5        | Repaired            | 3      | Traffic Light | 15-05-2015              | 16-05-2015    |
