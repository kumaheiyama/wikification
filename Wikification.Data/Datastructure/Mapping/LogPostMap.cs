using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Wikification.Data.Datastructure.Mapping
{
    public class LogPostMap : IEntityTypeConfiguration<LogPost>
    {
        public void Configure(EntityTypeBuilder<LogPost> builder)
        {
            var converter = new EnumToStringConverter<LogSeverity>();
            builder.Property(x => x.ExceptionType).HasMaxLength(30);
            builder.Property(x => x.Sender).HasMaxLength(100);
            builder.Property(x => x.Level).HasConversion(converter);
            builder.ToTable("Log", "system");
        }
    }
}
