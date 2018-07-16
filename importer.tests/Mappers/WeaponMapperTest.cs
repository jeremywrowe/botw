using System.Collections.Generic;
using importer.Mappers;
using models;
using Xunit;

namespace importer.tests.Mappers
{
    public class WeaponMapperTest
    {
        private readonly WeaponMapper subject;
        private readonly Model model;
        private readonly List<string> data;
        
        public WeaponMapperTest()
        {
            subject = new WeaponMapper("sword");
            model = new Weapon("sword")
            {
                Name = "Master Sword",
                Parry = 30,
                Powers = new []
                {
                    "As Weapon Durability Lowers so will the Damage of the Sword",
                    "Regenerates Weapon Durability",
                    "Deals 2x Damage when Fighting Ganon"
                },
                Locations = new []
                {
                    "The Korok Forest",
                    "You Can View The Full Guide Here: How To Get The master Sword In Zelda Breath of the Wild"
                }
            };
            data = new List<string>
            {
                "Master Sword",
                "2 - 30" + 
                    "%% As Weapon Durability Lowers so will the Damage of the Sword." +
                    "%% (Regenerates Weapon Durability)" + 
                    "%% Deals 2x Damage when Fighting Ganon",
                "The Korok Forest" + 
                    "%% You Can View The Full Guide Here: How To Get The master Sword In Zelda Breath of the Wild."
            };
        }
        
        [Fact]
        public void MapFromDataContainingAListOfLocations()
        {
            Assert.Equal(model, subject.Map(data));
        }
        
        [Fact]
        public void MapManyDataOnMultipleEntries()
        {
            var dataEntries = new List<List<string>> { data };

            Assert.Equal(new List<Model> { model }, subject.MapMany(dataEntries));
        }
    }
}