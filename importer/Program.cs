using System;
using System.Collections.Generic;
using System.Linq;
using importer.Mappers;
using importer.Readers;
using models;
using Nest;

namespace importer
{
    internal class Program
    {
        private static int Main(string[] args)
        {
            var itemReader = new ItemReader();
            var clothing = new List<Clothing>();
            var recipes = new List<Recipe>();
            var weapons = new List<Weapon>();
            var items = new ItemMapper().MapMany(itemReader.Read("items.html"));
            
            Add(clothing, new ClothingMapper("body").MapMany(itemReader.Read("clothing/body.html")));
            Add(clothing, new ClothingMapper("head").MapMany(itemReader.Read("clothing/head.html")));
            Add(clothing, new ClothingMapper("leg").MapMany(itemReader.Read("clothing/leg.html")));
            
            Add(recipes, new RecipeMapper("chill").MapMany(itemReader.Read("recipes/chill.html")));
            Add(recipes, new RecipeMapper("shock").MapMany(itemReader.Read("recipes/electro.html")));
            Add(recipes, new RecipeMapper("elixir").MapMany(itemReader.Read("recipes/elixirs.html")));
            Add(recipes, new RecipeMapper("energy").MapMany(itemReader.Read("recipes/energizing.html")));
            Add(recipes, new RecipeMapper("generic").MapMany(itemReader.Read("recipes/general.html")));
            Add(recipes, new RecipeMapper("hearty").MapMany(itemReader.Read("recipes/hearty.html")));
            Add(recipes, new RecipeMapper("mighty").MapMany(itemReader.Read("recipes/mighty.html")));
            Add(recipes, new RecipeMapper("sneak").MapMany(itemReader.Read("recipes/sneaky.html")));
            Add(recipes, new RecipeMapper("warmth").MapMany(itemReader.Read("recipes/spicy.html")));
            Add(recipes, new RecipeMapper("defense").MapMany(itemReader.Read("recipes/tough.html")));
            
            Add(weapons, new WeaponMapper("bow").MapMany(itemReader.Read("weapons/bows-arrows-boomerangs-and-rods.html")));
            Add(weapons, new WeaponMapper("club").MapMany(itemReader.Read("weapons/clubs-hammers-and-axes.html")));
            Add(weapons, new WeaponMapper("shield").MapMany(itemReader.Read("weapons/shields.html")));
            Add(weapons, new WeaponMapper("spear").MapMany(itemReader.Read("weapons/spears.html")));
            Add(weapons, new WeaponMapper("sword").MapMany(itemReader.Read("weapons/swords.html")));

            
            Output(clothing);
            Output(recipes);
            Output(weapons);
            Output(items);
            
            var node = new Uri("http://localhost:9200");
            var settings = new ConnectionSettings(node)
                .DefaultTypeName("_doc")
                .DefaultMappingFor<Clothing>(m => m.IndexName("clothing"))
                .DefaultMappingFor<Item>(m => m.IndexName("items"))
                .DefaultMappingFor<Recipe>(m => m.IndexName("recipes"))
                .DefaultMappingFor<Weapon>(m => m.IndexName("weapons"));
            var client = new ElasticClient(settings);

            
            Console.WriteLine("STARTING IMPORT");
            Import(clothing, client);
            Import(recipes, client);
            Import(weapons, client);
            Import(items, client);
            Console.WriteLine("FINISHED IMPORT");

            return 0;
        }

        private static void Output<T>(List<T> models)
        {
            foreach (var row in models) Console.WriteLine(row);
            Console.WriteLine(new String('*', 80));
            
        }

        private static void Add<T>(List<T> existing, List<T> additions)
        {
            existing.AddRange(additions);
        }

        private static void Import<T>(List<T> models, ElasticClient client) where T : class
        {
            Console.WriteLine($"Importing {typeof(T)}");
            client.Bulk(x => x.CreateMany(models));
        }
    }
}