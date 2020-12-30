using Microsoft.AspNetCore.Mvc;
using Wikification.Business.Dto.Model;
using Wikification.Business.Dto.Request;
using Wikification.Business.Interfaces;
using Wikification.Data.Interfaces;

namespace Wikification.Controllers
{
    [Route("api/[controller]")]
    public class AchievementController : Controller
    {
        private readonly IAchievementBusiness _achievementBusiness;

        public AchievementController(IAchievementBusiness achievementBusiness)
        {
            _achievementBusiness = achievementBusiness;
        }

        [HttpGet("[action]")]
        public AchievedLevelResponseDto GetAchievedLevel(string externalId, int currentXp)
        {
            return _achievementBusiness.GetAchievedLevel(externalId, currentXp);
        }

        [HttpPost("[action]")]
        public void AddLevel([FromBody] AddLevelRequestDto request)
        {
            _achievementBusiness.AddLevel(request);
        }

        [HttpPost("[action]")]
        public void RemoveLevel([FromBody] RemoveLevelRequestDto request)
        {
            _achievementBusiness.RemoveLevel(request);
        }
    }
}
