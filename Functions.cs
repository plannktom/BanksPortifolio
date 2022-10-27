using System;

namespace BanksPortifolio
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

        public static bool IsDouble(string number)
        {
            double tempDouble;
            return double.TryParse(number, out tempDouble);
        }
    }
}
