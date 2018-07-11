using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;

namespace importer
{
    namespace readers
    {
        public class ItemReader : IReader
        {
            readonly HtmlDocument htmlDocument;
                
            public ItemReader(string documentPath)
            {
                htmlDocument = new HtmlDocument();
                htmlDocument.Load(documentPath);
            }

            public List<List<string>> Read()
            {
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
                var tdData = from td in tr.ChildNodes.Where(node => node.InnerText.Trim() != "")
                             select sanitizeColumn(td.InnerText);

                return tdData.ToList();
            }

            private string sanitizeColumn(string column)
            {
                return column.Trim()
                             .ToLower()
                             .Replace("&nbsp;", " ")
                             .Replace("&amp;", "&")
                             .Replace(",", " ||")
                             .Replace(@"\r\n", " ");
                                
            }
        }
    }
}