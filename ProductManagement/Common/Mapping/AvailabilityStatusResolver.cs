﻿using AutoMapper;
using ProductManagement.Features.Products;
using ProductManagement.Features.Products.Dtos;

namespace ProductManagement.Common.Mapping;

public class AvailabilityStatusResolver : IValueResolver<Product, ProductProfileDto, string>
{
    public string Resolve(Product source, ProductProfileDto destination, string destMember, ResolutionContext context)
    {
        if (!source.IsAvailable)
            return "Out of Stock";

        if (source.StockQuantity == 0)
            return "Unavailable";

        if (source.StockQuantity == 1)
            return "Last Item";

        if (source.StockQuantity <= 5)
            return "Limited Stock";

        return "In Stock";
    }
}
