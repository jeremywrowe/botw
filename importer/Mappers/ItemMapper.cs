using System.Collections.Generic;
using System.Linq;
using models;

namespace importer.Mappers
{
    public class ItemMapper : IMapper<Item>
    {
        public List<Item> MapMany(List<List<string>> dataItems, List<Model> associations)
        {
            var mapping = from data in dataItems select Map(data, associations);
            return mapping.ToList();
        }

        public Item Map(List<string> data, List<Model> associations)
        {
            var name = Helpers.NormalizeString(data.ElementAt(0));
            var locations = from location in Helpers.ConvertStringToArray(data.ElementAt(4))
                select NormalizeLocation(location);

            var filteredRecipes = from recipe in new List<Recipe>(associations.Cast<Recipe>())
                where recipe.Ingredients.Contains(name)
                select recipe;
            
            
            return new Item
            {
                Name = name,
                Hp = Helpers.ConvertStringToNumber(data.ElementAt(1)),
                Type = Helpers.NormalizeString(data.ElementAt(2)),
                Time = Helpers.ConvertStringToNumber(data.ElementAt(3)),
                Locations = locations.ToArray(),
                Recipes = filteredRecipes.ToArray()
            };
        }

        private string NormalizeLocation(string location)
        {
            return location
                .Replace("also sold in ", "")
                .Replace("sold in ", "")
                .Replace("dropped by ", "");
        }
    }
}