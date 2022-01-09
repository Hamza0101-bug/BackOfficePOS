using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
            builder.Property(p => p.ImageName).IsRequired();
            builder.HasOne(b => b.Brand).WithMany().
                    HasForeignKey(p => p.BrandID).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(b => b.Category).WithMany().
                    HasForeignKey(p => p.CategoryID).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(b => b.Branch).WithMany().
                HasForeignKey(p => p.BranchID).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
