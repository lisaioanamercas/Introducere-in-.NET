using AutoMapper;
using ProductManagement.Features.Products;
using ProductManagement.Features.Products.Dtos;

namespace ProductManagement.Common.Mapping;

public class BrandInitialsResolver : IValueResolver<Product, ProductProfileDto, string>
{
    public string Resolve(Product source, ProductProfileDto destination, string destMember, ResolutionContext context)
    {
        if (string.IsNullOrWhiteSpace(source.Brand))
            return "?";

        var words = source.Brand.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);

        if (words.Length >= 2)
            return $"{char.ToUpper(words[0][0])}{char.ToUpper(words[^1][0])}";

        return char.ToUpper(words[0][0]).ToString();
    }
}