using System.Collections.Generic;
using HtmlAgilityPack;

namespace importer
{
  namespace readers
  {
    interface IReader
    {
      List<List<string>> Read();
    }
  }
}