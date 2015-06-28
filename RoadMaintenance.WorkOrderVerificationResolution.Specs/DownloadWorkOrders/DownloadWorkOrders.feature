Feature: Download Work Orders
	In order to inspect faults
	As an inspector
	I want to get scheduled inspections when I login

Scenario: Scheduled Inspections Received on Successfull Login
Given I am a "Inspector"
And the following work orders
| Id | Status               | FaultId | Priority |
| 1  | AwaitingVerification | 10      | Low      |
| 2  | AwaitingVerification | 11      | High     |
| 3  | AwaitingVerification | 12      | Normal   |
| 4  | Scheduled            | 13      | Normal   |
| 5  | AwaitingVerification | 14      | Normal   |
| 6  | AwaitingVerification | 15      | High     |
| 7  | AwaitingVerification | 16      | High     |
| 8  | AwaitingVerification | 17      | Normal   |
| 9  | Created              | 18      | High     |
| 10 | AwaitingVerification | 19      | Normal   |
| 11 | AwaitingVerification | 20      | Normal   |
| 12 | AwaitingVerification | 21      | Normal   |
When I get the top ten work orders
Then the result in ascending order is
| Id | Status               | FaultId | Priority |
| 2  | AwaitingVerification | 11      | High     |
| 6  | AwaitingVerification | 15      | High     |
| 7  | AwaitingVerification | 16      | High     |
| 1  | AwaitingVerification | 10      | Low      |
| 3  | AwaitingVerification | 12      | Normal   |
| 5  | AwaitingVerification | 14      | Normal   |
| 8  | AwaitingVerification | 17      | Normal   |
| 10 | AwaitingVerification | 19      | Normal   |
| 11 | AwaitingVerification | 20      | Normal   |
| 12 | AwaitingVerification | 21      | Normal   |

#If there are high priority faults, only these should be displayed at first.
#Lower priority faults will appear once the priority faults have been dealt with.
#Ideally, the faults should be sorted based on optimising the inspector’s route so that the distance that needs to be travelled is minimised.
#As the inspector is able to view, at any a point in time, a number of faults that need to be inspected he/she may decide to override the optimal route that is being suggested.
#This decision could be made based on traffic information, unexpected road closures and so.
#Therefore the inspection list should be reordered to produce an optimal route based on wherever the inspector is currently located.
#The inspection list should be periodically updated in the background.

#An inspector can view a particular fault requiring inspection by selecting it from the list.
#A map and turn-by-turn navigation directions will then be provided to direct the inspector to the fault.
#Once at the fault location, the inspector can review the quality of the work and verify the work order on the device,
#marking the fault as resolved or requesting additional work (as described in the previous section).

#There are a numbers of inspectors working for the department and they should each be assigned a different set of work orders to inspect.
#Once a work order has been assigned for inspection it cannot be recalled and assigned to a different inspector.
#In a future iteration, it may be possible to implement load balancing.
#This would allow for the dynamic reallocation of inspection tasks based on the inspector’s position and workload.