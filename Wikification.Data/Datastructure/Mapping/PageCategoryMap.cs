using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wikification.Data.Datastructure.Linking;

namespace Wikification.Data.Datastructure.Mapping
{
    public class PageCategoryMap : IEntityTypeConfiguration<PageCategory>
    {
        public void Configure(EntityTypeBuilder<PageCategory> builder)
        {
            builder.HasKey(pc => new { pc.CategoryId, pc.PageId });

            builder.HasOne(pc => pc.Category)
                .WithMany(p => p.Pages)
                .HasForeignKey(pc => pc.PageId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(pc => pc.Page)
                .WithMany(c => c.Categories)
                .HasForeignKey(pc => pc.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
