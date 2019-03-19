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
    [RoutePrefix("job")]
    public class JobsController : ApiController
    {
        public IUserManager userManager { get; set; }
        public IGicBusinessManager gicManager { get; set; }
        public JobsController()//IUserManager _userManager)
        {
            //userManager = _userManager;
            userManager = new UserManager();
            gicManager = new GicBusinessManager();
        }
        #region JobOpenings
        [HttpGet]
        [Route("get")]
        public List<JobOpening> GetJobOpening()
        {
            return gicManager.GetJobOpening();
        }

        [HttpPost]
        [Route("save")]
        public void SaveJobOpening(JobOpening job)
        {
            gicManager.SaveJobOpening(job);
        }

        [HttpDelete]
        [Route("delete")]
        public void DeleteJobOpening(JobOpening job)
        {
            gicManager.DeleteJobOpening(job);
        }
        #endregion
    }
}
