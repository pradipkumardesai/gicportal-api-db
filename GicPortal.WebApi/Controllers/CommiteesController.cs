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
    [RoutePrefix("commitees")]
    public class CommiteesController : ApiController
    {
        public IUserManager userManager { get; set; }
        public IGicBusinessManager gicManager { get; set; }
        public CommiteesController()
        {
            //userManager = _userManager;
            userManager = new UserManager();
            gicManager = new GicBusinessManager();
        }

        #region Committee
        [HttpGet]
        [Route("GetCommiteess")]
        public List<Committee> GetCommiteess()
        {
            return gicManager.GetCommiteess();
        }

        [HttpGet]
        [Route("GetCommiteeByName/{name}")]
        public Committee GetCommiteeByName(string name)
        {
            return gicManager.GetCommiteeByName(name);
        }
        [HttpPost]
        [Route("SaveCommitee")]
        public void SaveCommitee(Committee committee)
        {
            gicManager.SaveCommitee(committee);
        }

        [HttpDelete]
        [Route("DeleteCommitee")]
        public void DeleteCommitee(Committee committee)
        {
            gicManager.DeleteCommitee(committee);
        }
        #endregion

        #region CommitteeEvent
        [HttpGet]
        [Route("GetCommiteeEvent")]
        public List<CommitteeEvent> GetCommiteeEvent()
        {
            return gicManager.GetCommiteeEvent();
        }

        [HttpPost]
        [Route("SaveCommiteeEvent")]
        public void SaveCommitee(CommitteeEvent committeeEvent)
        {
            gicManager.SaveCommiteeEvent(committeeEvent);
        }

        [HttpDelete]
        [Route("DeleteCommiteeEvent")]
        public void DeleteCommiteeEvent(CommitteeEvent committeeEvent)
        {
            gicManager.DeleteCommiteeEvent(committeeEvent);
        }
        #endregion

        #region CommitteeMember
        [HttpGet]
        [Route("GetCommitteeMembers")]
        public List<CommitteeMember> GetCommitteeMembers()
        {
            return gicManager.GetCommitteeMembers();
        }

        [HttpPost]
        [Route("SaveCommitteeMember")]
        public void SaveCommitteeMember(CommitteeMember member)
        {
            gicManager.SaveCommitteeMember(member);
        }

        [HttpDelete]
        [Route("DeleteCommitteeMember")]
        public void DeleteCommitteeMember(CommitteeMember member)
        {
            gicManager.DeleteCommitteeMember(member);
        }
        #endregion
    }
}
