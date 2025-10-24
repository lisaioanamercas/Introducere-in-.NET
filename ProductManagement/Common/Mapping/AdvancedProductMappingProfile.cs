using AutoMapper;
using ProductManagement.Features.Products;
using ProductManagement.Features.Products.Dtos;

namespace ProductManagement.Common.Mapping;

public class AdvancedProductMappingProfile : Profile
{
    public AdvancedProductMappingProfile()
    {
        // CreateProductProfileRequest → Product
        CreateMap<CreateProductProfileRequest, Product>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForMember(dest => dest.IsAvailable, opt => opt.MapFrom(src => src.StockQuantity > 0))
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => 
                src.Category == ProductCategory.HomeAppliances ? null : src.ImageUrl))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src =>
                src.Category == ProductCategory.HomeAppliances ? src.Price * 0.9m : src.Price));

        // Product → ProductProfileDto
        CreateMap<Product, ProductProfileDto>()
            .ForMember(dest => dest.CategoryDisplayName, opt => opt.MapFrom<CategoryDisplayResolver>())
            .ForMember(dest => dest.FormattedPrice, opt => opt.MapFrom<PriceFormatterResolver>())
            .ForMember(dest => dest.ProductAge, opt => opt.MapFrom<ProductAgeResolver>())
            .ForMember(dest => dest.BrandInitials, opt => opt.MapFrom<BrandInitialsResolver>())
            .ForMember(dest => dest.AvailabilityStatus, opt => opt.MapFrom<AvailabilityStatusResolver>());
    }
}