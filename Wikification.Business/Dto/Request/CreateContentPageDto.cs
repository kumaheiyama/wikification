using System.Collections.Generic;

namespace Wikification.Business.Dto.Request
{
    public class AddContentPageRequestDto
    {
        public int AwardedXp { get; set; }
        public ICollection<AddCategoryRequestDto> Categories { get; set; }
        public string Contents { get; set; }
        public string SystemExternalId { get; set; }
        public string Title { get; set; }
    }
}
