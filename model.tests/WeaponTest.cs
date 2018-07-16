using models;
using Xunit;

namespace model.tests
{
    public class WeaponTest
    {
        
        [Fact]
        public void ToStringOutputsAllExpectedAttributes()
        {
            var model = new Weapon("shield")
            {
                Name = "Hylian Shield",
                Parry = 60,
                Powers = new [] { "It's.. awesome" },
                Locations = new[] { "Hyrule Castle" }
            };

            var expected = "Weapon { Type = 'shield', Name = 'Hylian Shield', Parry = 60, Powers = ['It's.. awesome'], Locations = ['Hyrule Castle'] }";
            
            Assert.Equal(expected, model.ToString());
        }
        
        [Fact]
        public void ToStringOutputsAllExpectedWithNoPropertiesAssigned()
        {
            var model = new Weapon("spear");
            var expected = "Weapon { Type = 'spear', Name = '', Parry = 0, Powers = [], Locations = [] }";
            
            Assert.Equal(expected, model.ToString());
        }

        [Fact]
        public void TwoWeaponsAreEqualWhenTheyHaveTheSameName()
        {
            var model1 = new Weapon("sword") { Name = "Master Sword" };
            var model2 = new Weapon("sword") { Name = "Master Sword" };
            
            Assert.Equal(model1, model2);
        }
    }
}