using ShopOnline.Models.Dtos;

namespace ShopOnline.Web.Services.Contracts;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetItemsAsync();
    Task<ProductDto> GetItem(int id);
}