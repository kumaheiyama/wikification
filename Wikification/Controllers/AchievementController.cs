using Microsoft.AspNetCore.Mvc;
using Wikification.Business.Dto.Model;
using Wikification.Business.Interfaces;

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
        public LevelDto GetAchievedLevel(string externalId, int currentXp)
        {
            return _achievementBusiness.GetAchievedLevel(externalId, currentXp);
        }
    }
}
