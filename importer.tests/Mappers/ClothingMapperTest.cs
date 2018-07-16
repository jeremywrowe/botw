using System.Collections.Generic;
using importer.Mappers;
using models;
using Xunit;

namespace importer.tests.Mappers
{
    public class ClothingMapperTest
    {
        
        private readonly ClothingMapper _subject;
        
        public ClothingMapperTest()
        {
            _subject = new ClothingMapper("head");
        }
        
        [Fact]
        public void MapFromDataContainingAListOfLocations()
        {
            var data = new List<string>
            {
                "Snowquill Headdress",
                "3 %% (Cold Resistance) %% (Armor Set Bonus: Unfreezable.)",
                "electro",
                "Rito Village (1,000 Rupees)"
            };
            
            var model = new Clothing
            {
                Type = "head",
                Name = "Snowquill Headdress",
                Defense = 3,
                Ratings = new [] { "(Cold Resistance)", "(Armor Set Bonus: Unfreezable.)"},
                Locations = new [] { "Rito Village (1,000 Rupees)" }
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
                    "Snowquill Headdress",
                    "3 %% (Cold Resistance) %% (Armor Set Bonus: Unfreezable.)",
                    "Rito Village (1,000 Rupees)"
                },
                new List<string>
                {
                    "Thunder Helm",
                    "3        %%    Lighting Proof",
                    "Side Quest: The Thunder Helm"
                }
            };
            
            var model1 = new Clothing
            {
                Type = "head",
                Name = "Snowquill Headdress",
                Defense = 3,
                Ratings = new [] { "(Cold Resistance)", "(Armor Set Bonus: Unfreezable.)"},
                Locations = new [] { "Rito Village (1,000 Rupees)" }
            };
            
            var model2 = new Clothing
            {
                Type = "head",
                Name = "Thunder Helm",
                Defense = 3,
                Ratings = new [] { "Lighting Proof" },
                Locations = new [] { "Side Quest: The Thunder Helm" }
            };
            
            Assert.Equal(new List<Model> { model1, model2 }, _subject.MapMany(dataEntries));
        }
    }
}