namespace Wikification.Business.Dto.Model
{
    public class CreateBadgeRequestDto
    {
        public int AwardedXp { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string SymbolUrl { get; set; }
    }
}
