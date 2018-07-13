using System.Collections.Generic;

namespace importer.Readers
{
    internal interface IReader
    {
        List<List<string>> Read(string documentPath);
    }
}