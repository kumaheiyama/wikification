using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Wikification.Data.Datastructure.Mapping
{
    public class EventMap : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            var converter = new EnumToStringConverter<EventType>();
            builder.Property(x => x.Name).HasMaxLength(200);
            builder.Property(x => x.Type).HasConversion(converter);
        }
    }
}
