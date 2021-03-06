﻿using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using models;

namespace importer.Mappers
{
    public class RecipeMapper : IMapper<Recipe>
    {
        private readonly string _type;

        public RecipeMapper(string type)
        {
            _type = type;
        }

        public List<Recipe> MapMany(List<List<string>> data, List<Model> _associations = null)
        {
            return (from item in data select Map(item, _associations)).ToList();
        }

        public Recipe Map(List<string> data, List<Model> _associations = null)
        {
            var effects = from effect in Helpers.ConvertStringToArray(data.ElementAt(2))
                select EffectMapping(effect);
            
            return new Recipe(_type)
            {
                Name = Helpers.NormalizeString(data.ElementAt(0)),
                Hearts = MapHearts(data.ElementAt(1)),
                Effects = effects.ToArray(),
                Ingredients = Helpers.ConvertStringToArray(data.ElementAt(3))
            };
        }

        private double MapHearts(string input)
        {
            return HeartMapping(input, "½", 0.5) +
                   HeartMapping(input, "¼", 0.25) +
                   HeartMapping(input, "¾", 0.75) +
                   HeartMapping(input, "❤", 1.0);
                
        }

        private double HeartMapping(string input, string pattern, double value)
        {
            return new Regex(pattern).Matches(input).Count * value;
        }

        private string EffectMapping(string effect)
        {
            return effect
                .Replace("increases ", "")
                .Replace("recovers ", "")
                .Replace("extra ", "")
                .Replace("restores full", "full")
                .Replace("defense boost duration", "defense")
                .Replace("defense boost", "defense");
        }
    }
}