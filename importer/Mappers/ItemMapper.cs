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
                Material = Helpers.NormalizeString(data.ElementAt(0)),
                Hp = Helpers.ConvertStringToNumber(data.ElementAt(1)),
                Type = Helpers.NormalizeString(data.ElementAt(2)),
                Time = Helpers.ConvertStringToNumber(data.ElementAt(3)),
                Locations = Helpers.ConvertStringToArray(data.ElementAt(4))
            };
        }

    }
}