namespace Wikification.Business.Dto.Request
{
    public class RemoveCategoryRequestDto
    {
        public string ContentPageExternalId { get; set; }
        public string CategoryName { get; set; }
        public string SystemExternalId { get; set; }
    }
}
