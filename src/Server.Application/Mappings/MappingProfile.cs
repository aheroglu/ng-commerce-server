using Mapster;
using Server.Application.Dtos;
using Server.Domain.Entities;

namespace Server.Application.Mappings;

public class MappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Category, CategoryDto>();
        config.NewConfig<Brand, BrandDto>();
        config.NewConfig<Product, ProductDto>();
        config.NewConfig<ProductImage, ProductImageDto>();
        config.NewConfig<AppUser, AppUserDto>();
    }
}