using GicPortal.Business.Manager;
using GicPortal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GicPortal.WebApi.Controllers
{
    [Authorize]
    [RoutePrefix("achievement")]
    public class AchievementController : ApiController
    {
        public IGicBusinessManager gicManager { get; set; }

        public AchievementController()//IUserManager _userManager)
        {
            gicManager = new GicBusinessManager();
        }

        #region EmployeeAchievement
        [HttpGet]
        [Route("get")]
        public List<Achievement> GetAchievements()
        {
            return gicManager.GetAchievements();
        }
        [HttpGet]
        [Route("getachievement/{guid}")]
        public Achievement GetAchievement(Guid guid)
        {
            return gicManager.GetAchievement(guid);
        }
        [HttpPost]
        [Route("save")]
        public void SaveAchievement(Achievement acv)
        {
            gicManager.SaveAchievement(acv);
        }

        [HttpDelete]
        [Route("delete")]
        public void DeleteAchievement(Achievement acv)
        {
            gicManager.DeleteAchievement(acv);
        }
        #endregion
    }
}
