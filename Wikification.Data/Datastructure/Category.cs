using System.Collections.Generic;
using Wikification.Data.Datastructure.Linking;
using Wikification.Data.Interfaces;

namespace Wikification.Data.Datastructure
{
    public class Category : IAwardedXp, IEntity
    {
        //Properties
        public int AwardedXp { get; set; }
        public Badge Badge { get; private set; }
        public int? BadgeId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<PageCategory> Pages { get; set; }

        //Methods
        public void SetBadge(Badge badge)
        {
            Badge = badge;
        }
        public int CalculatedAwardedXp()
        {
            var badgeXp = Badge != null ? Badge.CalculatedAwardedXp() : 0;
            return AwardedXp + badgeXp;
        }
    }
}
