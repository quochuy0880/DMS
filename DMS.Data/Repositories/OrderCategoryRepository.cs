using DMS.Data.Infrastructure;
using DMS.Model.Models;

namespace DMS.Data.Repositories
{
    public interface IOrderCategoryRepository : IRepository<OrderCategory>
    { }

    public class OrderCategoryRepository : RepositoryBase<OrderCategory>, IOrderCategoryRepository
    {
        public OrderCategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        { }
    }
}