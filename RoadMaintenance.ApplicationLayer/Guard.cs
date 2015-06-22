using System;
using System.Linq;
using System.Reflection;

namespace RoadMaintenance.ApplicationLayer
{
    public static class Guard
    {
        public static void ForLessEqualToZero(int value, string name)
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(name, string.Format("{0} cannot be less than or equal to zero.",name));
        }

        public static void ForNullOrEmpty(string value, string name)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(name, string.Format("{0} cannot be null or empty.", name));
        }

        public static void ForNull(object value, string name)
        {
            if (value == null)
                throw new ArgumentNullException(name, string.Format("{0} cannot be null.", name));
        }

        public static void ForAllPropertiesNullOrEmpty(object param, string paramName)
        {
            var nonNullOrEmptyParams = (from p in param.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                        where p.GetValue(param, null) != null
                                        select param);

            if (!nonNullOrEmptyParams.Any())
                throw new ArgumentNullException(paramName, string.Format("Properties of {0} cannot all be null or empty.", paramName));
        }
    }
}
