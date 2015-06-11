using System.Collections.Generic;

namespace RoadMaintenance.DataService.Datastore
{
    public static class LookupTables
    {
        public static Dictionary<int, string> FaultStatuses = new Dictionary<int, string>
        {
            { 1, "Awaiting Inspection" },
            { 2, "Awaiting Work Scheduling" },
            { 3, "Work Scheduled" },
            { 4, "In Progress" },
            { 5, "Repaired" },
            { 6, "On Hold" },
            { 7, "Unresolvable" },
        };

        public static Dictionary<int, string> FaultTypes = new Dictionary<int, string>
        {
            { 1, "Pothole" },
            { 2, "Drainage" },
            { 3, "TrafficLight" },
            { 4, "RoadMarking" },
            { 5, "Accident" },
            { 6, "Signage" },
        };
    }
}