using System.Collections.Generic;
using models;
using Xunit;

namespace importer.tests.Mappers
{
    public class ItemMapperTest
    {
        [Fact]
        public void MapFromDataContainingAListOfLocations()
        {
            var data = new List<List<string>>
            {
                new List<string>
                {
                    "zapshroom",
                    "2",
                    "electro",
                    "150+ ",
                    "hyrule ridge %%  gerudo highlands"
                }
            };
            var model = new Item
            {
                Material = "zapshroom",
                Hp = 2,
                Type = "electro",
                Time = 150,
                Locations = new string[] {"hyrule ridge", "gerudo highlands"}
            };
            
            
        }
    }
}