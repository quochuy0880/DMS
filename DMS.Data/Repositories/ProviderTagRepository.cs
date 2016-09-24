using DMS.Data.Infrastructure;
using DMS.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Data.Repositories
{
    public interface IProviderTagRepository : IRepository<ProviderTag>
    { }
    public class ProviderTagRepository:RepositoryBase<ProviderTag>, IProviderTagRepository
    {
        public ProviderTagRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
