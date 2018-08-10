using System;
using Nest;

namespace models
{
    public class Connection : IConnection
    {
        public ElasticClient Client { get; }

        public Connection(string host = "http://localhost:9200")
        {
            var node = new Uri(host);
            var settings = new ConnectionSettings(node)
                .DefaultTypeName("_doc")
                .DefaultMappingFor<Clothing>(m => m.IndexName("clothing"))
                .DefaultMappingFor<Item>(m => m.IndexName("items"))
                .DefaultMappingFor<Recipe>(m => m.IndexName("recipes"))
                .DefaultMappingFor<Weapon>(m => m.IndexName("weapons"));

            Client = new ElasticClient(settings);
        }
        
    }
}