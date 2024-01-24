using CatalogAPI.Models;
using MongoDB.Driver;

namespace CatalogAPI.Data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration configuration)
        {
            MongoClient dbClient = new(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            IMongoDatabase clientDatabase = dbClient.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
            Products = clientDatabase.GetCollection<Product>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));

            CatalogContextSeed.SeedData(Products);
        }

        public IMongoCollection<Product> Products { get; }
    }
}
