using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wikification.Data.Datastructure.Linking;

namespace Wikification.Data.Datastructure.Mapping
{
    public class UserBadgeMap : IEntityTypeConfiguration<UserBadge>
    {
        public void Configure(EntityTypeBuilder<UserBadge> builder)
        {
            builder.HasKey(ub => new { ub.BadgeId, ub.UserId });

            builder.HasOne(ub => ub.Badge)
                .WithMany(b => b.Users)
                .HasForeignKey(ub => ub.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ub => ub.User)
                .WithMany(u => u.EarnedBadges)
                .HasForeignKey(ub => ub.BadgeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
