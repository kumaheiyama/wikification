namespace Wikification.Business.Dto.Request
{
    public class AddCategoryRequestDto
    {
        public int ContentPageId { get; set; }
        public string CategoryName { get; set; }
        public BadgeDto Badge { get; set; }
        public int AwardedXp { get; set; }
    }
}
