using DMS.Model.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace DMS.Data
{
    public class DMSDbContext : IdentityDbContext<ApplicationUser>
    {
        public DMSDbContext() : base("DMSConnection")
        {
            this.Configuration.LazyLoadingEnabled = false; //Khi da load bang cha roi se khong include them bang con nua
        }

        public DbSet<Customer> Customers { set; get; }
        public DbSet<Footer> Footers { set; get; }
        public DbSet<Order> Orders { set; get; }
        public DbSet<OrderDetail> OrderDetails { set; get; }
        public DbSet<OrderCategory> OrderCategories { set; get; }
        public DbSet<Page> Pages { set; get; }
        public DbSet<Post> Posts { set; get; }
        public DbSet<PostCategory> PostCategories { set; get; }
        public DbSet<PostTag> PostTags { set; get; }
        public DbSet<Product> Products { set; get; }
        public DbSet<ProductCategory> ProductCategories { set; get; }
        public DbSet<ProductTag> ProductTags { set; get; }
        public DbSet<Provider> Providers { set; get; }
        public DbSet<ProviderTag> ProviderTags { set; get; }
        public DbSet<SystemConfig> SystemConfigs { set; get; }
        public DbSet<Tag> Tags { set; get; }
        public DbSet<Error> Errors { set; get; }
        public DbSet<UnitProduct> UnitProducts { set; get; }
        public DbSet<Branch> Branchs { set; get; }

        public static DMSDbContext Create()
        {
            return new DMSDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<IdentityUserRole>().HasKey(i => new { i.UserId, i.RoleId });
            builder.Entity<IdentityUserLogin>().HasKey(i => i.UserId);
        }
    }
}