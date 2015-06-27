Feature: Update the Address of a fault
	In order for a technician to more easily locate a fault's location
	As a call-center operator
	I want to be able to update the Address of a fault

@greenPath
Scenario: Update a fault address change street name
	Given I am a 'CallCenterOperator' user role
	And the fault I am editing has the Id '202947AF-130F-4494-8C50-DB84A93648E1'
	And I enter 'Fern Street' as the street name
	And These faults exist
	| Id                                   | Street      | CrossStreet | Suburb   | PostCode | StatusId | TypeId | DateCompleted |
	| 202947AF-130F-4494-8C50-DB84A93648E1 | Hill Street |             | Randburg | 2194     | 1        | 2      |               |
	| 46BF992F-B00C-4D76-BDD0-CCB6B993E8EF | Hill Street |             | Randburg | 2194     | 4        | 2      | 2015-03-01    |
	When I press the Update Address button
	And I perform a find for this fault id
	Then The results should be
	| Id                                   | Street      | CrossStreet | Suburb   | PostCode | StatusId | TypeId | DateCompleted |
	| 202947AF-130F-4494-8C50-DB84A93648E1 | Fern Street |             | Randburg | 2194     | 1        | 2      |               |

Scenario: Update a fault address change cross street name
	Given I am a 'CallCenterOperator' user role
	And the fault I am editing has the Id '202947AF-130F-4494-8C50-DB84A93648E1'
	And I enter 'Fern Street' as the cross street name
	And These faults exist
	| Id                                   | Street      | CrossStreet | Suburb   | PostCode | StatusId | TypeId | DateCompleted |
	| 202947AF-130F-4494-8C50-DB84A93648E1 | Hill Street |             | Randburg | 2194     | 1        | 2      |               |
	| 46BF992F-B00C-4D76-BDD0-CCB6B993E8EF | Hill Street |             | Randburg | 2194     | 4        | 2      | 2015-03-01    |
	When I press the Update Address button
	And I perform a find for this fault id
	Then The results should be
	| Id                                   | Street      | CrossStreet | Suburb   | PostCode | StatusId | TypeId | DateCompleted |
	| 202947AF-130F-4494-8C50-DB84A93648E1 | Hill Street | Fern Street | Randburg | 2194     | 1        | 2      |               |

Scenario: Update a fault address change suburb name
	Given I am a 'CallCenterOperator' user role
	And the fault I am editing has the Id '202947AF-130F-4494-8C50-DB84A93648E1'
	And I enter 'Sandton' as the suburb name
	And These faults exist
	| Id                                   | Street      | CrossStreet | Suburb   | PostCode | StatusId | TypeId | DateCompleted |
	| 202947AF-130F-4494-8C50-DB84A93648E1 | Hill Street |             | Randburg | 2194     | 1        | 2      |               |
	| 46BF992F-B00C-4D76-BDD0-CCB6B993E8EF | Hill Street |             | Randburg | 2194     | 4        | 2      | 2015-03-01    |
	When I press the Update Address button
	And I perform a find for this fault id
	Then The results should be
	| Id                                   | Street      | CrossStreet | Suburb  | PostCode | StatusId | TypeId | DateCompleted |
	| 202947AF-130F-4494-8C50-DB84A93648E1 | Hill Street |             | Sandton | 2194     | 1        | 2      |               |

Scenario: Update a fault address change post code
	Given I am a 'CallCenterOperator' user role
	And the fault I am editing has the Id '202947AF-130F-4494-8C50-DB84A93648E1'
	And I enter '2196' as the post code
	And These faults exist
	| Id                                   | Street      | CrossStreet | Suburb   | PostCode | StatusId | TypeId | DateCompleted |
	| 202947AF-130F-4494-8C50-DB84A93648E1 | Hill Street |             | Sandton  | 2194     | 1        | 2      |               |
	| 46BF992F-B00C-4D76-BDD0-CCB6B993E8EF | Hill Street |             | Randburg | 2194     | 4        | 2      | 2015-03-01    |
	When I press the Update Address button
	And I perform a find for this fault id
	Then The results should be
	| Id                                   | Street      | CrossStreet | Suburb  | PostCode | StatusId | TypeId | DateCompleted |
	| 202947AF-130F-4494-8C50-DB84A93648E1 | Hill Street |             | Sandton | 2196     | 1        | 2      |               |

Scenario: Update a fault address change all details
	Given I am a 'CallCenterOperator' user role
	And the fault I am editing has the Id '202947AF-130F-4494-8C50-DB84A93648E1'
	And I enter 'Rivonia Rd' as the street name
	And I enter 'Fern Ave' as the cross street name
	And I enter 'Midrand' as the suburb name
	And I enter '2127' as the post code
	And These faults exist
	| Id                                   | Street      | CrossStreet | Suburb   | PostCode | StatusId | TypeId | DateCompleted |
	| 202947AF-130F-4494-8C50-DB84A93648E1 | Hill Street |             | Sandton  | 2194     | 1        | 2      |               |
	| 46BF992F-B00C-4D76-BDD0-CCB6B993E8EF | Hill Street |             | Randburg | 2194     | 4        | 2      | 2015-03-01    |
	When I press the Update Address button
	And I perform a find for this fault id
	Then The results should be
	| Id                                   | Street     | CrossStreet | Suburb  | PostCode | StatusId | TypeId | DateCompleted |
	| 202947AF-130F-4494-8C50-DB84A93648E1 | Rivonia Rd | Fern Ave    | Midrand | 2127     | 1        | 2      |               |