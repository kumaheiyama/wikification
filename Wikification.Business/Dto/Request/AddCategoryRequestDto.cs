using Wikification.Business.Dto.Model;

namespace Wikification.Business.Dto.Request
{
    public class AddCategoryRequestDto
    {
        public string Name { get; set; }
        public CreateBadgeRequestDto Badge { get; set; }
        public int AwardedXp { get; set; }
    }
}
