﻿using System.Collections.Generic;
using Wikification.Data.Datastructure.Linking;
using Wikification.Data.Interfaces;

namespace Wikification.Data.Datastructure
{
    public class Badge : IAwardedXp, IEntity
    {
        public int AwardedXp { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string SymbolUrl { get; set; }
        public ICollection<UserBadge> Users { get; set; }

        public int CalculatedAwardedXp()
        {
            return AwardedXp;
        }
    }
}
