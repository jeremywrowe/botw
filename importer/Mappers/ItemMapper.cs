using System.Collections.Generic;
using System.Linq;
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
                Hp = Helpers.ConvertStringToNumber(data.ElementAt(1)),
                Type = data.ElementAt(2).Trim(),
                Time = Helpers.ConvertStringToNumber(data.ElementAt(3)),
                Locations = Helpers.ConvertStringToArray(data.ElementAt(4))
            };
        }

    }
}