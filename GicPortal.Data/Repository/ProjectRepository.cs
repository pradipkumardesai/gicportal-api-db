using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GicPortal.Data.Repository
{
    public interface IProjectRepository : IRepository<Project>
    {
        void Save(Project project);
    }
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public void Save(Project project)
        {
            try
            {
                var recExist = GetAll().AsQueryable().FirstOrDefault(s => s.ProjectIntId == project.ProjectIntId);
                if (recExist == null)
                {
                    project.ProjectGuid = Guid.NewGuid();
                    Add(project);
                }
                else
                {
                    recExist.Description = project.Description;
                    recExist.Title = project.Title;

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
