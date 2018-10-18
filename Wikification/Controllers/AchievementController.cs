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
        private readonly ILogifier _log;

        public AchievementController(IAchievementBusiness achievementBusiness, ILogifier log)
        {
            _achievementBusiness = achievementBusiness;
            _log = log;
        }

        [HttpGet("[action]")]
        public LevelDto GetAchievedLevel(string externalId, int currentXp)
        {
            _log.LogError("testmeddelande", new Business.Exceptions.SystemNotFoundException("externalid", "nytt meddelande"));

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
