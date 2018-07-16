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
            Output("BODY", new ClothingMapper("body").MapMany(itemReader.Read("clothing/body.html")));
            Output("HEAD", new ClothingMapper("head").MapMany(itemReader.Read("clothing/head.html")));
            Output("LEG", new ClothingMapper("leg").MapMany(itemReader.Read("clothing/leg.html")));

            // RECIPES
            Output("COOL DOWN", itemReader.Read("recipes/chill.html"));
            Output("SHOCK RESISTANT", itemReader.Read("recipes/electro.html"));
            Output("ELIXIRS", itemReader.Read("recipes/elixirs.html"));
            Output("ENERGIZING", itemReader.Read("recipes/energizing.html"));
            Output("GENERAL", itemReader.Read("recipes/general.html"));
            Output("HEARTY", itemReader.Read("recipes/hearty.html"));
            Output("MIGHTY", itemReader.Read("recipes/mighty.html"));
            Output("SNEAKY", itemReader.Read("recipes/sneaky.html"));
            Output("KEEP WARM", itemReader.Read("recipes/spicy.html"));
            Output("DEFENSE", itemReader.Read("recipes/tough.html"));

            // WEAPONS
            Output("BOWS ARROWS BOOMERANGS AND RODS", new WeaponMapper("bow").MapMany(itemReader.Read("weapons/bows-arrows-boomerangs-and-rods.html")));
            Output("CLUBS HAMMERS AND AXES", new WeaponMapper("club").MapMany(itemReader.Read("weapons/clubs-hammers-and-axes.html")));
            Output("SHIELDS", new WeaponMapper("shield").MapMany(itemReader.Read("weapons/shields.html")));
            Output("SPEARS", new WeaponMapper("spear").MapMany(itemReader.Read("weapons/spears.html")));
            Output("SWORDS", new WeaponMapper("sword").MapMany(itemReader.Read("weapons/swords.html")));

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