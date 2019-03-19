using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GicPortal.Data;

namespace GicPortal.Business.Manager
{
    public interface IUserManager
    {
        void AddUser(User user);
    }
    public class UserManager : IUserManager
    {
        public IUserRepository userRepo { get; set; }
        public UserManager()//IUserRepository _userRepo)
        {
            //userRepo = _userRepo;
            userRepo = new UserRepository();
        }
        public void AddUser(User user)
        {
            userRepo.Add(user);
        }
    }
}
