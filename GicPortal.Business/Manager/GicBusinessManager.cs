using GicPortal.Business.Models;
using GicPortal.Data;
using GicPortal.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GicPortal.Business.Manager
{
    public interface IGicBusinessManager
    {
        #region Job Openings
        void SaveJobOpening(JobOpening job);
        void DeleteJobOpening(JobOpening job);
        List<JobOpening> GetJobOpening();
        #endregion

        #region User
        List<User> GetAllEmployee();
        User GetMyProfile(string userName);
        User GetProfileByGuid(Guid guid);
        List<User> GetBirthdaysThisMonth();
        List<User> GetNewJoinees();
        #endregion

        #region Holidays
        void SaveHolidays(Holiday holiday);
        void DeleteHolidays(Holiday holiday);
        List<Holiday> GetHolidays();
        #endregion

        LookupDataModel GetLookupData();

        #region Team
        void SaveTeam(Team team);
        void DeleteTeam(Team team);
        List<Team> GetTeams();

        #endregion


        #region Commitee
        void SaveCommitee(Committee commitee);
        void DeleteCommitee(Committee commitee);
        List<Committee> GetCommiteess();
        Committee GetCommiteeByName(string name);
        #endregion

        #region Event 
        void SaveCommiteeEvent(CommitteeEvent commitee);
        void DeleteCommiteeEvent(CommitteeEvent commitee);
        List<CommitteeEvent> GetCommiteeEvent();

        #endregion

        #region CommiteeMember
        void SaveCommitteeMember(CommitteeMember commitee);
        void DeleteCommitteeMember(CommitteeMember commitee);
        List<CommitteeMember> GetCommitteeMembers();

        #endregion

        #region Project
        void SaveProject(Project project);
        void DeleteProject(Project project);
        List<Project> GetProjects();

        #endregion

        #region Annoucement
        void SaveWkAnnouncement(Announcement annoucement);
        void DeleteWkAnnouncement(Announcement annoucement);
        List<Announcement> GetWkAnnouncements();

        #endregion

        #region Achievement
        void SaveAchievement(Achievement annoucement);
        void DeleteAchievement(Achievement annoucement);
        List<Achievement> GetAchievements();
        Achievement GetAchievement(Guid guid);

        #endregion

        #region Achievement
        void SavePoliciesProcedure(PoliciesProcedure policy);
        void DeletePoliciesProcedure(PoliciesProcedure policy);
        List<PoliciesProcedure> GetPoliciesProcedure();
        PoliciesProcedure GetPoliciesProcedure(Guid guid);
        #endregion

        #region IT PoliciesProcedure
        void SaveITPolicies(ITPolicy policy);
        void DeleteITPolicy(ITPolicy policy);
        List<ITPolicy> GetITPolicies();
        ITPolicy GetITPolicy(Guid guid);
        #endregion

        #region Admin PoliciesProcedure
        void SaveAdminPolicies(AdminPolicy policy);
        void DeleteAdminPolicy(AdminPolicy policy);
        List<AdminPolicy> GetAdminPolicies();
        AdminPolicy GetAdminPolicy(Guid guid);
        #endregion
    }
    public class GicBusinessManager : IGicBusinessManager
    {

        public IUserRepository userRepo { get; set; }
        public IHolidaysRepository holidayRepo { get; set; }
        public IJobOpeningsRepository jobRepo { get; set; }
        public ITeamRepository teamRepo { get; set; }
        public ICommitteeRepository commiteeRepo { get; set; }
        public ICommitteeEventRepository eventRepo { get; set; }
        public ICommitteeMemberRepository memberRepo { get; set; }
        public IProjectRepository projectRepo { get; set; }
        public IAnnouncementRepository accouncementRepo { get; set; }
        public IAchievementRepository achivementRepo { get; set; }
        public IPoliciesRepository policiesRepo { get; set; }
        public IITPoliciesRepository itPoliciesRepo { get; set; }
        public IAdminPoliciesRepository adminPoliciesRepo { get; set; }

        public GicBusinessManager()//IUserRepository _userRepo)
        {
            userRepo = new UserRepository();
            holidayRepo = new HolidaysRepository();
            jobRepo = new JobOpeningsRepository();
            teamRepo = new TeamRepository();
            commiteeRepo = new CommitteeRepository();
            eventRepo = new CommitteeEventRepository();
            memberRepo = new CommitteeMemberRepository();
            projectRepo = new ProjectRepository();
            accouncementRepo = new AnnouncementRepository();
            achivementRepo = new AchievementRepository();
            policiesRepo = new PoliciesRepository();
            itPoliciesRepo = new ITPoliciesRepository();
            adminPoliciesRepo = new AdminPoliciesRepository();
        }

        #region Job Openings
        public void SaveJobOpening(JobOpening job)
        {
            jobRepo.Save(job);
        }
        public void DeleteJobOpening(JobOpening job)
        {
            jobRepo.Delete(job);
        }
        public List<JobOpening> GetJobOpening()
        {
            return jobRepo.GetAll().ToList();
        }
        #endregion

        #region User
        public List<User> GetBirthdaysThisMonth()
        {
            var result = userRepo.GetAll().Where(w => w.DateOfBirth.Month == DateTime.Now.Month);
            return result.ToList();
        }
        public List<User> GetNewJoinees()
        {
            var result = userRepo.GetAll().Where(w => w.JoiningDate.Year == DateTime.Now.Year && w.JoiningDate.Month == DateTime.Now.Month);
            return result.ToList();
        }
        public List<User> GetAllEmployee()
        {
            return userRepo.GetAll().ToList();
        }
        public User GetMyProfile(string userName)
        {
            return userRepo.GetMyProfile(userName);
        }
        public User GetProfileByGuid(Guid guid)
        {
            return userRepo.GetProfileByGuid(guid);
        }
        #endregion

        #region Holiday
        public void SaveHolidays(Holiday holiday)
        {
            holidayRepo.Save(holiday);
        }
        public void DeleteHolidays(Holiday holiday)
        {
            holidayRepo.Delete(holiday);
        }
        public List<Holiday> GetHolidays()
        {
            return holidayRepo.GetAll().ToList();
        }
        #endregion

        #region LookupData
        public LookupDataModel GetLookupData()
        {
            var res = new LookupDataModel
            {
                Teams = (from list in teamRepo.GetAll()
                         select new TeamModel
                         {
                             Team = list.TeamName,
                             TeamIntId = list.TeamIntId,
                         }).ToList(),
                Supervisor = (from list in userRepo.GetAll()
                              select new SupervisorModel
                              {
                                  SupervisorName = list.Name,
                                  SupervisorIntId = list.UserIntId,
                              }).ToList()
            };


            return res;
        }
        #endregion

        #region Team
        public void SaveTeam(Team team)
        {
            teamRepo.Save(team);
        }
        public void DeleteTeam(Team team)
        {
            teamRepo.Delete(team);
        }
        public List<Team> GetTeams()
        {
            return teamRepo.GetAll().ToList();
        }

        #endregion

        #region Commitee
        public void SaveCommitee(Committee commitee)
        {
            commiteeRepo.Save(commitee);
        }
        public void DeleteCommitee(Committee commitee)
        {
            commiteeRepo.Delete(commitee);
        }
        public List<Committee> GetCommiteess()
        {
            return commiteeRepo.GetAll().ToList();
        }
        public Committee GetCommiteeByName(string name)
        {
            return commiteeRepo.GetAll().FirstOrDefault(n => n.CommiteeName == name);
        }
        #endregion

        #region Event 
        public void SaveCommiteeEvent(CommitteeEvent commitee)
        {
            eventRepo.Save(commitee);
        }
        public void DeleteCommiteeEvent(CommitteeEvent commitee)
        {
            eventRepo.Delete(commitee);
        }
        public List<CommitteeEvent> GetCommiteeEvent()
        {
            return eventRepo.GetAll().ToList();
        }

        #endregion

        #region CommiteeMember
        public void SaveCommitteeMember(CommitteeMember commitee)
        {
            memberRepo.Save(commitee);
        }
        public void DeleteCommitteeMember(CommitteeMember commitee)
        {
            memberRepo.Delete(commitee);
        }
        public List<CommitteeMember> GetCommitteeMembers()
        {
            return memberRepo.GetAll().ToList();
        }

        #endregion

        #region Project
        public void SaveProject(Project project)
        {
            projectRepo.Save(project);
        }
        public void DeleteProject(Project project)
        {
            projectRepo.Delete(project);
        }
        public List<Project> GetProjects()
        {
            return projectRepo.GetAll().ToList();
        }

        #endregion

        #region Annoucement
        public void SaveWkAnnouncement(Announcement annoucement)
        {
            accouncementRepo.Save(annoucement);
        }
        public void DeleteWkAnnouncement(Announcement annoucement)
        {
            accouncementRepo.Delete(annoucement);
        }
        public List<Announcement> GetWkAnnouncements()
        {
            return accouncementRepo.GetAll().ToList();
        }

        #endregion

        #region Achievement
        public void SaveAchievement(Achievement annoucement)
        {
            achivementRepo.Save(annoucement);
        }
        public void DeleteAchievement(Achievement annoucement)
        {
            achivementRepo.Delete(annoucement);
        }
        public List<Achievement> GetAchievements()
        {
            return achivementRepo.GetAll().ToList();
        }
        public Achievement GetAchievement(Guid guid)
        {
            return achivementRepo.GetAll().FirstOrDefault(w => w.AchievementGuid == guid);
        }
        #endregion

        #region PoliciesProcedure
        public void SavePoliciesProcedure(PoliciesProcedure policy)
        {
            policiesRepo.Save(policy);
        }
        public void DeletePoliciesProcedure(PoliciesProcedure policy)
        {
            policiesRepo.Delete(policy);
        }
        public List<PoliciesProcedure> GetPoliciesProcedure()
        {
            return policiesRepo.GetAll().ToList();
        }
        public PoliciesProcedure GetPoliciesProcedure(Guid guid)
        {
            return policiesRepo.GetAll().FirstOrDefault(w => w.PoliciesProcedureGuid == guid);
        }
        #endregion

        #region PoliciesProcedure
        public void SaveITPolicies(ITPolicy policy)
        {
            itPoliciesRepo.Save(policy);
        }
        public void DeleteITPolicy(ITPolicy policy)
        {
            itPoliciesRepo.Delete(policy);
        }
        public List<ITPolicy> GetITPolicies()
        {
            return itPoliciesRepo.GetAll().ToList();
        }
        public ITPolicy GetITPolicy(Guid guid)
        {
            return itPoliciesRepo.GetAll().FirstOrDefault(w => w.ITPoliciesGuid == guid);
        }
        #endregion

        #region PoliciesProcedure
        public void SaveAdminPolicies(AdminPolicy policy)
        {
            adminPoliciesRepo.Save(policy);
        }
        public void DeleteAdminPolicy(AdminPolicy policy)
        {
            adminPoliciesRepo.Delete(policy);
        }
        public List<AdminPolicy> GetAdminPolicies()
        {
            return adminPoliciesRepo.GetAll().ToList();
        }
        public AdminPolicy GetAdminPolicy(Guid guid)
        {
            return adminPoliciesRepo.GetAll().FirstOrDefault(w => w.AdminPoliciesGuid == guid);
        }
        #endregion
    }
}
