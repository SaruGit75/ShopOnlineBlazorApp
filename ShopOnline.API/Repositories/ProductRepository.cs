using Microsoft.EntityFrameworkCore;
using ShopOnline.API.Data;
using ShopOnline.API.Entities;
using ShopOnline.API.Repositories.Contracts;

namespace ShopOnline.API.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ShopOnlineDbContext _context;

    public ProductRepository(ShopOnlineDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetItemsAsync()
    {
        var allProducts = await _context.Products.AsNoTracking().ToListAsync();
        return allProducts;
    }

    public async Task<IEnumerable<ProductCategory>> GetCategoriesAsync()
    {
        var categories = await _context.ProductCategories.AsNoTracking().ToListAsync();
        return categories;
    }

    public async Task<Product> GetItem(int id)
    {
        var productEntity = await _context.Products.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);
        if (productEntity != null) 
            return productEntity;
        return new Product();   //TODO elleçle
    }

    public async Task<ProductCategory> GetCategory(int id)
    {
        var categoryOfProduct = await _context.ProductCategories.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);

        if (categoryOfProduct is not null)
            return categoryOfProduct;
        return new ProductCategory();   //elleçle
    }
}