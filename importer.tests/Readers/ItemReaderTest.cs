using Xunit;
using importer.readers;
using System.Collections.Generic;
using HtmlAgilityPack;
using System.Linq;

namespace importer.tests.Readers
{
    public class ItemReaderTest
    {
        [Fact]
        public void ReadParsesTheHTMLFileOutputtingAValidArrayOfData()
        {
            var reader = new ItemReader();
            var nodes = reader.Read();

            System.Console.WriteLine("turds");
        }
    }
}