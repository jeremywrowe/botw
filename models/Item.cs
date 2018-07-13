using System;
using System.Linq;

namespace models
{
    public class Item : Model
    {
        public string Material { get; set; }
        public int Hp { get; set; }
        public string Type { get; set; }
        public int Time { get; set; }
        public string[] Locations;
        
        public override string ToString()
        {
            var quotedLocations = from location in Locations select $"'{location}'";
            var locationString = string.Join(", ", quotedLocations.ToList());
            
            return $"Item {{ Material = '{Material}', Hp = {Hp}, Type = '{Type}', Time = {Time}, Locations = [{locationString}] }}";
        }
    }
}