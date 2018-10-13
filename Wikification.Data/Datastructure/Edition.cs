﻿using System;
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
        public Edition(EditionVersion version) : this()
        {
            Version = version;
        }

        //Properties
        public int AwardedXp { get; set; }
        public string Contents { get; set; }
        public long DateCreated { get; set; }
        public string EditionDescription { get; set; }
        public int Id { get; set; }
        public EditionVersion Version { get; private set; }

        //Methods
        public int CalculatedAwardedXp()
        {
            return AwardedXp;
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
    }
}
