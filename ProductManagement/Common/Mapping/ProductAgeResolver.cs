using AutoMapper;
using ProductManagement.Features.Products;
using ProductManagement.Features.Products.Dtos;

namespace ProductManagement.Common.Mapping;

public class ProductAgeResolver : IValueResolver<Product, ProductProfileDto, string>
{
    public string Resolve(Product source, ProductProfileDto destination, string destMember, ResolutionContext context)
    {
        var daysSinceRelease = (DateTime.UtcNow - source.ReleaseDate).Days;

        if (daysSinceRelease < 30)
            return "New Release";

        if (daysSinceRelease < 365)
        {
            var months = daysSinceRelease / 30;
            return $"{months} months old";
        }

        if (daysSinceRelease < 1825)
        {
            var years = daysSinceRelease / 365;
            return $"{years} years old";
        }

        return "Classic";
    }
}