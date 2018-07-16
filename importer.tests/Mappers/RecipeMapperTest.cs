using System.Collections.Generic;
using importer.Mappers;
using models;
using Xunit;

namespace importer.tests.Mappers
{
    public class RecipeMapperTest
    {
        private readonly RecipeMapper subject;
        private readonly Recipe model;
        private readonly List<string> data;

        public RecipeMapperTest()
        {
            subject = new RecipeMapper("generic");
            model = new Recipe("generic")
            {
                Name = "Big Fish Stew",
                Hearts = 3.25,
                Effects = new [] { "makes you turnt", "is super trill" },
                Ingredients = new [] { "carp", "rice" }
            };
            data = new List<string>
            {
                "Big Fish Stew",
                "❤❤¾½",
                "makes you turnt     %% is super trill  ",
                "carp %% rice"
            };
        }

        [Fact]
        public void MapFromDataContainingAListOfEffectsAndIngredients()
        {
            Assert.Equal(model, subject.Map(data));
        }

        [Fact]
        public void MapManyDataOnMultipleEntries()
        {
            var entries = new List<List<string>>
            {
                data
            };
            var expected = new List<Model>
            {
                model
            };

            Assert.Equal(expected, subject.MapMany(entries));
        }
    }
}