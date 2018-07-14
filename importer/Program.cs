using System;
using System.Collections.Generic;
using importer.Mappers;
using importer.Readers;
using models;

namespace importer
{
    internal class Program
    {
        private static int Main(string[] args)
        {
            var itemReader = new ItemReader();
            // CLOTHING
            Output("BODY", itemReader.Read("clothing/body.html"));
            Output("HEAD", itemReader.Read("clothing/head.html"));
            Output("LEG", itemReader.Read("clothing/leg.html"));

            // RECIPIES
            Output("CHILL", itemReader.Read("recipes/chill.html"));
            Output("ELECTRO", itemReader.Read("recipes/electro.html"));
            Output("ELIXIRS", itemReader.Read("recipes/elixirs.html"));
            Output("ENERGIZING", itemReader.Read("recipes/energizing.html"));
            Output("GENERAL", itemReader.Read("recipes/general.html"));
            Output("HEARTY", itemReader.Read("recipes/hearty.html"));
            Output("MIGHTY", itemReader.Read("recipes/mighty.html"));
            Output("SNEAKY", itemReader.Read("recipes/sneaky.html"));
            Output("SPICY", itemReader.Read("recipes/spicy.html"));
            Output("TOUGH", itemReader.Read("recipes/tough.html"));

            // WEAPONS
            Output("BOWS ARROWS BOOMERANGS AND RODS", itemReader.Read("weapons/bows-arrows-boomerangs-and-rods.html"));
            Output("CLUBS HAMMERS AND AXES", itemReader.Read("weapons/clubs-hammers-and-axes.html"));
            Output("SHIELDS", itemReader.Read("weapons/shields.html"));
            Output("SPEARS", itemReader.Read("weapons/spears.html"));
            Output("SWORDS", itemReader.Read("weapons/swords.html"));

            // ITEMS
            Output("ITEMS", new ItemMapper().MapMany(itemReader.Read("items.html")));

            return 0;
        }

        private static void Output(string label, List<List<string>> data)
        {
            Console.WriteLine(new string('#', 80));
            Console.WriteLine(label.PadLeft(40 - label.Length / 2 + 1));
            Console.WriteLine(new string('#', 80));
            Console.WriteLine();
            foreach (var row in data) Console.WriteLine(string.Join(" ^^ ", row));
            Console.WriteLine();
            Console.WriteLine();
        }

        private static void Output(string label, List<Model> models)
        {
            Console.WriteLine(new string('#', 80));
            Console.WriteLine(label.PadLeft(40 - label.Length / 2 + 1));
            Console.WriteLine(new string('#', 80));
            Console.WriteLine();
            foreach (var row in models) Console.WriteLine(row);
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}