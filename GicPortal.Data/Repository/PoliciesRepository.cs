using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GicPortal.Data.Repository
{
    public interface IPoliciesRepository : IRepository<PoliciesProcedure>
    {
        void Save(PoliciesProcedure project);
    }
    public class PoliciesRepository : Repository<PoliciesProcedure>, IPoliciesRepository
    {
        public void Save(PoliciesProcedure policy)
        {
            try
            {
                var policyrExist = GetAll().AsQueryable().FirstOrDefault(s => s.PoliciesProcedureIntId == policy.PoliciesProcedureIntId);
                policy.LastModifiedDate = DateTime.Now;
                if (policyrExist == null)
                {
                    policy.PoliciesProcedureGuid = Guid.NewGuid();
                    Add(policy);
                }
                else
                {
                    policyrExist.PoliciesProcedureName = policy.PoliciesProcedureName;
                    policyrExist.PoliciesProcedureDetails = policy.PoliciesProcedureDetails;
                    policyrExist.PoliciesFullDetails = policy.PoliciesFullDetails;
                    policyrExist.LastModifiedDate= policy.LastModifiedDate;

                    Update(policyrExist);
                }
            }
            catch (DbEntityValidationException e)
            {
                throw e;
            }
        }
    }
}
