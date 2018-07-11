using System;
using System.IO;
using importer.readers;
using System.Collections.Generic;

namespace importer
{
    class Program
    {
        static int Main(string[] args)
        {
            Output("ITEMS", new ItemReader(Path.Join(Directory.GetCurrentDirectory(), @"data/html/items.html")).Read());
            Output("SWORDS", new ItemReader(Path.Join(Directory.GetCurrentDirectory(), @"data/html/swords.html")).Read());
            Output("SHIELDS", new ItemReader(Path.Join(Directory.GetCurrentDirectory(), @"data/html/shields.html")).Read());

            return 0;
        }

        static void Output(string label, List<List<string>> data)
        {
            Console.WriteLine(label);
            Console.WriteLine(new String('#', 80));
            Console.WriteLine();
            foreach (var row in data)
            {
                Console.WriteLine(row.JoinWith(", "));
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
