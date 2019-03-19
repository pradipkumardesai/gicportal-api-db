using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GicPortal.Data.Repository
{
    public interface IAnnouncementRepository : IRepository<Announcement>
    {
        void Save(Announcement annoucement);
    }
    public class AnnouncementRepository : Repository<Announcement>, IAnnouncementRepository
    {
        public void Save(Announcement annoucement)
        {
            try
            {
                var annoucementExist = GetAll().AsQueryable().FirstOrDefault(s => s.AnnouncementIntId == annoucement.AnnouncementIntId);
                if (annoucementExist == null)
                {
                    annoucement.AnnouncementGuid = Guid.NewGuid();
                    Add(annoucement);
                }
                else
                {
                    annoucementExist.Description = annoucement.Description;
                    annoucementExist.Expiry = annoucement.Expiry;
                    annoucementExist.Title = annoucement.Title;

                    Update(annoucementExist);
                }
            }
            catch (DbEntityValidationException e)
            {
                throw e;
            }
        }
    }
}
