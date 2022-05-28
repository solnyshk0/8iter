using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DB.Models
{
    public class DiscountTransConfiguration : IEntityTypeConfiguration<DiscountTrans>
    {
        public void Configure(EntityTypeBuilder<DiscountTrans> builder)
        {
            builder.HasKey(s => new { s.ID });

            builder.HasOne(ss => ss.Discount)
                .WithMany(s => s.DiscountTrans)
                .HasForeignKey(ss => ss.DiscountId);

            builder.HasOne(ss => ss.Trans)
                .WithMany(s => s.DiscountTrans)
                .HasForeignKey(ss => ss.TransId);
        }
    }
}