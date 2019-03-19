using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GicPortal.Data.Repository
{
    public interface IAdminPoliciesRepository : IRepository<AdminPolicy>
    {
        void Save(AdminPolicy policy);
    }
    public class AdminPoliciesRepository : Repository<AdminPolicy>, IAdminPoliciesRepository
    {
        public void Save(AdminPolicy policy)
        {
            try
            {
                var recExist = GetAll().AsQueryable().FirstOrDefault(s => s.AdminPoliciesIntId == policy.AdminPoliciesIntId);
                if (recExist == null)
                {
                    policy.AdminPoliciesGuid = Guid.NewGuid();
                    Add(policy);
                }
                else
                {
                    recExist.AdminPoliciesName = policy.AdminPoliciesName;
                    recExist.AdminPoliciesDetails = policy.AdminPoliciesDetails;
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
