using ShopOnline.API.Entities;

namespace ShopOnline.API.Repositories.Contracts;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetItemsAsync();
    Task<IEnumerable<ProductCategory>> GetCategoriesAsync();
    Task<Product> GetItem(int id);
    Task<ProductCategory> GetCategory(int id);
}