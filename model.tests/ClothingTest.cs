using models;
using Xunit;

namespace model.tests
{
    public class ClothingTest
    {
        [Fact]
        public void ToStringWorksWithAnEmptyObject()
        {
            var model = new Clothing();
            
            Assert.Equal(
                "Clothing { Type = 'head', Name = '', Defense = 0, Raitings = [], Locations = [] }",
                model.ToString()
            );
        }

        [Fact]
        public void ToStringAnObjectWithProperties()
        {
            var model = new Clothing
            {
                Defense = 22,
                Locations = new [] { "east", "west" },
                Name = "Some Item",
                Ratings = new [] { "good", "great" },
                Type = "body"
            };
            
            Assert.Equal(
                "Clothing { Type = 'body', Name = 'Some Item', Defense = 22, Raitings = ['good', 'great'], Locations = ['east', 'west'] }",
                model.ToString()
            );
        }

        [Fact]
        public void EqualsIsTrueWhenTwoNewClothingModelsAreCompared()
        {
            var model1 = new Clothing();
            var model2 = new Clothing();
            
            Assert.Equal(model1, model2);
        }

        [Fact]
        public void TwoClothingModelsAreNotConsideredEqualWithDifferentNames()
        {
            var model1 = new Clothing();
            var model2 = new Clothing
            {
                Name = "Doesn't Matter"
            };
            
            Assert.NotEqual(model1, model2);
        }
    }
}