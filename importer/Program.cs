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
            // CLOTHING
            Output("BODY", new ItemReader("clothing/body.html").Read());
            Output("HEAD", new ItemReader("clothing/head.html").Read());
            Output("LEG", new ItemReader("clothing/leg.html").Read());

            // RECIPIES
            Output("CHILL", new ItemReader("recipes/chill.html").Read());
            Output("ELECTRO", new ItemReader("recipes/electro.html").Read());
            Output("ELIXIRS", new ItemReader("recipes/elixirs.html").Read());
            Output("ENERGIZING", new ItemReader("recipes/energizing.html").Read());
            Output("GENERAL", new ItemReader("recipes/general.html").Read());
            Output("HEARTY", new ItemReader("recipes/hearty.html").Read());
            Output("MIGHTY", new ItemReader("recipes/mighty.html").Read());
            Output("SNEAKY", new ItemReader("recipes/sneaky.html").Read());
            Output("SPICY", new ItemReader("recipes/spicy.html").Read());
            Output("TOUGH", new ItemReader("recipes/tough.html").Read());

            // WEAPONS
            Output("BOWS ARROWS BOOMERANGS AND RODS", new ItemReader("weapons/bows-arrows-boomerangs-and-rods.html").Read());
            Output("CLUBS HAMMERS AND AXES", new ItemReader("weapons/clubs-hammers-and-axes.html").Read());
            Output("SHIELDS", new ItemReader("weapons/shields.html").Read());
            Output("SPEARS", new ItemReader("weapons/spears.html").Read());
            Output("SWORDS", new ItemReader("weapons/swords.html").Read());

            // ITEMS
            Output("ITEMS", new ItemReader("items.html").Read());

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
