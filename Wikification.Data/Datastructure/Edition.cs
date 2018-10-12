using System;
using Wikification.Data.Interfaces;

namespace Wikification.Data.Datastructure
{
    public partial class Edition : IAwardedXp, IEntity
    {
        public Edition()
        {
            DateCreated = DateTime.Now.Ticks;
            Version = new EditionVersion();
        }
        public Edition(EditionVersion version) : this()
        {
            Version = version;
        }

        public string Contents { get; set; }
        public int AwardedXp { get; set; }
        public long DateCreated { get; set; }
        public string EditionDescription { get; set; }
        public EditionVersion Version { get; private set; }
        public int Id { get; set; }

        public int CalculatedAwardedXp()
        {
            return AwardedXp;
        }
    }
}
