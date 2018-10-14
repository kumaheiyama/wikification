using System;
using System.Collections.Generic;
using System.Text;

namespace Wikification.Business.Dto.Request
{
    public class AddBadgeRequestDto
    {
        public int AwardedXp { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string SymbolUrl { get; set; }
    }
}
