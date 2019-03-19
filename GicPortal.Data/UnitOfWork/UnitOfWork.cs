using GicPortal.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GicPortal.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();
    }

    public sealed class UnitOfWork : IUnitOfWork
    {

        private GicDbEntities _dbContext;

        private IRepository<User> _userRepository = null;

        public IRepository<User> UserRepository
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new Repository<User>();
                return _userRepository;
            }
        }

        public GicDbEntities Context { get { return _dbContext; } }

        public UnitOfWork()
        {
            _dbContext = new GicDbEntities();
        }

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_dbContext != null)
                {
                    _dbContext.Dispose();
                    _dbContext = null;
                }
            }
        }
    }
}
