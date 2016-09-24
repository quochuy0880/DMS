﻿using DMS.Data.Infrastructure;
using DMS.Model.Models;

namespace DMS.Data.Repositories
{
    public interface IProviderRepository : IRepository<Provider>
    {
    }

    public class ProviderRepository : RepositoryBase<Provider>, IProviderRepository
    {
        public ProviderRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}