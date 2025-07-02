using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Common
{
    public static class Extensions
    {
        public static string ToFormattedDateString(this DateTime dateTime, string format = "dd-MM-yyyy")
        {
            return dateTime.ToString(format);
        }
    }
}
