Feature: Update the GPS Coordinates for a fault
	In order for a technician to more easily locate a fault location
	As a call-center operator
	I want to be able to update the GPS coordinates for a fault

@greenPath
Scenario: Update the GPS coordinates of an open fault: coordinate format spaces
	Given I am a 'CallCenterOperator' user role
	And I enter '33 34 35 W' as the longitude
	And I enter '56 21 23 S' as the latitude
	And These faults exist
	| Id                                   | Latitude | Longitude | Street      | CrossStreet      | Suburb   | PostCode | StatusId | TypeId | DateCompleted |
	| 202947AF-130F-4494-8C50-DB84A93648E1 |          |           | Hill Street | Malabongwe Drive | Randburg | 2194     | 1        | 2      |               |
	| 46BF992F-B00C-4D76-BDD0-CCB6B993E8EF |          |           | Hill Street | Malabongwe Drive | Randburg | 2194     | 4        | 2      | 2015-03-01    |
	And the fault I am editing has the Id '202947AF-130F-4494-8C50-DB84A93648E1'
	When I press the Update button
	And I perform a find for this fault id
	Then The results should be
	| Id                                   | Latitude   | Longitude  | Street      | CrossStreet      | Suburb   | PostCode | StatusId | TypeId | DateCompleted |
	| 202947AF-130F-4494-8C50-DB84A93648E1 | 56 21 23 S | 33 34 35 W | Hill Street | Malabongwe Drive | Randburg | 2194     | 1        | 2      |               |

Scenario: Update the GPS coordinates of an open fault: coordinate format dashes
	Given I am a 'CallCenterOperator' user role
	And I enter '33-34-35-W' as the longitude
	And I enter '56-21-23-S' as the latitude
	And These faults exist
	| Id                                   | Latitude | Longitude | Street      | CrossStreet      | Suburb   | PostCode | StatusId | TypeId | DateCompleted |
	| 202947AF-130F-4494-8C50-DB84A93648E1 |          |           | Hill Street | Malabongwe Drive | Randburg | 2194     | 1        | 2      |               |
	| 46BF992F-B00C-4D76-BDD0-CCB6B993E8EF |          |           | Hill Street | Malabongwe Drive | Randburg | 2194     | 4        | 2      | 2015-03-01    |
	And the fault I am editing has the Id '202947AF-130F-4494-8C50-DB84A93648E1'
	When I press the Update button
	And I perform a find for this fault id
	Then The results should be
	| Id                                   | Latitude   | Longitude  | Street      | CrossStreet      | Suburb   | PostCode | StatusId | TypeId | DateCompleted |
	| 202947AF-130F-4494-8C50-DB84A93648E1 | 56 21 23 S | 33 34 35 W | Hill Street | Malabongwe Drive | Randburg | 2194     | 1        | 2      |               |

Scenario: Update the GPS coordinates of an open fault: coordinate format backslashes
	Given I am a 'CallCenterOperator' user role
	And I enter '33/34/35/W' as the longitude
	And I enter '56/21/23/S' as the latitude
	And These faults exist
	| Id                                   | Latitude | Longitude | Street      | CrossStreet      | Suburb   | PostCode | StatusId | TypeId | DateCompleted |
	| 202947AF-130F-4494-8C50-DB84A93648E1 |          |           | Hill Street | Malabongwe Drive | Randburg | 2194     | 1        | 2      |               |
	| 46BF992F-B00C-4D76-BDD0-CCB6B993E8EF |          |           | Hill Street | Malabongwe Drive | Randburg | 2194     | 4        | 2      | 2015-03-01    |
	And the fault I am editing has the Id '202947AF-130F-4494-8C50-DB84A93648E1'
	When I press the Update button
	And I perform a find for this fault id
	Then The results should be
	| Id                                   | Latitude   | Longitude  | Street      | CrossStreet      | Suburb   | PostCode | StatusId | TypeId | DateCompleted |
	| 202947AF-130F-4494-8C50-DB84A93648E1 | 56 21 23 S | 33 34 35 W | Hill Street | Malabongwe Drive | Randburg | 2194     | 1        | 2      |               |

Scenario: Update the GPS coordinates of a fault where the status is Closed
	Given I am a 'CallCenterOperator' user role
	And I enter '33/34/35/W' as the longitude
	And I enter '56/21/23/S' as the latitude
	And These faults exist
	| Id                                   | Latitude | Longitude | Street      | CrossStreet      | Suburb   | PostCode | StatusId | TypeId | DateCompleted |
	| 202947AF-130F-4494-8C50-DB84A93648E1 |          |           | Hill Street | Malabongwe Drive | Randburg | 2194     | 1        | 2      |               |
	| 46BF992F-B00C-4D76-BDD0-CCB6B993E8EF |          |           | Hill Street | Malabongwe Drive | Randburg | 2194     | 4        | 2      | 2015-03-01    |
	And the fault I am editing has the Id '46BF992F-B00C-4D76-BDD0-CCB6B993E8EF'
	When I press the Update button
	Then an InvalidOperationException should be thrown

Scenario: Update the GPS coordinates of a fault that does not exist
	Given I am a 'CallCenterOperator' user role
	And I enter '33/34/35/W' as the longitude
	And I enter '56/21/23/S' as the latitude
	And These faults exist
	| Id                                   | Latitude | Longitude | Street      | CrossStreet      | Suburb   | PostCode | StatusId | TypeId | DateCompleted |
	| 202947AF-130F-4494-8C50-DB84A93648E1 |          |           | Hill Street | Malabongwe Drive | Randburg | 2194     | 1        | 2      |               |
	| 46BF992F-B00C-4D76-BDD0-CCB6B993E8EF |          |           | Hill Street | Malabongwe Drive | Randburg | 2194     | 4        | 2      | 2015-03-01    |
	And the fault I am editing has the Id '0b46c325-cfa3-413a-a683-b0b2bf022c8c'
	When I press the Update button
	Then an ArgumentException should be thrown