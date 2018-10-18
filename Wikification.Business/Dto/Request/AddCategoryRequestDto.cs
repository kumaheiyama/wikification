using Wikification.Business.Dto.Model;

namespace Wikification.Business.Dto.Request
{
    public class AddCategoryRequestDto
    {
        public int AwardedXp { get; set; }
        public AddBadgeRequestDto Badge { get; set; }
        public string Name { get; set; }
        public string SystemExternalId { get; set; }
    }
}
