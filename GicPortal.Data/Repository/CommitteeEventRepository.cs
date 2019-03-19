using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GicPortal.Data.Repository
{
    public interface ICommitteeEventRepository : IRepository<CommitteeEvent>
    {
        void Save(CommitteeEvent cEvent);
    }
    public class CommitteeEventRepository : Repository<CommitteeEvent>, ICommitteeEventRepository
    {

        public void Save(CommitteeEvent cEvent)
        {
            try
            {
                var evntExist = GetAll().AsQueryable().FirstOrDefault(s => s.EventIntId == cEvent.EventIntId);
                if (evntExist == null)
                    Add(cEvent);
                else
                {
                    evntExist.Committee = cEvent.Committee;
                    evntExist.EventDescription = cEvent.EventDescription;
                    evntExist.EventName = cEvent.EventName;

                    Update(evntExist);
                }
            }
            catch (DbEntityValidationException e)
            {
                throw e;
            }
        }
    }

}
