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
    [RoutePrefix("policy")]
    public class PolicyController : ApiController
    {

        public IGicBusinessManager gicMngr { get; set; }
        public PolicyController()//IUserRepository _userRepo)
        {
            gicMngr = new GicBusinessManager();
        }


        #region Annoucement
        [HttpPost]
        [Route("save")]
        public void Save(PoliciesProcedure policy)
        {
            gicMngr.SavePoliciesProcedure(policy);
        }

        [HttpDelete]
        [Route("delete")]
        public void DeletePoliciesProcedure(PoliciesProcedure policy)
        {
            gicMngr.DeletePoliciesProcedure(policy);
        }

        [HttpGet]
        [Route("get")]
        public List<PoliciesProcedure> GetPoliciesProcedure()
        {
            return gicMngr.GetPoliciesProcedure().ToList();
        }

        [HttpGet]
        [Route("getdetails/{guid}")]
        public PoliciesProcedure GetPoliciesProcedure(Guid guid)
        {
            return gicMngr.GetPoliciesProcedure(guid);
        }
        #endregion

        #region Admin Policies
        [HttpPost]
        [Route("saveadminpolicies")]
        public void SaveAdminPolicies(AdminPolicy policy)
        {
            gicMngr.SaveAdminPolicies(policy);
        }

        [HttpDelete]
        [Route("deleteadminpolicies")]
        public void DeleteAdminPolicy(AdminPolicy policy)
        {
            gicMngr.DeleteAdminPolicy(policy);
        }

        [HttpGet]
        [Route("getadminpolicies")]
        public List<AdminPolicy> GetAdminPolicies()
        {
            return gicMngr.GetAdminPolicies().ToList();
        }

        [HttpGet]
        [Route("getadminpoliciesdetails/{guid}")]
        public AdminPolicy GetAdminPolicy(Guid guid)
        {
            return gicMngr.GetAdminPolicy(guid);
        }
        #endregion

        #region Admin Policies
        [HttpPost]
        [Route("saveitpolicies")]
        public void SaveITPolicies(ITPolicy policy)
        {
            gicMngr.SaveITPolicies(policy);
        }

        [HttpDelete]
        [Route("deleteitpolicies")]
        public void DeleteITPolicy(ITPolicy policy)
        {
            gicMngr.DeleteITPolicy(policy);
        }

        [HttpGet]
        [Route("getitpolicies")]
        public List<ITPolicy> GetITPolicies()
        {
            return gicMngr.GetITPolicies().ToList();
        }

        [HttpGet]
        [Route("getitpoliciesdetails/{guid}")]
        public ITPolicy GetITPolicy(Guid guid)
        {
            return gicMngr.GetITPolicy(guid);
        }
        #endregion
    }
}
