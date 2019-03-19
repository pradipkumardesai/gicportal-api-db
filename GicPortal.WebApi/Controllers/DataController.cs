using GicPortal.Business.Manager;
using GicPortal.Business.Models;
using GicPortal.Data;
using GicPortal.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace GicPortal.WebApi.Controllers
{
    [Authorize]
    [RoutePrefix("data")]
    public class DataController : ApiController
    {
        public IUserManager userManager { get; set; }
        public IGicBusinessManager gicManager { get; set; }
        public DataController()//IUserManager _userManager)
        {
            //userManager = _userManager;
            userManager = new UserManager();
            gicManager = new GicBusinessManager();
        }
        [HttpPost]
        [Route("save")]
        public IHttpActionResult Save(PostData data)
        {
            User user = new User()
            {
                Name = User.Identity.Name,
                Designation = data.DeskNo,
                DeskNo = data.DeskNo,
                EmailId = data.EMailId,
                EmployeeId = data.EmployeeId
            };
            userManager.AddUser(user);
            if (User.Identity.IsAuthenticated)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Not authenticated");
            }
        }

        [HttpGet]
        [Route("GetNewJoiness")]
        public List<User> GetNewJoiness()
        {
            return gicManager.GetNewJoinees();
        }

        [HttpGet]
        [Route("GetBirthdaysThisMonth")]
        public List<User> GetBirthdaysThisMonth()
        {
            return gicManager.GetBirthdaysThisMonth();
        }

        [HttpGet]
        [Route("GetAllEmployee")]
        public List<User> GetAllEmployee()
        {
            return gicManager.GetAllEmployee();
        }

        [HttpGet]
        [Route("GetMyProfile")]
        public User GetMyProfile()
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
            //var EMailId =  userPrincipal.DisplayName;

            #endregion

            #region HomeNetwork
            string EMailId = "Prashant Sutar"; //userPrincipal.EmailAddress,
            #endregion
            var user = gicManager.GetMyProfile(EMailId);
            return user;
        }
        [HttpGet]
        [Route("get/{guid}")]
        public User GetProfileByGuid(Guid guid)
        {
            var user = gicManager.GetProfileByGuid(guid);
            return user;
        }
        [HttpGet]
        [Route("GetLookupData")]
        public LookupDataModel GetLookupData()
        {
            return gicManager.GetLookupData();
        }



        #region Holiday
        [HttpGet]
        [Route("GetHolidays")]
        public List<Holiday> GetHolidays()
        {
            return gicManager.GetHolidays();
        }

        [HttpPost]
        [Route("SaveHoliday")]
        public void SaveHoliday(Holiday holiday)
        {
            gicManager.SaveHolidays(holiday);
        }

        [HttpDelete]
        [Route("DeleteHoliday")]
        public void DeleteHoliday(Holiday holiday)
        {
            gicManager.DeleteHolidays(holiday);
        }
        #endregion

        #region Teams
        [HttpGet]
        [Route("GetTeams")]
        public List<Team> GetTeams()
        {
            return gicManager.GetTeams();
        }

        [HttpPost]
        [Route("SaveTeam")]
        public void SaveTeam(Team team)
        {
            gicManager.SaveTeam(team);
        }

        [HttpDelete]
        [Route("DeleteTeam")]
        public void DeleteTeam(Team team)
        {
            gicManager.DeleteTeam(team);
        }
        #endregion


        #region Project
        [HttpGet]
        [Route("GetProjects")]
        public List<Project> GetProjects()
        {
            return gicManager.GetProjects();
        }

        [HttpPost]
        [Route("SaveProject")]
        public void SaveProject(Project project)
        {
            gicManager.SaveProject(project);
        }

        [HttpDelete]
        [Route("DeleteProject")]
        public void DeleteProject(Project project)
        {
            gicManager.DeleteProject(project);
        }
        #endregion



        #region WkAnnouncement
        [HttpGet]
        [Route("GetWkAnnouncements")]
        public List<Announcement> GetWkAnnouncements()
        {
            return gicManager.GetWkAnnouncements();
        }

        [HttpPost]
        [Route("SaveWkAnnouncement")]
        public void SaveWkAnnouncement(Announcement acv)
        {
            gicManager.SaveWkAnnouncement(acv);
        }

        [HttpDelete]
        [Route("DeleteWkAnnouncement")]
        public void DeleteWkAnnouncement(Announcement acv)
        {
            gicManager.DeleteWkAnnouncement(acv);
        }
        #endregion

    }
}
