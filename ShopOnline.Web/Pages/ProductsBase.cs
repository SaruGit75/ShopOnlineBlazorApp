using Microsoft.AspNetCore.Components;
using ShopOnline.Models.Dtos;
using ShopOnline.Web.Services.Contracts;

namespace ShopOnline.Web.Pages;

public class ProductsBase : ComponentBase
{
    [Inject]    //property injection
    public IProductService ProductService { get; set; }

    public IEnumerable<ProductDto> Products { get; set; }


    protected override async Task OnInitializedAsync()
    {
        Products = await ProductService.GetItemsAsync();
    }

    protected IOrderedEnumerable<IGrouping<int, ProductDto>> GetGroupedProductsByCategory()
    {
        return from product in Products
               group product by product.CategoryId
            into prodByCatGroup
               orderby prodByCatGroup.Key
               select prodByCatGroup;
    }

    protected string GetCategoryName(IGrouping<int, ProductDto> groupedProductDto)
    {
        return groupedProductDto?.FirstOrDefault(t => t.CategoryId == groupedProductDto.Key)?.CategoryName;
    }
}