using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShopTruck.Store.Infrastructure.Persistence.Configurations;

public class StoreConfiguration : IEntityTypeConfiguration<Domain.Entities.Store>
    {
    public void Configure(EntityTypeBuilder<Domain.Entities.Store> builder)
        {
        builder.ToTable("stores");

        builder.HasKey(s => s.Id);

        builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.OwnsOne(s => s.Address, address =>
        {
            address.Property(a => a.Street)
                .HasColumnName("street")
                .IsRequired();

            address.Property(a => a.City)
                .HasColumnName("city")
                .IsRequired();

            address.Property(a => a.PostalCode)
                .HasColumnName("postal_code");

            address.Property(a => a.Country)
                .HasColumnName("country")
                .IsRequired();
        });
        }
    }
