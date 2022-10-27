using System;

namespace BanksPortifolio.Entities
{
    class Functions
    {
        public static bool IsDateTime(string date)
        {
            DateTime tempDate;
            return DateTime.TryParse(date, out tempDate);
        }

        public static bool IsInteger(string number)
        {
            int tempInt;
            return int.TryParse(number, out tempInt);
        }
    }
}
