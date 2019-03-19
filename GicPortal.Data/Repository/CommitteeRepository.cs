using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GicPortal.Data.Repository
{
    public interface ICommitteeRepository : IRepository<Committee>
    {
        void Save(Committee commitee);
    }
    public class CommitteeRepository : Repository<Committee>, ICommitteeRepository
    {
        public void Save(Committee commitee)
        {
            try
            {
                var recExist = GetAll().AsQueryable().FirstOrDefault(s => s.CommiteeIntId == commitee.CommiteeIntId);
                if (recExist == null)
                    Add(commitee);
                else
                {
                    recExist.CommiteeName = commitee.CommiteeName;
                    recExist.CommitteeDetails = commitee.CommitteeDetails;
                    recExist.CommitteeEvents = commitee.CommitteeEvents;
                    recExist.CommitteeMembers = commitee.CommitteeMembers;

                    Update(recExist);
                }
            }
            catch (DbEntityValidationException e)
            {
                throw e;
            }
        }
    }
}
