namespace DMS.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private DMSDbContext dbContext;

        public DMSDbContext Init()
        {
            return dbContext ?? (dbContext = new DMSDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}