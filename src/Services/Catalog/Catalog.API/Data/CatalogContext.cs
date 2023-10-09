using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration config)
        {
            var mongoClient = new MongoClient(config.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = mongoClient.GetDatabase(config.GetValue<string>("DatabaseSettings:DatabaseName"));

            Products = database.GetCollection<Product>(config.GetValue<string>("DatabaseSettings:CollectionName"));
            CatalogContextSeed.SeedData(Products);
        }
        public IMongoCollection<Product> Products { get; }
    }
}
