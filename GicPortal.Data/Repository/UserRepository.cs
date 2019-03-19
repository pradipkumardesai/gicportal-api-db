using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using GicPortal.Data.Repository;

namespace GicPortal.Data
{
    public interface IUserRepository : IRepository<User>
    {
        User GetMyProfile(string userName);
        User GetProfileByGuid(Guid guid);
    }
    public class UserRepository : IUserRepository
    {
        UnitOfWork.UnitOfWork uow = new UnitOfWork.UnitOfWork();

        public void CommitChanges()
        {
            uow.Commit();
        }
       
        public IQueryable<User> GetAll()
        {
            return uow.UserRepository.GetAll().AsQueryable<User>();
        }

        public User GetById(long Id)
        {
            return uow.UserRepository.GetAll().FirstOrDefault();
        }

        public User GetMyProfile(string userName)
        {
            return uow.UserRepository.GetAll().AsQueryable().FirstOrDefault(s => s.Name == userName); 
        }
        public User GetProfileByGuid(Guid guid)
        {
            return uow.UserRepository.GetAll().AsQueryable().FirstOrDefault(s => s.UserGuid == guid);
        }

        public void Add(User user)
        {
            try
            {
                var userExist = uow.UserRepository.GetAll().AsQueryable().FirstOrDefault(s => s.UserGuid == user.UserGuid);
                if (userExist == null)
                {
                    uow.UserRepository.Add(user);
                }
                else
                {
                    userExist.UserGuid = user.UserGuid;
                    userExist.EmployeeId = user.EmployeeId;
                    userExist.Name = user.Name;
                    userExist.EmailId = user.EmailId;
                    userExist.SupervisorIntId = user.SupervisorIntId;
                    userExist.Summary = user.Summary;
                    userExist.DateOfBirth = user.DateOfBirth;
                    userExist.DeskNo = user.DeskNo;
                    userExist.Team = user.Team;
                    userExist.About = user.About;
                    userExist.Imagedata = user.Imagedata;
                    userExist.ContactNo = user.ContactNo;

                    uow.UserRepository.Update(userExist);
                    uow.Commit();
                }
            }
            catch (DbEntityValidationException e)
            {
                //throw e;
            }
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<User> GetAll(params Expression<Func<User, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }
    }
}
