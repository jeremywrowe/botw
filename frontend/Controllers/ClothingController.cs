using System.Collections.Generic;
using models;
using Microsoft.AspNetCore.Mvc;

namespace frontend.Controllers
{
    [Route("api/clothing")]
    public class ClothingController
    {
        
        [HttpGet]
        public IEnumerable<Clothing> Index()
        {
            var connection = new Connection();
            return connection.Client.Search<Clothing>(search => search
                .From(0)
                .Size(1000)
                .Sort(item => item.Ascending("name.keyword"))
            ).Documents;
        }
    }
}