using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Wikification.Data.Datastructure.Mapping
{
    public class ExternalSystemMap : IEntityTypeConfiguration<ExternalSystem>
    {
        public void Configure(EntityTypeBuilder<ExternalSystem> builder)
        {
            builder.Property(x => x.CallbackUrl).HasMaxLength(200);
            builder.Property(x => x.ExternalId).HasMaxLength(50);
            builder.Property(x => x.Name).HasMaxLength(50);
        }
    }
}
