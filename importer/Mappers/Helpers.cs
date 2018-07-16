using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace importer.Mappers
{
    public static class Helpers
    {
        public static string NormalizeString(string input)
        {
            if (input.Trim().Equals("-") || input.Trim().Equals("–"))
            {
                return "";
            }

            return input.Trim().Replace("(", "").Replace(")", "");
        }
        
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
            if (input.Trim().Equals("-") || input.Trim().Equals("–"))
            {
                return new string[] {};
            }
            
            return (from element in Regex.Split(input, @"\s*%%\s*") select element.Trim()).ToArray();
        }
    }
}