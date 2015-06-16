Feature: SearchFaults
	In order to ensure existing faults aren't duplicated
	As a call center operator
	I want to enter a street address, suburb or postal code and receive a list of all open and recently closed faults surrounding that address.

@mytag
Scenario: Find open faults by street name
	Given I am on the Fault Search page
	And   I enter '8th Street' as the street name
	And   These faults exist	
	| Id | Latitude   | Longitude | Street      | CrossStreet | Suburb   | PostCode | StatusId | TypeId | EstimatedCompletionDate | DateCompleted |
	| 1  | null       | null      | Sandton Dr  | Grayston Dr | Sandton  | 2196     | 1        | 1      | null                    | null          |
	| 27 | null       | null      | 10th St     | null        | Sandton  | 2195     | 1        | 2      | null                    | null          |
	| 47 | -26.160226 | 27.975857 | 8th Street  | null        | Randburg | 2195     | 1        | 3      | null                    | null          |
	| 52 | null       | null      | Hill Street | null        | Randburg | 2195     | 5        | 1      | 11-01-2015              | 13-01-2015    |
	When  I press the Search button
	Then  The results should be
	| Id | Latitude   | Longitude | Street      | CrossStreet | Suburb   | PostCode | StatusId | TypeId | EstimatedCompletionDate | DateCompleted |
	| 47 | -26.160226 | 27.975857 | 8th Street  | null        | Randburg | 2195     | 1        | 3      | null                    | null          |

Scenario: Find open faults by passing the cross street name as the street name
	Given I am on the Fault Search page
	And   I enter 'Grayston Dr' as the street name
	And   These faults exist	
	| Id | Latitude   | Longitude | Street      | CrossStreet | Suburb   | PostCode | StatusId | TypeId | EstimatedCompletionDate | DateCompleted |
	| 1  | null       | null      | Sandton Dr  | Grayston Dr | Sandton  | 2196     | 1        | 1      | null                    | null          |
	| 27 | null       | null      | 10th St     | null        | Sandton  | 2195     | 1        | 1      | null                    | null          |
	| 47 | -26.160226 | 27.975857 | 8th Street  | null        | Randburg | 2195     | 1        | 3      | null                    | null          |
	| 52 | null       | null      | Hill Street | null        | Randburg | 2195     | 5        | 1      | 11-01-2015              | 13-01-2015    |
	When  I press the Search button
	Then  The results should be
	| Id | Latitude   | Longitude | Street      | CrossStreet | Suburb   | PostCode | StatusId | TypeId | EstimatedCompletionDate | DateCompleted |
	| 1  | null       | null      | Sandton Dr  | Grayston Dr | Sandton  | 2196     | 1        | 1      | null                    | null          |

Scenario: Find open faults by cross street name
	Given I am on the Fault Search page
	And   I enter 'Grayston Dr' as the cross street name
	And   These faults exist	
	| Id | Latitude   | Longitude | Street      | CrossStreet | Suburb   | PostCode | StatusId | TypeId | EstimatedCompletionDate | DateCompleted |
	| 1  | null       | null      | Sandton Dr  | Grayston Dr | Sandton  | 2196     | 1        | 1      | null                    | null          |
	| 27 | null       | null      | 10th St     | null        | Sandton  | 2195     | 1        | 1      | null                    | null          |
	| 47 | -26.160226 | 27.975857 | 8th Street  | null        | Randburg | 2195     | 1        | 3      | null                    | null          |
	| 52 | null       | null      | Hill Street | null        | Randburg | 2195     | 5        | 1      | 11-01-2015              | 13-01-2015    |
	When  I press the Search button
	Then  The results should be
	| Id | Latitude   | Longitude | Street      | CrossStreet | Suburb   | PostCode | StatusId | TypeId | EstimatedCompletionDate | DateCompleted |
	| 1  | null       | null      | Sandton Dr  | Grayston Dr | Sandton  | 2196     | 1        | 1      | null                    | null          |

Scenario: Find open faults by passing the street name as the cross street name
	Given I am on the Fault Search page
	And   I enter 'Sandton Dr' as the cross street name
	And   These faults exist	
	| Id | Latitude   | Longitude | Street      | CrossStreet | Suburb   | PostCode | StatusId | TypeId | EstimatedCompletionDate | DateCompleted |
	| 1  | null       | null      | Sandton Dr  | Grayston Dr | Sandton  | 2196     | 1        | 1      | null                    | null          |
	| 27 | null       | null      | 10th St     | null        | Sandton  | 2195     | 1        | 1      | null                    | null          |
	| 47 | -26.160226 | 27.975857 | 8th Street  | null        | Randburg | 2195     | 1        | 3      | null                    | null          |
	| 52 | null       | null      | Hill Street | null        | Randburg | 2195     | 5        | 1      | 11-01-2015              | 13-01-2015    |
	When  I press the Search button
	Then  The results should be
	| Id | Latitude   | Longitude | Street      | CrossStreet | Suburb   | PostCode | StatusId | TypeId | EstimatedCompletionDate | DateCompleted |
	| 1  | null       | null      | Sandton Dr  | Grayston Dr | Sandton  | 2196     | 1        | 1      | null                    | null          |

Scenario: Find open faults by suburb name
	Given I am on the Fault Search page
	And   I enter 'Sandton' as the suburb name
	And   These faults exist	
	| Id | Latitude   | Longitude | Street      | CrossStreet | Suburb   | PostCode | StatusId | TypeId | EstimatedCompletionDate | DateCompleted |
	| 1  | null       | null      | Sandton Dr  | Grayston Dr | Sandton  | 2196     | 1        | 1      | null                    | null          |
	| 27 | null       | null      | 10th St     | null        | Sandton  | 2195     | 1        | 1      | null                    | null          |
	| 47 | -26.160226 | 27.975857 | 8th Street  | null        | Randburg | 2195     | 1        | 3      | null                    | null          |
	| 52 | null       | null      | Hill Street | null        | Randburg | 2195     | 5        | 1      | 11-01-2015              | 13-01-2015    |
	When  I press the Search button
	Then  The results should be
	| Id | Latitude   | Longitude | Street      | CrossStreet | Suburb   | PostCode | StatusId | TypeId | EstimatedCompletionDate | DateCompleted |
	| 1  | null       | null      | Sandton Dr  | Grayston Dr | Sandton  | 2196     | 1        | 1      | null                    | null          |
	| 27 | null       | null      | 10th St     | null        | Sandton  | 2195     | 1        | 1      | null                    | null          |

Scenario: Find open faults by type
	Given I am on the Fault Search page
	And   I enter '3' as the fault type
	And   These faults exist	
	| Id | Latitude   | Longitude | Street      | CrossStreet | Suburb   | PostCode | StatusId | TypeId | EstimatedCompletionDate | DateCompleted |
	| 1  | null       | null      | Sandton Dr  | Grayston Dr | Sandton  | 2196     | 1        | 1      | null                    | null          |
	| 27 | null       | null      | 10th St     | null        | Sandton  | 2195     | 1        | 1      | null                    | null          |
	| 47 | -26.160226 | 27.975857 | 8th Street  | null        | Randburg | 2195     | 1        | 3      | null                    | null          |
	| 52 | null       | null      | Hill Street | null        | Randburg | 2195     | 5        | 1      | 11-01-2015              | 13-01-2015    |
	When  I press the Search button
	Then  The results should be
	| Id | Latitude   | Longitude | Street      | CrossStreet | Suburb   | PostCode | StatusId | TypeId | EstimatedCompletionDate | DateCompleted |
	| 47 | -26.160226 | 27.975857 | 8th Street  | null        | Randburg | 2195     | 1        | 3      | null                    | null          |

Scenario: Find open faults by street name, suburb, type combination
	Given I am on the Fault Search page
	And   I enter '8th Street' as the street name
	And   I enter 'Sandton' as the suburb name
	And   I enter '3' as the fault type
	And   These faults exist	
	| Id | Latitude | Longitude | Street     | CrossStreet | Suburb   | PostCode | StatusId | TypeId | EstimatedCompletionDate | DateCompleted |
	| 1  | null     | null      | 8th Street | null        | Sandton  | 2196     | 1        | 1      | null                    | null          |
	| 27 | null     | null      | 8th Street | null        | Sandton  | 2196     | 1        | 2      | null                    | null          |
	| 47 | null     | null      | 8th Street | null        | Sandton  | 2196     | 1        | 3      | null                    | null          |
	| 52 | null     | null      | 8th Street | null        | Randburg | 2195     | 1        | 3      | null                    | null          |
	| 78 | null     | null      | 9th Street | null        | Sandton  | 2196     | 1        | 3      | null                    | null          |
	When  I press the Search button
	Then  The results should be
	| Id | Latitude | Longitude | Street     | CrossStreet | Suburb  | PostCode | StatusId | TypeId | EstimatedCompletionDate | DateCompleted |
	| 47 | null     | null      | 8th Street | null        | Sandton | 2196     | 1        | 3      | null                    | null          |