
using System.Linq;

namespace models
{
    public class Weapon : Model
    {
        public string Type { get; set; }
        public int Parry { get; set; }
        public string[] Powers { get; set; }
        public string[] Locations { get; set; }

        public Weapon(string type)
        {
            Type = type;
            Name = "";
            Parry = 0;
            Powers = new string[] { };
            Locations = new string[] { };
        }
        
        public override string ToString()
        {
            return $"Weapon {{ Type = '{Type}', Name = '{Name}', Parry = {Parry}," + 
                   $" Powers = {Helpers.ArrayToString(Powers)}, Locations = {Helpers.ArrayToString(Locations)} }}";
        }

        public override bool Equals(object other)
        {
            if (other == null || other.GetType() != GetType())
            {
                return false;
            }

            var otherWeapon = (Weapon) other;
            return Type.Equals(otherWeapon.Type) &&
                   Name.Equals(otherWeapon.Name) &&
                   Parry.Equals(otherWeapon.Parry) &&
                   Powers.OrderBy(p => p).SequenceEqual(otherWeapon.Powers.OrderBy(p => p)) &&
                   Locations.OrderBy(l => l).SequenceEqual(otherWeapon.Locations.OrderBy(l => l));
        }
    }
}