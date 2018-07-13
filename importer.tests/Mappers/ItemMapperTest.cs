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
                Material = "zapshroom",
                Hp = 2,
                Type = "electro",
                Time = 150,
                Locations = new[] {"hyrule ridge", "gerudo highlands"}
            };
            
            Assert.Equal(model, _subject.Map(data));
        }
    }
}