using System.Collections.Generic;
using importer.Mappers;
using models;
using Xunit;

namespace importer.tests.Mappers
{
    public class ItemMapperTest
    {
        private readonly ItemMapper _subject;
        
        public ItemMapperTest()
        {
            _subject = new ItemMapper();
        }
        
        [Fact]
        public void MapFromDataContainingAListOfLocations()
        {
            var data = new List<string>
            {
                "zapshroom",
                "2",
                "electro",
                "150+ ",
                "hyrule ridge %%  gerudo highlands"
            };
            
            var model = new Item
            {
                Name = "zapshroom",
                Hp = 2,
                Type = "electro",
                Time = 150,
                Locations = new[] {"hyrule ridge", "gerudo highlands"}
            };
            
            Assert.Equal(model, _subject.Map(data));
        }

        [Fact]
        public void MapManyDataOnMultipleEntries()
        {
            var dataEntries = new List<List<string>>
            {
                new List<string>
                {
                    "zapshroom",
                    "2",
                    "electro",
                    "150+ ",
                    "hyrule ridge %%  gerudo highlands"
                },
                new List<string>
                {
                    "freezeshroom",
                    "6",
                    "freeze",
                    "50+ ",
                    "a %%  b       %% c"
                }
            };
            
            var model1 = new Item
            {
                Name = "zapshroom",
                Hp = 2,
                Type = "electro",
                Time = 150,
                Locations = new[] {"hyrule ridge", "gerudo highlands"}
            };
            
            var model2 = new Item
            {
                Name = "freezeshroom",
                Hp = 6,
                Type = "freeze",
                Time = 50,
                Locations = new[] {"a", "b", "c"}
            };
            
            Assert.Equal(new List<Model> { model1, model2 }, _subject.MapMany(dataEntries));
        }
    }
}