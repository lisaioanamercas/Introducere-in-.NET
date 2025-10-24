using AutoMapper;
using ProductManagement.Features.Products;
using ProductManagement.Features.Products.Dtos;

namespace ProductManagement.Common.Mapping;

public class CategoryDisplayResolver : IValueResolver<Product, ProductProfileDto, string>
{
    public string Resolve(Product source, ProductProfileDto destination, string destMember, ResolutionContext context)
    {
        return source.Category switch
        {
            ProductCategory.Electronics => "Electronics & Technology",
            ProductCategory.Clothing => "Clothing & Fashion",
            ProductCategory.Books => "Books & Media",
            ProductCategory.HomeAppliances => "Home & Garden",
            _ => "Uncategorized"
        };
    }
}