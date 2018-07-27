using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using models;

namespace importer.Mappers
{
    public class ClothingMapper : IMapper<Clothing>
    {
        private string _type;

        public ClothingMapper(string type)
        {
            _type = type;
        }
        
        public List<Clothing> MapMany(List<List<string>> dataItems, List<Model> _associations = null)
        {
            var mapping = from data in dataItems select Map(data, _associations);
            return mapping.ToList();
        }

        public Clothing Map(List<string> data, List<Model> _associations = null)
        {
            var defenseAndRatings = Helpers.ConvertStringToArray(data.ElementAt(1));
            var locations = from location in Helpers.ConvertStringToArray(data.ElementAt(2))
                            select NormalizeLocation(location);
            
            return new Clothing
            {
                Type = _type,
                Name = Helpers.NormalizeString(data.ElementAt(0)),
                Defense = Helpers.ConvertStringToNumber(defenseAndRatings.ElementAt(0).Trim()),
                Ratings = defenseAndRatings.Skip(1).Take(defenseAndRatings.Length - 1).ToArray(),
                Locations = locations.ToArray()
            };
        }

        private string NormalizeLocation(string location)
        {
            return Regex.Replace(location, @"^\w+:\s+", "").Replace("amiibo unlock", "amiibo");
        }
    }
}