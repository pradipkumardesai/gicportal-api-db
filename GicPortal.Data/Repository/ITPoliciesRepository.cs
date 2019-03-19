using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GicPortal.Data.Repository
{
    public interface IITPoliciesRepository : IRepository<ITPolicy>
    {
        void Save(ITPolicy policy);
    }
    public class ITPoliciesRepository : Repository<ITPolicy>, IITPoliciesRepository
    {
        public void Save(ITPolicy policy)
        {
            try
            {
                var recExist = GetAll().AsQueryable().FirstOrDefault(s => s.ITPoliciesIntId == policy.ITPoliciesIntId);
                if (recExist == null)
                {
                    policy.ITPoliciesGuid = Guid.NewGuid();
                    Add(policy);
                }
                else
                {
                    recExist.ITPoliciesName = policy.ITPoliciesName;
                    recExist.ITPoliciesDetails = policy.ITPoliciesDetails;
                    recExist.PoliciesFullDetails = policy.PoliciesFullDetails;
                    recExist.LastModifiedDate = policy.LastModifiedDate;

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
