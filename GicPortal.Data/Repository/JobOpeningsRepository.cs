using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GicPortal.Data.Repository
{
    public interface IJobOpeningsRepository : IRepository<JobOpening>
    {
        void Save(JobOpening job);
    }
    public class JobOpeningsRepository : Repository<JobOpening>, IJobOpeningsRepository
    {
        public void Save(JobOpening job)
        {
            try
            {
                var jobExist = GetAll().AsQueryable().FirstOrDefault(s => s.JobOpeningGuid == job.JobOpeningGuid);
                if (jobExist == null)
                {
                    job.JobOpeningGuid = Guid.NewGuid();
                    Add(job);
                }
                else
                {
                    jobExist.Jobcode = job.Jobcode;
                    jobExist.Skills = job.Skills;
                    jobExist.Experience = job.Experience;
                    jobExist.Designation = job.Designation;

                    Update(jobExist);
                }
            }
            catch (DbEntityValidationException e)
            {
                throw e;
            }
        }
    }
}
