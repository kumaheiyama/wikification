using System;
using System.Collections.Generic;
using Wikification.Data.Datastructure.Linking;
using Wikification.Data.Extensions;
using Wikification.Data.Interfaces;

namespace Wikification.Data.Datastructure
{
    public partial class Edition : IAwardedXp, IEntity
    {
        public Edition()
        {
            DateCreated = DateTime.UtcNow.Ticks;
            Version = new EditionVersion();
        }
        public Edition(string contents, int awardedXp, string editionDescription) : this()
        {
            Contents = contents;
            AwardedXp = awardedXp;
            EditionDescription = editionDescription;
        }
        public Edition(EditionVersion version) : this()
        {
            Version = version;
        }

        //Properties
        public int AwardedXp { get; private set; }
        public string Contents { get; private set; }
        public long DateCreated { get; private set; }
        public string EditionDescription { get; private set; }
        public int Id { get; set; }
        public ContentPage Page { get; set; }
        public int PageId { get; set; }
        public ICollection<UserEdition> Users { get; set; }
        public EditionVersion Version { get; private set; }

        //Methods
        public void SetAwardedXp(int xp)
        {
            AwardedXp = xp;
        }
        public void SetContents(string contents)
        {
            Contents = contents;
        }
        public int CalculatedAwardedXp()
        {
            return AwardedXp;
        }
        public void SetEditionDescription(string desc)
        {
            EditionDescription = desc;
        }
        public string ParsedContents()
        {
            var builder = ContentParseBuilder
                .Begin()
                .SetUnparsedContent(Contents)
                .ParseList()
                .ParseLinks()
                .ParseImageUrls();
            return builder.Build();
        }
        /// <summary>
        /// Increase version and sets new awarded xp accordingly
        /// </summary>
        /// <param name="versionUpdate"></param>
        public void IncreaseVersion(Edition.VersionUpdate versionUpdate)
        {
            Version.IncreaseVersion(versionUpdate);
            switch (versionUpdate)
            {
                case VersionUpdate.Major:
                    SetAwardedXp(Convert.ToInt32(AwardedXp * 1.5m));
                    break;
                case VersionUpdate.Minor:
                    SetAwardedXp(Convert.ToInt32(AwardedXp * 1.1m));
                    break;
                default:
                case VersionUpdate.Change:
                    SetAwardedXp(Convert.ToInt32(AwardedXp * 1.01m));
                    break;
            }
        }
    }
}
