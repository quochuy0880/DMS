using DMS.Data.Infrastructure;
using DMS.Model.Models;

namespace DMS.Data.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    { }

    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(IDbFactory dbFactory) : base(dbFactory)
        { }
    }
}