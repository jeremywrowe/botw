using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using models;

namespace importer.Mappers
{
    public class ItemMapper : IMapper
    {
        public List<Model> MapMany(List<List<string>> dataItems)
        {
            var mapping = from data in dataItems select Map(data);
            return mapping.ToList();
        }

        public Model Map(List<string> data)
        {
            return new Item
            {
                Material = data.ElementAt(0).Trim(),
                Hp = ConvertStringToNumber(data.ElementAt(1)),
                Type = data.ElementAt(2).Trim(),
                Time = ConvertStringToNumber(data.ElementAt(3)),
                Locations = Regex.Split(data.ElementAt(4), @"\s*%%\s*")
            };
        }

        private static int ConvertStringToNumber(string input)
        {
            var numberRegex = new Regex(@"\d+");
            return numberRegex.IsMatch(input) ? Convert.ToInt32(numberRegex.Match(input).Value) : 0;
        }
    }
}