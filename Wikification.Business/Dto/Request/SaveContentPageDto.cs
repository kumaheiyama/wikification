﻿using System.Collections.Generic;

namespace Wikification.Business.Dto.Request
{
    public class SaveContentPageRequestDto
    {
        public int AwardedXp { get; set; }
        public ICollection<AddCategoryRequestDto> Categories { get; set; }
        public string Contents { get; set; }
        public string EditionDescription { get; set; }
        public string ExternalId { get; set; }
        public string SystemExternalId { get; set; }
        public string Title { get; set; }
        public VersionUpdate Version { get; set; }
    }
    public enum VersionUpdate
    {
        Change,
        Minor,
        Major
    }
}
