using System.Collections.Generic;
using System.Linq;
using Wikification.Data.Datastructure.Linking;
using Wikification.Data.Interfaces;

namespace Wikification.Data.Datastructure
{
    public class User : IEntity
    {
        //Properties
        public ICollection<UserBadge> EarnedBadges { get; }
        public string ExternalId { get; private set; }
        public int Id { get; set; }
        public Level Level { get; private set; }
        public int? LevelId { get; set; }
        public ICollection<UserEdition> ReadEditions { get; }
        public ExternalSystem System { get; set; }
        public int SystemId { get; set; }
        public string Username { get; private set; }

        //Methods
        public void SetExternalId(string newExternalId)
        {
            //TODO check if externalId is already taken
            ExternalId = newExternalId;
        }
        public void SetLevel(Level newLevel)
        {
            //TODO check that not lower than current level, users cannot be demoted
            Level = newLevel;
        }
        public void SetUsername(string newUsername)
        {
            //TODO check if username is already taken
            Username = newUsername;
        }
        public void AddReadEdition(Edition edition)
        {
            if (!ReadEditions.Any(x => x.EditionId == edition.Id && x.UserId == this.Id))
            {
                ReadEditions.Add(new UserEdition {
                    User = this,
                    Edition = edition
                });
            }
        }
        public void AddBadge(Badge badge)
        {
            if (!EarnedBadges.Any(x => x.BadgeId == badge.Id && x.UserId == this.Id))
            {
                EarnedBadges.Add(new UserBadge
                {
                    Badge = badge,
                    User = this
                });
            }
        }
        public int CollectedXp()
        {
            var editionXps = ReadEditions.Sum(x => x.Edition.AwardedXp);
            var badgeXps = EarnedBadges.Sum(x => x.Badge.AwardedXp);
            return editionXps + badgeXps;
        }
        public ICollection<Edition> UnreadEditions()
        {
            //TODO: get list of editions and compare to list of read editions
            return new List<Edition>();
        }
    }
}
