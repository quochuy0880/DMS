using DMS.Data.Infrastructure;
using DMS.Model.Models;

namespace DMS.Data.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    { }

    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(IDbFactory dbFactory) : base(dbFactory)
        { }
    }
}