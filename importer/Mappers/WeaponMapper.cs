using System.Collections.Generic;
using System.Linq;
using models;

namespace importer.Mappers
{
    public class WeaponMapper : IMapper<Weapon>
    {
        private readonly string _type;
        
        public WeaponMapper(string type)
        {
            _type = type;
        }
        
        public List<Weapon> MapMany(List<List<string>> data, List<Model> _associations = null)
        {
            return (from item in data select Map(item)).ToList();
        }

        public Weapon Map(List<string> data, List<Model> _associations = null)
        {
            var parryAndPowers = Helpers.ConvertStringToArray(data.ElementAt(1));
            var locations = from location in Helpers.ConvertStringToArray(data.ElementAt(2))
                select NormalizeLocation(location);
            
            return new Weapon(_type)
            {
                Name = Helpers.NormalizeString(data.ElementAt(0)),
                Parry = Helpers.ConvertStringToNumber(parryAndPowers.ElementAt(0)),
                Powers = parryAndPowers.Skip(1).ToArray(),
                Locations = locations.ToArray()
            };
        }
        
        private string NormalizeLocation(string location)
        {
            return location
                .Replace("you can view the full guide here: how to get the master sword in zelda breath of the wild", "trial of sword")
                .Replace("reward for clearing the ", "")
                .Replace("amiibo unlock", "amiibo")
                .Replace("complete the shrine quest", "complete quest")
                .Replace("reward for clearing ", "")
                .Replace("also sold in ", "")
                .Replace("sold in ", "")
                .Replace("near ", "")
                .Replace("dropped by ", "");
        }
    }
}