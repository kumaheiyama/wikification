using Wikification.Data.Interfaces;

namespace Wikification.Data.Datastructure
{
    public class Category : IAwardedXp, IEntity
    {
        public string Name { get; set; }
        public Badge Badge { get; set; }
        public int AwardedXp { get; set; }
        public int Id { get; set; }

        public int CalculatedAwardedXp()
        {
            var badgeXp = Badge != null ? Badge.CalculatedAwardedXp() : 0;
            return AwardedXp + badgeXp;
        }
    }
}
