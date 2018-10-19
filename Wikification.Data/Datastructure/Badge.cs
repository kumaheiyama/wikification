using System.Collections.Generic;
using Wikification.Data.Datastructure.Linking;
using Wikification.Data.Interfaces;

namespace Wikification.Data.Datastructure
{
    public class Badge : IAwardedXp, IEntity
    {
        public Badge() { }
        public Badge(string name, string description, string symbolUrl, int awardedXp) : this()
        {
            Name = name;
            Description = description;
            SymbolUrl = symbolUrl;
            AwardedXp = awardedXp;
        }

        //Properties
        public int AwardedXp { get; private set; }
        public string Description { get; private set; }
        public int Id { get; set; }
        public string Name { get; private set; }
        public string SymbolUrl { get; private set; }
        public ExternalSystem System { get; set; }
        public int SystemId { get; set; }
        public ICollection<UserBadge> Users { get; set; }

        //Methods
        public int CalculatedAwardedXp()
        {
            return AwardedXp;
        }
        public void SetAwardedXp(int xp)
        {
            AwardedXp = xp;
        }
        public void SetName(string name)
        {
            Name = name;
        }
        public void SetSymbolUrl(string url)
        {
            SymbolUrl = url;
        }
        public void SetDescription(string desc)
        {
            Description = desc;
        }
    }
}
