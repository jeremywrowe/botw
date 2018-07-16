using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using models;

namespace importer.Mappers
{
    public class RecipeMapper : IMapper
    {
        private readonly string _type;

        public RecipeMapper(string type)
        {
            _type = type;
        }

        public List<Model> MapMany(List<List<string>> data)
        {
            return (from item in data select Map(item)).ToList();
        }

        public Model Map(List<string> data)
        {
            return new Recipe(_type)
            {
                Name = Helpers.NormalizeString(data.ElementAt(0)),
                Hearts = MapHearts(data.ElementAt(1)),
                Effects = Helpers.ConvertStringToArray(data.ElementAt(2)),
                Ingredients = Helpers.ConvertStringToArray(data.ElementAt(3))
            };
        }

        private double MapHearts(string input)
        {
            return HeartMapping(input, "½", 0.5) +
                   HeartMapping(input, "¼", 0.25) +
                   HeartMapping(input, "¾", 0.75) +
                   HeartMapping(input, "❤", 1.0);
                
        }

        private double HeartMapping(string input, string pattern, double value)
        {
            return new Regex(pattern).Matches(input).Count * value;
        }
    }
}