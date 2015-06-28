namespace RoadMaintenance.FaultLogging.Core.Enums
{
    public enum Status
    {
        PendingInvestigation = 1,
        PendingTeamDispatch = 2,
        InProgress = 3,
        Repaired = 4,
        PendingRepairVerification = 5,
        OnHold = 6,
        Rejected = 7,
    }
}