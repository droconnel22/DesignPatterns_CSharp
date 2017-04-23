using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.CodeWars.CSharp.Misc
{

    /*
        Write a function, which takes a non-negative integer (seconds) as input and returns the time in a human-readable format (HH:MM:SS)

        HH = hours, padded to 2 digits, range: 00 - 99
        MM = minutes, padded to 2 digits, range: 00 - 59
        SS = seconds, padded to 2 digits, range: 00 - 59
        The maximum time never exceeds 359999 (99:59:59)

        You can find some examples in the test fixtures.

    */
    public static class Human_Readable_Time
    {
        public static string GetReadableTime(int seconds)
        {

            return CalucateHour(seconds) + CalculateMinute(seconds) + string.Empty;
        }

        //00 to 99
        private static string CalucateHour(int seconds)
        {
            return "\"" + seconds / (60 * 60) + "\":";
        }

        // 00 to 59
        private static string CalculateMinute(int seconds)
        {
            return "\"" + seconds / 60 + "\":";
        }

        // 00 to 59
        private static string CalculateSeconds(int seconds)
        {
            return string.Empty;
        }
    }
}
