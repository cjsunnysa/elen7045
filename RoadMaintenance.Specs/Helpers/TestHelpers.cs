using System;

namespace RoadMaintenance.FaultLogging.Specs.Helpers
{
    public static class TestHelpers
    {
        public static DateTime AsDateTime(this string dateString)
        {
            var year = Int32.Parse(dateString.Substring(0, 4));
            var month = Int32.Parse(dateString.Substring(5, 2));
            var day = Int32.Parse(dateString.Substring(8, 2));

            return new DateTime(year,month,day);
        }
    }
}
