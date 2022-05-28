using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DB.Models
{
    public class ProductTransConfiguration : IEntityTypeConfiguration<ProductTrans>
    {
        public void Configure(EntityTypeBuilder<ProductTrans> builder)
        {
            builder.HasKey(s => new { s.Id });

            builder.HasOne(ss => ss.Product)
                .WithMany(s => s.ProductTrans)
                .HasForeignKey(ss => ss.ProductId);

            builder.HasOne(ss => ss.Trans)
                .WithMany(s => s.ProductTrans)
                .HasForeignKey(ss => ss.TransId);
        }
    }
}