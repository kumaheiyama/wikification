using Wikification.Business.Dto.Model;

namespace Wikification.Business.Dto.Request
{
    public class AchievedLevelResponseDto
    {
        public LevelDto CurrentLevel { get; set; }
        public LevelDto NextLevel { get; set; }
    }
}
