Feature: SearchFaults
	In order to ensure existing faults aren't duplicated
	As a call center operator
	I want to enter a street address, suburb or postal code and receive a list of all open and recently closed faults surrounding that address.

@mytag
Scenario: Find open faults by street name
	Given I am on the Fault Search page
	And   I enter '8th Street' as the street name
	And   These faults exist	
	| Id | Street      | CrossStreet | Suburb   | PostCode | StatusId | TypeId |
	| 1  | Sandton Dr  | Grayston Dr | Sandton  | 2196     | 1        | 1      |
	| 27 | 10th St     | null        | Sandton  | 2195     | 1        | 2      |
	| 47 | 8th Street  | null        | Randburg | 2195     | 1        | 3      |
	| 52 | Hill Street | null        | Randburg | 2195     | 5        | 1      |
	When  I press the Search button
	Then  The results should be
	| Id | Street      | CrossStreet | Suburb   | PostCode | StatusId | TypeId |
	| 47 | 8th Street  | null        | Randburg | 2195     | 1        | 3      |

Scenario: Find open faults by passing the cross street name as the street name
	Given I am on the Fault Search page
	And   I enter 'Grayston Dr' as the street name
	And   These faults exist	
	| Id | Street      | CrossStreet | Suburb   | PostCode | StatusId | TypeId |
	| 1  | Sandton Dr  | Grayston Dr | Sandton  | 2196     | 1        | 1      |
	| 27 | 10th St     | null        | Sandton  | 2195     | 1        | 2      |
	| 47 | 8th Street  | null        | Randburg | 2195     | 1        | 3      |
	| 52 | Hill Street | null        | Randburg | 2195     | 5        | 1      |
	When  I press the Search button
	Then  The results should be
	| Id | Street      | CrossStreet | Suburb   | PostCode | StatusId | TypeId |
	| 1  | Sandton Dr  | Grayston Dr | Sandton  | 2196     | 1        | 1      |

Scenario: Find open faults by cross street name
	Given I am on the Fault Search page
	And   I enter 'Grayston Dr' as the cross street name
	And   These faults exist	
	| Id | Street      | CrossStreet | Suburb   | PostCode | StatusId | TypeId |
	| 1  | Sandton Dr  | Grayston Dr | Sandton  | 2196     | 1        | 1      |
	| 27 | 10th St     | null        | Sandton  | 2195     | 1        | 2      |
	| 47 | 8th Street  | null        | Randburg | 2195     | 1        | 3      |
	| 52 | Hill Street | null        | Randburg | 2195     | 5        | 1      |
	When  I press the Search button
	Then  The results should be
	| Id | Street      | CrossStreet | Suburb   | PostCode | StatusId | TypeId |
	| 1  | Sandton Dr  | Grayston Dr | Sandton  | 2196     | 1        | 1      |
	
Scenario: Find open faults by passing the street name as the cross street name
	Given I am on the Fault Search page
	And   I enter 'Sandton Dr' as the cross street name
	And   These faults exist	
	| Id | Street      | CrossStreet | Suburb   | PostCode | StatusId | TypeId |
	| 1  | Sandton Dr  | Grayston Dr | Sandton  | 2196     | 1        | 1      |
	| 27 | 10th St     | null        | Sandton  | 2195     | 1        | 2      |
	| 47 | 8th Street  | null        | Randburg | 2195     | 1        | 3      |
	| 52 | Hill Street | null        | Randburg | 2195     | 5        | 1      |
	When  I press the Search button
	Then  The results should be
	| Id | Street      | CrossStreet | Suburb   | PostCode | StatusId | TypeId |
	| 1  | Sandton Dr  | Grayston Dr | Sandton  | 2196     | 1        | 1      |
	
Scenario: Find open faults by suburb name
	Given I am on the Fault Search page
	And   I enter 'Sandton' as the suburb name
	And   These faults exist	
	| Id | Street      | CrossStreet | Suburb   | PostCode | StatusId | TypeId |
	| 1  | Sandton Dr  | Grayston Dr | Sandton  | 2196     | 1        | 1      |
	| 27 | 10th St     | null        | Sandton  | 2195     | 1        | 2      |
	| 47 | 8th Street  | null        | Randburg | 2195     | 1        | 3      |
	| 52 | Hill Street | null        | Randburg | 2195     | 5        | 1      |
	When  I press the Search button
	Then  The results should be
	| Id | Street      | CrossStreet | Suburb   | PostCode | StatusId | TypeId |
	| 1  | Sandton Dr  | Grayston Dr | Sandton  | 2196     | 1        | 1      |
	| 27 | 10th St     | null        | Sandton  | 2195     | 1        | 2      |
	
Scenario: Find open faults by type
	Given I am on the Fault Search page
	And   I enter '3' as the fault type
	And   These faults exist	
	| Id | Street      | CrossStreet | Suburb   | PostCode | StatusId | TypeId |
	| 1  | Sandton Dr  | Grayston Dr | Sandton  | 2196     | 1        | 1      |
	| 27 | 10th St     | null        | Sandton  | 2195     | 1        | 2      |
	| 47 | 8th Street  | null        | Randburg | 2195     | 1        | 3      |
	| 52 | Hill Street | null        | Randburg | 2195     | 5        | 1      |
	When  I press the Search button
	Then  The results should be
	| Id | Street      | CrossStreet | Suburb   | PostCode | StatusId | TypeId |
	| 47 | 8th Street  | null        | Randburg | 2195     | 1        | 3      |
	
Scenario: Find open faults by street name, suburb, type combination
	Given I am on the Fault Search page
	And   I enter '8th Street' as the street name
	And   I enter 'Sandton' as the suburb name
	And   I enter '3' as the fault type
	And   These faults exist	
	| Id | Street      | CrossStreet | Suburb   | PostCode | StatusId | TypeId |
	| 1  | 8th Street  | Grayston Dr | Sandton  | 2196     | 1        | 3      |
	| 27 | 10th St     | null        | Sandton  | 2195     | 1        | 2      |
	| 47 | 8th Street  | null        | Sandton  | 2195     | 1        | 1      |
	| 52 | 8th Street  | null        | Randburg | 2195     | 5        | 3      |
	| 78 | 9th Street  | null        | Sandton  | 2196     | 1        | 3      |
	When  I press the Search button
	Then  The results should be
	| Id | Street      | CrossStreet | Suburb   | PostCode | StatusId | TypeId |
	| 1  | 8th Street  | Grayston Dr | Sandton  | 2196     | 1        | 3      |

Scenario: Find recently closed faults by street name
	Given I am on the Fault Search page
	And   I enter 'Hill Street' as the street name
	And   The date today is '2015-04-01'
	And   The recently closed fault logging search period is '30' days
	And   These faults exist
	| Id | Street      | CrossStreet      | Suburb   | PostCode | StatusId | TypeId | DateCompleted |
	| 1  | Hill Street | Malabongwe Drive | Randburg | 2194     | 4        | 2      | 2015-03-02    |
	| 2  | Hill Street | Malabongwe Drive | Randburg | 2194     | 4        | 2      | 2015-03-01    |
	When I press the Search button
	Then The results should be
	| Id | Street      | CrossStreet      | Suburb   | PostCode | StatusId | TypeId | DateCompleted |
	| 1  | Hill Street | Malabongwe Drive | Randburg | 2194     | 4        | 2      | 2015-03-02    |