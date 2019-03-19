using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GicPortal.Data.Repository
{
    public interface IAchievementRepository : IRepository<Achievement>
    {
        void Save(Achievement empAchievement);
    }
    public class AchievementRepository : Repository<Achievement>, IAchievementRepository
    {
        public void Save(Achievement empAchievement)
        {
            try
            {
                var achExist = GetAll().AsQueryable().FirstOrDefault(s => s.AchievementIntId == empAchievement.AchievementIntId);
                if (achExist == null)
                {
                    empAchievement.AchievementGuid = Guid.NewGuid();
                    Add(empAchievement);
                }
                else
                {
                    achExist.EmployeeName = empAchievement.EmployeeName;
                    achExist.Title = empAchievement.Title;
                    achExist.Comment = empAchievement.Comment;

                    Update(achExist);
                }
            }
            catch (DbEntityValidationException e)
            {
                throw e;
            }
        }
    }
}
