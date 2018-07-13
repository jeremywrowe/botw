using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using models;

namespace importer.Mappers
{
    public class ItemMapper : IMapper
    {
        public Model Map(List<string> data)
        {
            var timeRegex = new Regex(@"\d+");
            var time = timeRegex.Match(data.ElementAt(3));
            
            return new Item
            {
                Material = data.ElementAt(0).Trim(),
                Hp = Convert.ToInt32(data.ElementAt(1)),
                Type = data.ElementAt(2).Trim(),
                Time = Convert.ToInt32(time.Value),
                Locations = Regex.Split(data.ElementAt(4), @"\s*%%\s*")
            };
        }
    }
}