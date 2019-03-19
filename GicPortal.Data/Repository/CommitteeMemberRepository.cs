using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GicPortal.Data.Repository
{
    public interface ICommitteeMemberRepository : IRepository<CommitteeMember>
    {
        void Save(CommitteeMember commiteeMember);
    }
    public class CommitteeMemberRepository : Repository<CommitteeMember>, ICommitteeMemberRepository
    {
        public void Save(CommitteeMember commiteeMember)
        {
            try
            {
                var cmtExist = GetAll().AsQueryable().FirstOrDefault(s => s.CommitteeMemberIntId == commiteeMember.CommitteeMemberIntId);
                if (cmtExist == null)
                {
                    commiteeMember.CommitteeMemberGuid = new Guid();
                    Add(commiteeMember);
                }
                else
                {
                    cmtExist.CommiteeIntId = commiteeMember.CommiteeIntId;
                    cmtExist.CommitteeMemberIntId = commiteeMember.CommitteeMemberIntId;

                    Update(cmtExist);
                }
            }
            catch (DbEntityValidationException e)
            {
                throw e;
            }
        }
    }

}
