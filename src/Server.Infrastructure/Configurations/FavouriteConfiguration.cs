using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Server.Domain.Entities;

namespace Server.Infrastructure.Configurations;

public sealed class FavouriteConfiguration : IEntityTypeConfiguration<Favourite>
{
    public void Configure(EntityTypeBuilder<Favourite> builder)
    {
        builder.ToTable("Favourites");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.PriceWhenAdded).HasPrecision(18, 2);
    }
}
