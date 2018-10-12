using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Wikification.Data.Datastructure.Mapping
{
    public class BadgeMap : IEntityTypeConfiguration<Badge>
    {
        public void Configure(EntityTypeBuilder<Badge> builder)
        {
            builder.Property(x => x.Description).HasMaxLength(300);
            builder.Property(x => x.Name).HasMaxLength(50);
            builder.Property(x => x.SymbolUrl).HasMaxLength(150);
        }
    }
}
