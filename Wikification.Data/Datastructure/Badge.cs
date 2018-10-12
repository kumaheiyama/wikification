using Wikification.Data.Interfaces;

namespace Wikification.Data.Datastructure
{
    public class Badge : IAwardedXp, IEntity
    {
        public string Name { get; set; }
        public string SymbolUrl { get; set; }
        public string Description { get; set; }
        public int AwardedXp { get; set; }
        public int Id { get; set; }

        public int CalculatedAwardedXp()
        {
            return AwardedXp;
        }
    }
}
