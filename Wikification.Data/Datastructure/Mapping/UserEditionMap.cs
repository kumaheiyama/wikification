using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wikification.Data.Datastructure.Linking;

namespace Wikification.Data.Datastructure.Mapping
{
    public class UserEditionMap : IEntityTypeConfiguration<UserEdition>
    {
        public void Configure(EntityTypeBuilder<UserEdition> builder)
        {
            builder.HasKey(ue => new { ue.EditionId, ue.UserId });

            builder.HasOne(ue => ue.Edition)
                .WithMany(e => e.Users)
                .HasForeignKey(ue => ue.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ue => ue.User)
                .WithMany(u => u.ReadEditions)
                .HasForeignKey(ue => ue.EditionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
