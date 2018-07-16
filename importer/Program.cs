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
            Output(new ClothingMapper("body").MapMany(itemReader.Read("clothing/body.html")));
            Output(new ClothingMapper("head").MapMany(itemReader.Read("clothing/head.html")));
            Output(new ClothingMapper("leg").MapMany(itemReader.Read("clothing/leg.html")));
            Output(new RecipeMapper("chill").MapMany(itemReader.Read("recipes/chill.html")));
            Output(new RecipeMapper("shock").MapMany(itemReader.Read("recipes/electro.html")));
            Output(new RecipeMapper("elixir").MapMany(itemReader.Read("recipes/elixirs.html")));
            Output(new RecipeMapper("energy").MapMany(itemReader.Read("recipes/energizing.html")));
            Output(new RecipeMapper("generic").MapMany(itemReader.Read("recipes/general.html")));
            Output(new RecipeMapper("hearty").MapMany(itemReader.Read("recipes/hearty.html")));
            Output(new RecipeMapper("mighty").MapMany(itemReader.Read("recipes/mighty.html")));
            Output(new RecipeMapper("sneak").MapMany(itemReader.Read("recipes/sneaky.html")));
            Output(new RecipeMapper("warmth").MapMany(itemReader.Read("recipes/spicy.html")));
            Output(new RecipeMapper("defense").MapMany(itemReader.Read("recipes/tough.html")));
            Output(new WeaponMapper("bow").MapMany(itemReader.Read("weapons/bows-arrows-boomerangs-and-rods.html")));
            Output(new WeaponMapper("club").MapMany(itemReader.Read("weapons/clubs-hammers-and-axes.html")));
            Output(new WeaponMapper("shield").MapMany(itemReader.Read("weapons/shields.html")));
            Output(new WeaponMapper("spear").MapMany(itemReader.Read("weapons/spears.html")));
            Output(new WeaponMapper("sword").MapMany(itemReader.Read("weapons/swords.html")));
            Output(new ItemMapper().MapMany(itemReader.Read("items.html")));

            return 0;
        }

        private static void Output(List<Model> models)
        {
            foreach (var row in models) Console.WriteLine(row);
        }
    }
}