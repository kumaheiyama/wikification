namespace Wikification.Business.Dto.Model
{
    public class CreateBadgeRequestDto
    {
        public string Name { get; set; }
        public string SymbolUrl { get; set; }
        public string Description { get; set; }
        public int AwardedXp { get; set; }
    }
}
