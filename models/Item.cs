namespace models
{
    public class Item : Model
    {
        public int Hp { get; set; }
        public string Type { get; set; }
        public int Time { get; set; }
        public string[] Locations { get; set; }

        public Item()
        {
            Name = "";
            Hp = 0;
            Type = "";
            Time = 0;
            Locations = new string[]{};
        }
        
        public override string ToString()
        {
            return $"Item {{ Name = '{Name}', Hp = {Hp}, Type = '{Type}'," + 
                   $" Time = {Time}, Locations = {Helpers.ArrayToString(Locations)} }}";
        }

        public override bool Equals(object other)
        {
            if (other == null || other.GetType() != GetType())
            {
                return false;
            }

            var otherItem = (Item) other;
            
            return Name.Equals(otherItem.Name) &&
                   Hp.Equals(otherItem.Hp) &&
                   Type.Equals(otherItem.Type) &&
                   Time.Equals(otherItem.Time);
        }
    }
}