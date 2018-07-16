namespace models
{
    public class Item : Model
    {
        public string Material { get; set; }
        public int Hp { get; set; }
        public string Type { get; set; }
        public int Time { get; set; }
        public string[] Locations { get; set; }

        public Item()
        {
            Material = "";
            Hp = 0;
            Type = "";
            Time = 0;
            Locations = new string[]{};
        }
        
        public override string ToString()
        {
            return $"Item {{ Material = '{Material}', Hp = {Hp}, Type = '{Type}'," + 
                   $" Time = {Time}, Locations = {Helpers.ArrayToString(Locations)} }}";
        }

        public override bool Equals(object other)
        {
            if (other == null || other.GetType() != GetType())
            {
                return false;
            }

            var otherItem = (Item) other;
            
            return Material.Equals(otherItem.Material) &&
                   Hp.Equals(otherItem.Hp) &&
                   Type.Equals(otherItem.Type) &&
                   Time.Equals(otherItem.Time);
        }
    }
}