using System.Collections.Generic;
using System.Linq;
using importer.Readers;
using Xunit;

namespace importer.tests.Readers
{
    public class ItemReaderTest
    {
        private readonly ItemReader _subject;

        public ItemReaderTest()
        {
            _subject = new ItemReader();
        }
        
        [Fact]
        public void ParsingADocumentOmitsTheHeaderRow()
        {
            var nodes = _subject.Read("items.html");
            var header = new List<string>()
            {
                "zelda breath of the wild materials",
                "hp",
                "type",
                "time +",
                "locations found"
            };

            Assert.DoesNotContain(header, nodes);
        }
        
        [Fact]
        public void ParsingADocumentGeneratesAValidRow()
        {
            var nodes = _subject.Read("items.html");
            var expected = new List<string>()
            {
                "ancient screw",
                "–",
                "–",
                "70+",
                "dropped by guardians"
            };

            Assert.Equal(expected, nodes.Find(node => node.ElementAt(0) == "ancient screw"));
        }

        [Fact]
        public void ParsingADocumentRemovesNewLinesFromOutput()
        {
            var row = _subject.Read("items.html").Find(item => item.ElementAt(0) == "amber");
            var expected = "ore deposits %%  dropped by talus & silver enemies";
            
            Assert.Equal(expected, row.Last());
        }
    }
}