Feature: SearchFaults
	In order to ensure existing faults aren't duplicated
	As a call center operator
	I want to enter a street address, cross-street address, suburb or fault type and receive a list of all open and recently closed faults containing that information.

@GreenPath
Scenario: Find open and recently closed faults by street name
	Given I am a 'CallCenterOperator' user role
	And   I enter 'Hill Street' as the street name
	And   The date today is '2015-04-01'
	And   The recently closed fault logging search period is '30' days
	And   These faults exist	
	| Id | Street        | CrossStreet      | Suburb   | PostCode | StatusId | TypeId | DateCompleted |
	| 1  | Hill Street   | Malabongwe Drive | Randburg | 2194     | 1        | 2      |               |
	| 2  | Hill Street   |                  | Randburg | 2194     | 1        | 2      |               |
	| 3  | Hill Street   | Malabongwe Drive | Randburg | 2194     | 4        | 2      | 2015-03-01    |
	| 4  | Hill Street   | Malabongwe Drive | Randburg | 2194     | 4        | 2      | 2015-03-02    |
	| 5  | Hill Street   |                  | Randburg | 2194     | 4        | 2      | 2015-03-02    |
	| 6  | Fern Street   | Hill Street      | Randburg | 2194     | 1        | 2      |               |
	| 8  | Fern Street   | Hill Street      | Randburg | 2194     | 4        | 2      | 2015-03-02    |
	| 9  | Fern Street   | Hill Street      | Randburg | 2194     | 4        | 2      | 2015-03-01    |
	| 11 | Republic Road | Malabongwe Drive | Randburg | 2194     | 1        | 2      |               |
	| 13 | Republic Road |                  | Randburg | 2194     | 4        | 2      | 2015-03-01    |
	When  I press the Search button
	Then  The results should be
	| Id | Street        | CrossStreet      | Suburb   | PostCode | StatusId | TypeId | DateCompleted |
	| 1  | Hill Street   | Malabongwe Drive | Randburg | 2194     | 1        | 2      |               |
	| 2  | Hill Street   |                  | Randburg | 2194     | 1        | 2      |               |
	| 4  | Hill Street   | Malabongwe Drive | Randburg | 2194     | 4        | 2      | 2015-03-02    |
	| 5  | Hill Street   |                  | Randburg | 2194     | 4        | 2      | 2015-03-02    |
	| 6  | Fern Street   | Hill Street      | Randburg | 2194     | 1        | 2      |               |
	| 8  | Fern Street   | Hill Street      | Randburg | 2194     | 4        | 2      | 2015-03-02    |

Scenario: Find open and recently closed faults by cross street name
	Given I am a 'CallCenterOperator' user role
	And   I enter 'Hill Street' as the cross street name
	And   The date today is '2015-04-01'
	And   The recently closed fault logging search period is '30' days
	And   These faults exist	
	| Id | Street        | CrossStreet      | Suburb   | PostCode | StatusId | TypeId | DateCompleted |
	| 1  | Hill Street   | Malabongwe Drive | Randburg | 2194     | 1        | 2      |               |
	| 2  | Hill Street   |                  | Randburg | 2194     | 1        | 2      |               |
	| 3  | Hill Street   | Malabongwe Drive | Randburg | 2194     | 4        | 2      | 2015-03-01    |
	| 4  | Hill Street   | Malabongwe Drive | Randburg | 2194     | 4        | 2      | 2015-03-02    |
	| 5  | Hill Street   |                  | Randburg | 2194     | 4        | 2      | 2015-03-02    |
	| 6  | Fern Street   | Hill Street      | Randburg | 2194     | 1        | 2      |               |
	| 8  | Fern Street   | Hill Street      | Randburg | 2194     | 4        | 2      | 2015-03-02    |
	| 9  | Fern Street   | Hill Street      | Randburg | 2194     | 4        | 2      | 2015-03-01    |
	| 11 | Republic Road | Malabongwe Drive | Randburg | 2194     | 1        | 2      |               |
	| 13 | Republic Road |                  | Randburg | 2194     | 4        | 2      | 2015-03-01    |
	When  I press the Search button
	Then  The results should be
	| Id | Street        | CrossStreet      | Suburb   | PostCode | StatusId | TypeId | DateCompleted |
	| 1  | Hill Street   | Malabongwe Drive | Randburg | 2194     | 1        | 2      |               |
	| 2  | Hill Street   |                  | Randburg | 2194     | 1        | 2      |               |
	| 4  | Hill Street   | Malabongwe Drive | Randburg | 2194     | 4        | 2      | 2015-03-02    |
	| 5  | Hill Street   |                  | Randburg | 2194     | 4        | 2      | 2015-03-02    |
	| 6  | Fern Street   | Hill Street      | Randburg | 2194     | 1        | 2      |               |
	| 8  | Fern Street   | Hill Street      | Randburg | 2194     | 4        | 2      | 2015-03-02    |

Scenario: Find open and recently closed faults by suburb name
	Given I am a 'CallCenterOperator' user role
	And   I enter 'Sandton' as the suburb name
	And   The date today is '2015-04-01'
	And   The recently closed fault logging search period is '30' days
	And   These faults exist	
	| Id | Street      | CrossStreet      | Suburb   | PostCode | StatusId | TypeId | DateCompleted |
	| 1  | Hill Street | Malabongwe Drive | Sandton  | 2196     | 1        | 2      |               |
	| 1  | Hill Street | Malabongwe Drive | Sandton  | 2196     | 1        | 2      | 2015-03-01    |
	| 1  | Hill Street | Malabongwe Drive | Sandton  | 2196     | 1        | 2      | 2015-03-02    |
	| 1  | Hill Street | Malabongwe Drive | Sandton  | 2196     | 4        | 2      | 2015-03-01    |
	| 1  | Hill Street | Malabongwe Drive | Sandton  | 2196     | 4        | 2      | 2015-03-02    |
	| 1  | Hill Street | Malabongwe Drive | Randburg | 2194     | 1        | 2      |               |
	| 1  | Hill Street | Malabongwe Drive | Randburg | 2194     | 1        | 2      |               |
	When  I press the Search button
	Then  The results should be
	| Id | Street      | CrossStreet      | Suburb   | PostCode | StatusId | TypeId | DateCompleted |
	| 1  | Hill Street | Malabongwe Drive | Sandton  | 2196     | 1        | 2      |               |
	| 1  | Hill Street | Malabongwe Drive | Sandton  | 2196     | 1        | 2      | 2015-03-01    |
	| 1  | Hill Street | Malabongwe Drive | Sandton  | 2196     | 1        | 2      | 2015-03-02    |
	| 1  | Hill Street | Malabongwe Drive | Sandton  | 2196     | 4        | 2      | 2015-03-02    |

Scenario: Find open and recently closed faults by fault type
	Given I am a 'CallCenterOperator' user role
	And   The date today is '2015-04-01'
	And   The recently closed fault logging search period is '30' days
	And   These faults exist
	| Id | Street      | CrossStreet      | Suburb   | PostCode | StatusId | TypeId | DateCompleted |
	| 1  | Hill Street | Malabongwe Drive | Sandton  | 2196     | 1        | 1      |               |
	| 2  | Hill Street | Malabongwe Drive | Sandton  | 2196     | 1        | 1      | 2015-03-01    |
	| 3  | Hill Street | Malabongwe Drive | Sandton  | 2196     | 1        | 1      | 2015-03-02    |
	| 4  | Hill Street | Malabongwe Drive | Sandton  | 2196     | 4        | 1      | 2015-03-01    |
	| 5  | Hill Street | Malabongwe Drive | Sandton  | 2196     | 4        | 1      | 2015-03-02    |
	| 6  | Hill Street | Malabongwe Drive | Randburg | 2194     | 1        | 2      |               |
	| 7  | Hill Street | Malabongwe Drive | Randburg | 2194     | 1        | 2      |               |
	And   I select 'Pothole' as the fault type
	When  I press the Search button
	Then  The results should be
	| Id | Street      | CrossStreet      | Suburb   | PostCode | StatusId | TypeId | DateCompleted |
	| 1  | Hill Street | Malabongwe Drive | Sandton  | 2196     | 1        | 1      |               |
	| 2  | Hill Street | Malabongwe Drive | Sandton  | 2196     | 1        | 1      | 2015-03-01    |
	| 3  | Hill Street | Malabongwe Drive | Sandton  | 2196     | 1        | 1      | 2015-03-02    |
	| 5  | Hill Street | Malabongwe Drive | Sandton  | 2196     | 4        | 1      | 2015-03-02    |

Scenario: Find open and recently closed faults by street and cross street
	Given I am a 'CallCenterOperator' user role
	And   I enter 'Hill Street' as the street name
	And   I enter 'Fern Ave' as the cross street name
	And   The date today is '2015-04-01'
	And   The recently closed fault logging search period is '30' days
	And   These faults exist
	| Id | Street      | CrossStreet | Suburb   | PostCode | StatusId | TypeId | DateCompleted |
	| 1  | Hill Street | Fern Ave    | Randburg | 2194     | 1        | 1      |               |
	| 2  | Fern Ave    | Hill Street | Randburg | 2194     | 1        | 1      |               |
	| 3  | Hill Street |             | Randburg | 2194     | 1        | 1      |               |
	| 5  | Fern Ave    |             | Randburg | 2194     | 1        | 1      |               |
	| 7  | Hill Street | Fern Ave    | Randburg | 2194     | 4        | 1      | 2015-03-01    |
	| 8  | Hill Street | Fern Ave    | Randburg | 2194     | 4        | 1      | 2015-03-02    |
	| 9  | Fern Ave    | Hill Street | Randburg | 2194     | 4        | 1      | 2015-03-01    |
	| 10 | Fern Ave    | Hill Street | Randburg | 2194     | 4        | 1      | 2015-03-02    |
	When  I press the Search button
	Then  The results should be
	| Id | Street      | CrossStreet | Suburb   | PostCode | StatusId | TypeId | DateCompleted |
	| 1  | Hill Street | Fern Ave    | Randburg | 2194     | 1        | 1      |               |
	| 2  | Fern Ave    | Hill Street | Randburg | 2194     | 1        | 1      |               |
	| 8  | Hill Street | Fern Ave    | Randburg | 2194     | 4        | 1      | 2015-03-02    |
	| 10 | Fern Ave    | Hill Street | Randburg | 2194     | 4        | 1      | 2015-03-02    |

Scenario: Find open and recently closed faults by street and cross street and fault type
	Given I am a 'CallCenterOperator' user role
	And   I enter 'Hill Street' as the street name
	And   I enter 'Fern Ave' as the cross street name
	And   The date today is '2015-04-01'
	And   The recently closed fault logging search period is '30' days
	And   These faults exist
	| Id | Street      | CrossStreet | Suburb   | PostCode | StatusId | TypeId | DateCompleted |
	| 1  | Hill Street | Fern Ave    | Randburg | 2194     | 1        | 1      |               |
	| 2  | Fern Ave    | Hill Street | Randburg | 2194     | 1        | 1      |               |
	| 3  | Hill Street |             | Randburg | 2194     | 1        | 1      |               |
	| 5  | Fern Ave    |             | Randburg | 2194     | 1        | 1      |               |
	| 7  | Hill Street | Fern Ave    | Randburg | 2194     | 4        | 1      | 2015-03-01    |
	| 8  | Hill Street | Fern Ave    | Randburg | 2194     | 4        | 1      | 2015-03-02    |
	| 9  | Fern Ave    | Hill Street | Randburg | 2194     | 4        | 1      | 2015-03-01    |
	| 10 | Fern Ave    | Hill Street | Randburg | 2194     | 4        | 1      | 2015-03-02    |
	| 11 | Hill Street | Fern Ave    | Randburg | 2194     | 4        | 2      | 2015-03-01    |
	| 12 | Hill Street | Fern Ave    | Randburg | 2194     | 4        | 3      | 2015-03-02    |
	| 13 | Fern Ave    | Hill Street | Randburg | 2194     | 4        | 2      | 2015-03-01    |
	| 14 | Fern Ave    | Hill Street | Randburg | 2194     | 4        | 2      | 2015-03-02    |
	| 15 | Fern Ave    | Hill Street | Randburg | 2194     | 1        | 2      |               |
	And   I select 'Pothole' as the fault type
	When  I press the Search button
	Then  The results should be
	| Id | Street      | CrossStreet | Suburb   | PostCode | StatusId | TypeId | DateCompleted |
	| 1  | Hill Street | Fern Ave    | Randburg | 2194     | 1        | 1      |               |
	| 2  | Fern Ave    | Hill Street | Randburg | 2194     | 1        | 1      |               |
	| 8  | Hill Street | Fern Ave    | Randburg | 2194     | 4        | 1      | 2015-03-02    |
	| 10 | Fern Ave    | Hill Street | Randburg | 2194     | 4        | 1      | 2015-03-02    |

Scenario: Find open and recently closed faults by street and cross street and fault type and suburb name
	Given I am a 'CallCenterOperator' user role
	And   I enter 'Hill Street' as the street name
	And   I enter 'Fern Ave' as the cross street name
	And   I enter 'Sandton' as the suburb name
	And   The date today is '2015-04-01'
	And   The recently closed fault logging search period is '30' days
	And   These faults exist
	| Id | Street      | CrossStreet | Suburb   | PostCode | StatusId | TypeId | DateCompleted |
	| 1  | Hill Street | Fern Ave    | Randburg | 2194     | 1        | 1      |               |
	| 2  | Fern Ave    | Hill Street | Sandton  | 2196     | 1        | 1      |               |
	| 3  | Hill Street |             | Randburg | 2194     | 1        | 1      |               |
	| 5  | Fern Ave    |             | Randburg | 2194     | 1        | 1      |               |
	| 7  | Hill Street | Fern Ave    | Randburg | 2194     | 4        | 1      | 2015-03-01    |
	| 8  | Hill Street | Fern Ave    | Randburg | 2194     | 4        | 1      | 2015-03-02    |
	| 9  | Fern Ave    | Hill Street | Randburg | 2194     | 4        | 1      | 2015-03-01    |
	| 10 | Fern Ave    | Hill Street | Randburg | 2194     | 4        | 1      | 2015-03-02    |
	| 11 | Hill Street | Fern Ave    | Randburg | 2194     | 4        | 2      | 2015-03-01    |
	| 12 | Hill Street | Fern Ave    | Randburg | 2194     | 4        | 3      | 2015-03-02    |
	| 13 | Fern Ave    | Hill Street | Randburg | 2194     | 4        | 2      | 2015-03-01    |
	| 14 | Fern Ave    | Hill Street | Randburg | 2194     | 4        | 2      | 2015-03-02    |
	| 15 | Fern Ave    | Hill Street | Randburg | 2194     | 1        | 2      |               |
	And   I select 'Pothole' as the fault type
	When  I press the Search button
	Then  The results should be
	| Id | Street   | CrossStreet | Suburb  | PostCode | StatusId | TypeId | DateCompleted |
	| 2  | Fern Ave | Hill Street | Sandton | 2196     | 1        | 1      |               |	