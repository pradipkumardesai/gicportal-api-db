using GicPortal.Business.Manager;
using GicPortal.Data;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Cors;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security;


namespace GicPortal.WebApi.Controllers
{
    [Authorize]
    [RoutePrefix("user")]

    public class UserController : ApiController
    {
        public IUserManager userManager { get; set; }
        public IGicBusinessManager gicManager { get; set; }
        public UserController()//IUserManager _userManager)
        {
            //userManager = _userManager;
            gicManager = new GicBusinessManager();
            userManager = new UserManager();
        }
        [HttpGet]
        [Route("getuser")]
        public string GetUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                #region Ofc Network
                //UserPrincipal userPrincipal;
                //WindowsPrincipal principal = (WindowsPrincipal)User;
                //using (PrincipalContext pc = new PrincipalContext(ContextType.Domain))
                //{
                //    userPrincipal = (UserPrincipal)Principal.FindByIdentity(pc, principal.Identity.Name);
                //}
                //User user = new User()
                //{
                //    Name = userPrincipal.DisplayName,
                //    EMailId = userPrincipal.EmailAddress,
                //};
                //userManager.AddUser(user);
                //return userPrincipal.DisplayName;

                #endregion

                #region HomeNetwork
                User user = new User()
                {
                    UserGuid = new Guid(),
                    Name = "Prashant Sutar",//userPrincipal.DisplayName,
                    EmailId = "prashant.sutar@wolterskluwer.com", //userPrincipal.EmailAddress,
                };
                #endregion
                userManager.AddUser(user);
                return "Prashant Sutar";
            }
            else
            {
                return "Not authenticated";
            }
        }

        [HttpPost]
        [Route("save")]
        public IHttpActionResult Save(User data)
        {
            
            userManager.AddUser(data);
            if (User.Identity.IsAuthenticated)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Not authenticated");
            }
        }
    }
}
