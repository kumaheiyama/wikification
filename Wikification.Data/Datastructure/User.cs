using System.Collections.Generic;
using System.Linq;
using Wikification.Data.Interfaces;

namespace Wikification.Data.Datastructure
{
    public class User : IEntity
    {
        public string ExternalId { get; set; }
        public string Username { get; set; }
        public int CollectedXp()
        {
            var editionXps = ReadEditions.Sum(x => x.AwardedXp);
            var badgeXps = EarnedBadges.Sum(x => x.AwardedXp);
            return editionXps + badgeXps;
        }
        public Level Level()
        {
            //TODO add different levels
            return null;
        }
        public ICollection<Edition> ReadEditions { get; set; }
        public ICollection<Edition> UnreadEditions()
        {
            //TODO get list of pages and editions
            return null;
        }
        public ICollection<Badge> EarnedBadges { get; set; }
        public int Id { get; set; }
    }
}
