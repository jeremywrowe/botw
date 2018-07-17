using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using models;

namespace frontend.Controllers
{
    [Route("api/recipes")]
    public class RecipesController : Controller
    {
        [HttpGet]
        public IEnumerable<Recipe> Index()
        {
            var connection = new Connection();
            return connection.Client.Search<Recipe>(search => search
                .From(0)
                .Size(1000)
                .Sort(item => item.Ascending("name.keyword").Ascending("type.keyword"))
            ).Documents;
        }
    }
}
