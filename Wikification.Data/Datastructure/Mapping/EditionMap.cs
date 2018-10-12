
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Wikification.Data.Datastructure.Mapping
{
    public class EditionMap : IEntityTypeConfiguration<Edition>
    {
        public void Configure(EntityTypeBuilder<Edition> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.EditionDescription).HasMaxLength(150);
        }
    }
}
