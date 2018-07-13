using System.Collections.Generic;
using System.IO;
using System.Linq;
using HtmlAgilityPack;

namespace importer.Readers
{
    public class ItemReader : IReader
    {
        private readonly HtmlDocument _htmlDocument;

        public ItemReader()
        {
            _htmlDocument = new HtmlDocument();
        }

        public List<List<string>> Read(string documentPath)
        {
            _htmlDocument.Load(Path.Join(Directory.GetCurrentDirectory(), @"data/html", documentPath));
            return (from tr in BodyNodes() select ConvertRow(tr)).ToList();
        }

        private IEnumerable<HtmlNode> HeaderDocuments()
        {
            return _htmlDocument.DocumentNode.SelectNodes("//table/thead/tr");
        }

        private IEnumerable<HtmlNode> BodyNodes()
        {
            return _htmlDocument.DocumentNode.SelectNodes("//table/tbody/tr");
        }

        private List<string> ConvertRow(HtmlNode tr)
        {
            var tdData = from td in tr.ChildNodes.Where(node => SanitizeColumn(node.InnerText) != "")
                select SanitizeColumn(td.InnerText);

            return tdData.ToList();
        }

        private static string SanitizeColumn(string column)
        {
            var sections = column.Trim()
                .ToLower()
                .Replace("&nbsp;", " ")
                .Replace("&amp;", "&")
                .Replace(",", " %% ")
                .Split("\n");

            return string.Join(" %% ", from section in sections select section.Trim());
        }
    }
}