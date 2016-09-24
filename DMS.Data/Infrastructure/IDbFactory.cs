using System;

namespace DMS.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        DMSDbContext Init();
    }
}