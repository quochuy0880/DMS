using DMS.Data.Infrastructure;
using DMS.Model.Models;

namespace DMS.Data.Repositories
{
    public interface IBranchRepository : IRepository<Branch>
    {
    }

    public class BranchRepository : RepositoryBase<Branch>, IBranchRepository
    {
        public BranchRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}