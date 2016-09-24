using DMS.Data.Infrastructure;
using DMS.Model.Models;

namespace DMS.Data.Repositories
{
    public interface IUnitProductRepository : IRepository<UnitProduct>
    {
    }

    public class UnitProductRepository : RepositoryBase<UnitProduct>, IUnitProductRepository
    {
        public UnitProductRepository(IDbFactory dbFactory) : base(dbFactory)
        { }
    }
}