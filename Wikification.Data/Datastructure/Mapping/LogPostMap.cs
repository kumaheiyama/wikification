using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Wikification.Data.Datastructure.Mapping
{
    public class LogPostMap : IEntityTypeConfiguration<LogPost>
    {
        public void Configure(EntityTypeBuilder<LogPost> builder)
        {
            builder.Property(x => x.ExceptionType).HasMaxLength(30);
            builder.Property(x => x.Sender).HasMaxLength(100);
            builder.ToTable("Log", "system");
        }
    }
}
