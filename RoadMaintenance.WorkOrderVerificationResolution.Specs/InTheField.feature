Feature: In the Field

#Inspectors conduct inspections
#in order to verify completed work orders
#when it is not possible make a decision from the central office.

Scenario: Work Order List
Given Inspectors use mobile devices to receive scheduled inspections, to navigate to fault locations, and to perform the actual verification of work orders.
When inspector logs on to the system via his/her device
Then the device will download the ten work orders requiring inspection.

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