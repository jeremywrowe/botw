using System.Linq;

namespace models
{
    public class Recipe : Model
    {
        public string Name { get; set; }
        public double Hearts { get; set; }
        public string[] Effects { get; set; }
        public string[] Ingredients { get; set; }

        public Recipe()
        {
            Effects = new string[] { };
            Ingredients = new string[] { };
        }
            
        public override string ToString()
        {
            var hearts = Hearts == 0.0 ? "none" : Hearts.ToString();
            
            return $"Recipe {{ Name = '{Name}', Hearts = {hearts}, " +
                   $"Effects = {Helpers.ArrayToString(Effects)}, Ingredients = {Helpers.ArrayToString(Ingredients)} }}";
        }

        public override bool Equals(object other)
        {
            if (other == null || other.GetType() != GetType())
            {
                return false;
            }

            var otherRecipe = (Recipe) other;
            return Name.Equals(otherRecipe.Name) &&
                   Hearts.Equals(otherRecipe.Hearts) &&
                   Effects.OrderBy(e => e).SequenceEqual(otherRecipe.Effects.OrderBy(e => e)) &&
                   Ingredients.OrderBy(i => i).SequenceEqual(otherRecipe.Ingredients.OrderBy(i => i));
        }
    }
}