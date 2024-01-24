using CatalogAPI.Data;
using CatalogAPI.Models;
using MongoDB.Driver;

namespace CatalogAPI.Repositories
{
    public interface IProductRepository
    {
        //list/filter fetch
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(string id);
        Task<IEnumerable<Product>> GetProductByName(string name);
        Task<IEnumerable<Product>> GetProductByCategory(string categoryName);
        //CRUD operations
        Task CreateProduct(Product product);
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(string id);
    }

    public class ProductRepository(ICatalogContext catalogContext) : IProductRepository
    {
        private readonly ICatalogContext _catalogDB = catalogContext ?? throw new ArgumentNullException(nameof(catalogContext));
        public async Task<Product> GetProduct(string id) =>
            await this._catalogDB.Products
                                    .Find(f => f.Id == id)
                                    .FirstOrDefaultAsync();
        public async Task<IEnumerable<Product>> GetProductByCategory(string categoryName)
        {
            FilterDefinition<Product> ProductByCategoryFilter = Builders<Product>.Filter.Eq(f => f.Category, categoryName);
            return await this._catalogDB.Products
                                    .Find(ProductByCategoryFilter)//.Find(f => f.Category == categoryName)
                                    .ToListAsync();
        }
        public async Task<IEnumerable<Product>> GetProductByName(string productName)
        {
            FilterDefinition<Product> ProductByNameFilter = Builders<Product>.Filter.Eq(f => f.Name, productName);
            return await this._catalogDB.Products
                                    .Find(ProductByNameFilter)//.Find(f => f.Name == productName)
                                    .ToListAsync();
        }
        public async Task<IEnumerable<Product>> GetProducts() => await this._catalogDB.Products.Find(f => true).ToListAsync();
        public async Task CreateProduct(Product product)
        {
            await this._catalogDB.Products.InsertOneAsync(product);
        }
        public async Task<bool> UpdateProduct(Product product)
        {
            ReplaceOneResult updateResult = await this._catalogDB.Products.ReplaceOneAsync(filter: f => f.Id == product.Id, replacement: product);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
        public async Task<bool> DeleteProduct(string id)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await this._catalogDB.Products
                                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }
    }
}
