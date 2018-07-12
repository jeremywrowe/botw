using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using System;
using System.IO;

namespace importer
{
    namespace readers
    {
        public class ItemReader : IReader
        {
            readonly HtmlDocument htmlDocument;
            
            public ItemReader()
            {
                htmlDocument = new HtmlDocument();
            }
            
            public List<List<string>> Read(string documentPath)
            {
                htmlDocument.Load(Path.Join(Directory.GetCurrentDirectory(), @"data/html", documentPath));

                var headerContents = (from tr in HeaderDocuments() select convertRow(tr)).ToList();
                var bodyContents = (from tr in BodyNodes() select convertRow(tr)).ToList();

                return headerContents.Concat(bodyContents).ToList();
            }

            private IEnumerable<HtmlNode> HeaderDocuments()
            {
                return htmlDocument.DocumentNode.SelectNodes("//table/thead/tr");
            }

            private IEnumerable<HtmlNode> BodyNodes()
            {
                return htmlDocument.DocumentNode.SelectNodes("//table/tbody/tr");
            }

            private List<string> convertRow(HtmlNode tr)
            {
                var tdData = from td in tr.ChildNodes.Where(node => sanitizeColumn(node.InnerText) != "")
                             select sanitizeColumn(td.InnerText);

                return tdData.ToList();
            }

            private string sanitizeColumn(string column)
            {
                var sections = column.Trim()
                             .ToLower()
                             .Replace("&nbsp;", " ")
                             .Replace("&amp;", "&")
                             .Replace(",", " %% ")
                             .Split("\n");

                return String.Join(" %% ", from section in sections select section.Trim());
            }
        }
    }
}