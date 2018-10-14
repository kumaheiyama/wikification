using System.Collections.Generic;

namespace Wikification.Business.Dto.Model
{
    public class ContentPageDto
    {
        public string Title { get; set; }
        public string Contents { get; set; }
        public ICollection<EditionDto> Editions { get; set; }
        public ICollection<CategoryDto> Categories { get; set; }
        public BadgeDto Badge { get; set; }
        public string Version { get; set; }
    }
}
