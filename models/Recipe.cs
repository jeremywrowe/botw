using System.Linq;

namespace models
{
    public class Recipe : Model
    {
        public string Type { get; }
        public double Hearts { get; set; }
        public string[] Effects { get; set; }
        public string[] Ingredients { get; set; }

        public Recipe(string type)
        {
            Type = type;
            Effects = new string[] { };
            Ingredients = new string[] { };
        }
            
        public override string ToString()
        {
            var hearts = Hearts == 0.0 ? "none" : Hearts.ToString();
            
            return $"Recipe {{ Type = '{Type}', Name = '{Name}', Hearts = {hearts}, " +
                   $"Effects = {Helpers.ArrayToString(Effects)}, Ingredients = {Helpers.ArrayToString(Ingredients)} }}";
        }

        public override bool Equals(object other)
        {
            if (other == null || other.GetType() != GetType())
            {
                return false;
            }

            var otherRecipe = (Recipe) other;
            return Type.Equals(otherRecipe.Type) &&
                   Name.Equals(otherRecipe.Name) &&
                   Hearts.Equals(otherRecipe.Hearts) &&
                   Effects.OrderBy(e => e).SequenceEqual(otherRecipe.Effects.OrderBy(e => e)) &&
                   Ingredients.OrderBy(i => i).SequenceEqual(otherRecipe.Ingredients.OrderBy(i => i));
        }
    }
}