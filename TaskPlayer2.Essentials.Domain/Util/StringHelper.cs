using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskPlayer2.Essentials.Domain.Util
{
    /// <summary>
    /// Helps on the string manipulations
    /// </summary>
    public static class StringHelper
    {

        public static Guid ParseGuid(string value)
        {
            return new Guid(value);
        }

        public static DateTime ParseDateTime(string value)
        {
            return DateTime.Parse(value);
        }

        public static int ParseInt(string value)
        {
            return Convert.ToInt32(value);
        }

        public static double ParseDouble(string value)
        {
            return Convert.ToDouble(value);
        }

        
    }
}
