using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using models;

namespace frontend.Controllers
{
    [Route("api/weapons")]
    public class WeaponsController : Controller
    {
        [HttpGet]
        public IEnumerable<Weapon> Index()
        {
            var connection = new Connection();
            return connection.Client.Search<Weapon>(search => search
                .From(0)
                .Size(1000)
                .Sort(item => item.Ascending("name.keyword").Ascending("type.keyword"))
            ).Documents;
        }
    }
}
