using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GicPortal.Data.Repository
{
    public interface IHolidaysRepository : IRepository<Holiday>
    {
        void Save(Holiday job);
    }
    public class HolidaysRepository : Repository<Holiday>, IHolidaysRepository
    {
        public void Save(Holiday holiday)
        {
            try
            {
                var recExist = GetAll().AsQueryable().FirstOrDefault(s => s.HolidayId == holiday.HolidayId);
                if (recExist == null)
                {
                    // holiday. = Guid.NewGuid();
                    Add(holiday);
                }
                else
                {
                    recExist.HolidayDate = holiday.HolidayDate;
                    recExist.HolidayDay = holiday.HolidayDay;
                    recExist.Occasion = holiday.Occasion;
                    recExist.Optional = holiday.Optional;

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
