using System.Collections.Generic;

namespace Wikification.Business
{
    public class UserDto
    {
        public string ExternalId { get; set; }
        public string Username { get; set; }
        public int CollectedXp { get; set; }
        public LevelDto Level { get; set; }
        public ICollection<EditionDto> ReadEditions { get; set; }
        public ICollection<EditionDto> UnreadEditions { get; set; }
        public ICollection<BadgeDto> EarnedBadges { get; set; }
    }
}
