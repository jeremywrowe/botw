using System;
using models;
using Xunit;

namespace model.tests
{
    public class ItemTest
    {
        [Fact]
        public void ToStringOutputsAllExpectedAttributes()
        {
            var model = new Item
            {
                Name = "Something Rad",
                Hp = 10,
                Time = 22,
                Type = "Some Type",
                Locations = new[] { "one", "two" }
            };

            var expected = "Item { Name = 'Something Rad', Hp = 10, Type = 'Some Type', Time = 22, Locations = ['one', 'two'] }";
            
            Assert.Equal(expected, model.ToString());
        }
        
        [Fact]
        public void ToStringOutputsAllExpectedWithNoPropertiesAssigned()
        {
            var model = new Item();

            var expected = "Item { Name = '', Hp = 0, Type = '', Time = 0, Locations = [] }";
            
            Assert.Equal(expected, model.ToString());
        }

        [Fact]
        public void TwoItemsAreEqualWhenTheyHaveTheSameName()
        {
            var model1 = new Item { Name = "cloth" };
            var model2 = new Item { Name = "cloth" };
            
            Assert.Equal(model1, model2);
        }
    }
}