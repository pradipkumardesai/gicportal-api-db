using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GicPortal.Data.Repository
{
    public interface ITeamRepository : IRepository<Team>
    {
        void Save(Team team);
    }
    public class TeamRepository : Repository<Team>, ITeamRepository
    {
        public void Save(Team team)
        {
            try
            {
                var recExist = GetAll().AsQueryable().FirstOrDefault(s => s.TeamIntId == team.TeamIntId);
                if (recExist == null)
                {
                    team.TeamGuid = Guid.NewGuid();
                    Add(team);
                }
                else
                {
                    recExist.TeamName = team.TeamName;
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
