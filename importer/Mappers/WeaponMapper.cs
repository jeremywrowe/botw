using System.Collections.Generic;
using System.Linq;
using models;

namespace importer.Mappers
{
    public class WeaponMapper : IMapper
    {
        private readonly string _type;
        
        public WeaponMapper(string type)
        {
            _type = type;
        }
        
        public List<Model> MapMany(List<List<string>> data)
        {
            return (from item in data select Map(item)).ToList();
        }

        public Model Map(List<string> data)
        {
            var parryAndPowers = Helpers.ConvertStringToArray(data.ElementAt(1));
            return new Weapon(_type)
            {
                Name = Helpers.NormalizeString(data.ElementAt(0)),
                Parry = Helpers.ConvertStringToNumber(parryAndPowers.ElementAt(0)),
                Powers = parryAndPowers.Skip(1).ToArray(),
                Locations = Helpers.ConvertStringToArray(data.ElementAt(2))
            };
        }
    }
}