using System;
using System.Text.RegularExpressions;

namespace importer.Mappers
{
    public static class Helpers
    {
        public static int ConvertStringToNumber(string input)
        {
            var numberRegex = new Regex(@"\d+");
            return numberRegex.IsMatch(input) ? Convert.ToInt32(numberRegex.Match(input).Value) : 0;
        }

        public static string[] ConvertStringToArray(string input)
        {
            return Regex.Split(input, @"\s*%%\s*");
        }
    }
}