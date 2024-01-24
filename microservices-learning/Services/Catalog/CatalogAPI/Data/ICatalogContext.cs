using CatalogAPI.Models;
using MongoDB.Driver;

namespace CatalogAPI.Data
{
    public interface ICatalogContext
    {
        public IMongoCollection<Product> Products { get;  }
    }
}
