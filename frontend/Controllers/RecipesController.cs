using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using models;
using Nest;

namespace frontend.Controllers
{
    [Route("api/recipes")]
    public class RecipesController : Controller
    {
        [HttpGet]
        public IEnumerable<Model> Index(string ingredients, string effects, string types)
        {
            var connection = new Connection();
            return connection.Client.Search<Recipe>(search => Filter(search, ingredients, effects, types)).Documents;
        }

        private SearchDescriptor<Recipe> Filter(SearchDescriptor<Recipe> search, string ingredients, string effects, string types)
        {
            var updatedSearch = search
                .From(0)
                .Size(1000)
                .Sort(i => i.Descending("hearts").Ascending("type.keyword").Ascending("name.keyword"));

            return updatedSearch.Query(query => query
                .Bool(b => b
                    .Must(bm =>
                    {
                        QueryContainer container = null;

                        if (!String.IsNullOrWhiteSpace(ingredients))
                        {
                            foreach (var val in ingredients.Split(","))
                            {
                                container &= bm.Term(t => t.Field("ingredients.keyword").Value(val));
                            }
                        }
                        
                        if (!String.IsNullOrWhiteSpace(effects))
                        {
                            QueryContainer effectContainer = null;
                            foreach (var val in effects.Split(","))
                            {
                                effectContainer |= bm.Match(t => t.Field("effects").Query(val));
                            }
                            
                            container &= effectContainer;
                        }
                        
                        if (!String.IsNullOrWhiteSpace(types))
                        {
                            QueryContainer typeContainer = null;
                            foreach (var val in types.Split(","))
                            {
                                typeContainer |= bm.Term(t => t.Field("type.keyword").Value(val));
                            }

                            container &= typeContainer;
                        }

                        return container;
                    })
                )
            );
        }
    }
}