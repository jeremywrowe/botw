using models;
using Xunit;

namespace model.tests
{
    public class RecipeTest
    {
        [Fact]
        public void ToStringOutputsAllExpectedAttributes()
        {
            var model = new Recipe("generic")
            {
                Name = "baked apple",
                Hearts = 1.75,
                Ingredients = new [] { "apple" }
            };

            var expected = "Recipe { Type = 'generic', Name = 'baked apple', Hearts = 1.75, Effects = [], Ingredients = ['apple'] }";
            
            Assert.Equal(expected, model.ToString());
        }
        
        [Fact]
        public void ToStringOutputsAllExpectedWithNoPropertiesAssigned()
        {
            var model = new Recipe("generic");
            var expected = "Recipe { Type = 'generic', Name = '', Hearts = none, Effects = [], Ingredients = [] }";
            
            Assert.Equal(expected, model.ToString());
        }

        [Fact]
        public void TwoRecipesAreEqualWhenTheyHaveTheSameName()
        {
            var model1 = new Recipe("generic") { Name = "Spicy Simmered Fruit" };
            var model2 = new Recipe("generic") { Name = "Spicy Simmered Fruit" };
            
            Assert.Equal(model1, model2);
        }
    }
}