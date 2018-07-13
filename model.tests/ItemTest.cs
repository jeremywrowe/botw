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
            var model = new Item()
            {
                Material = "Something Rad",
                Hp = 10,
                Time = 22,
                Type = "Some Type",
                Locations = new string[] { "one", "two" }
            };

            var expected = "Item { Material = 'Something Rad', Hp = 10, Type = 'Some Type', Time = 22, Locations = ['one', 'two'] }";
            
            Assert.Equal(expected, model.ToString());
        }
    }
}