namespace Wikification.Business.Dto.Request
{
    public class AddLevelRequestDto
    {
        public string Name { get; set; }
        public int XpThreshold { get; set; }
        public string SystemExternalId { get; set; }
    }
}
