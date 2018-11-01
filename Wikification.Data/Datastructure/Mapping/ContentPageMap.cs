
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Wikification.Data.Datastructure.Mapping
{
    public class ContentPageMap : IEntityTypeConfiguration<ContentPage>
    {
        public void Configure(EntityTypeBuilder<ContentPage> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).HasMaxLength(50);
            builder.Property(x => x.ExternalId).HasMaxLength(100).IsRequired(true);
        }
    }
}
