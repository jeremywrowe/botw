using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using models;

namespace frontend.Controllers
{
    [Route("api/items")]
    public class ItemsController : Controller
    {
        [HttpGet]
        public IEnumerable<Item> Index()
        {
            var connection = new Connection();
            return connection.Client.Search<Item>(search => search
                .From(0)
                .Size(1000)
                .Sort(item => item.Ascending("name.keyword").Ascending("type.keyword").Ascending("locations.keyword"))
            ).Documents;
        }
    }
}