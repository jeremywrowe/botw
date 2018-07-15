using System.Linq;
using System.Net;

namespace models
{
    public class Clothing : Model
    {
        public string Type;
        public string Name;
        public int Defense;
        public string[] Ratings;
        public string[] Locations;

        public Clothing()
        {
            Type = "head";
            Name = "";
            Defense = 0;
            Ratings = new string[] { };
            Locations = new string[] { };
        }
        
        public override string ToString()
        {
            return $"Clothing {{ Type = '{Type}', Name = '{Name}', Defense = {Defense}," + 
                   $" Raitings = {Helpers.ArrayToString(Ratings)}, Locations = {Helpers.ArrayToString(Locations)} }}";
        }
        
        public override bool Equals(object other)
        {
            if (other == null || other.GetType() != GetType())
            {
                return false;
            }

            var otherClothing = (Clothing) other;

            return Type.Equals(otherClothing.Type) &&
                   Name.Equals(otherClothing.Name) &&
                   Defense.Equals(otherClothing.Defense);
        }
    }
}