using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace importer.Mappers
{
    public static class Helpers
    {
        public static int ConvertStringToNumber(string input)
        {
            var numberRegex = new Regex(@"\d+");

            if (numberRegex.IsMatch(input))
            {
                return Convert.ToInt32(numberRegex.Matches(input).Last().Value);
            }
            return 0;
        }

        public static string[] ConvertStringToArray(string input)
        {
            return Regex.Split(input, @"\s*%%\s*");
        }
    }
}