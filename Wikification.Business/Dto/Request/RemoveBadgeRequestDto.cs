using System;
using System.Collections.Generic;
using System.Text;

namespace Wikification.Business.Dto.Request
{
    public class RemoveBadgeRequestDto
    {
        public int BadgeId { get; set; }
        public string SystemExternalId { get; set; }
    }
}
