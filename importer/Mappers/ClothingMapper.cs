using System;
using System.Collections.Generic;
using System.Linq;
using models;

namespace importer.Mappers
{
    public class ClothingMapper : IMapper
    {
        private string _type;

        public ClothingMapper(string type)
        {
            _type = type;
        }
        
        public List<Model> MapMany(List<List<string>> dataItems)
        {
            var mapping = from data in dataItems select Map(data);
            return mapping.ToList();
        }

        public Model Map(List<string> data)
        {
            var defenseAndRatings = Helpers.ConvertStringToArray(data.ElementAt(1));
            
            return new Clothing
            {
                Type = _type,
                Name = data.ElementAt(0),
                Defense = Convert.ToInt32(defenseAndRatings.ElementAt(0).Trim()),
                Ratings = defenseAndRatings.Skip(1).Take(defenseAndRatings.Length - 1).ToArray(),
                Locations = Helpers.ConvertStringToArray(data.ElementAt(2))
            };
        }
    }
}