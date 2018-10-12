using System.Collections.Generic;

namespace Wikification.Business
{
    public class ContentPageDto
    {
        public string Title { get; set; }
        public string Contents { get; set; }
        public ICollection<EditionDto> Editions { get; set; }
        public ICollection<CategoryDto> Categories { get; set; }
        public ICollection<BadgeDto> Badges { get; set; }
        public string Version { get; set; }
    }
}
