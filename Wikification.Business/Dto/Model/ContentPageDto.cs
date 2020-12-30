using System.Collections.Generic;

namespace Wikification.Business.Dto.Model
{
    public class ContentPageDto
    {
        public BadgeDto Badge { get; set; }
        public ICollection<CategoryDto> Categories { get; set; }
        public string Contents { get; set; }
        public string ParsedContents { get; set; }
        public string Title { get; set; }
        public string Version { get; set; }
    }
}
