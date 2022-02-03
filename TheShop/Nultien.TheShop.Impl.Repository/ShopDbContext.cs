using Microsoft.EntityFrameworkCore;
using Nultien.TheShop.DataDomain;
using System.Linq;

namespace Nultien.TheShop.Impl.Repository
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
        {
        }

        public void MarkChanged(DbEntity entity) 
        {
            this.Entry(entity).State = EntityState.Modified;
        }
        public DbSet<SupplierStock> SupplierStocks { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>().HasKey(x => x.ID);
            modelBuilder.Entity<Supplier>().HasKey(x => x.ID);
            modelBuilder.Entity<Buyer>().HasKey(x => x.ID);
            modelBuilder.Entity<SupplierStock>().HasKey(x => x.ID);

            modelBuilder.Entity<SupplierStock>()
                .HasOne<Supplier>(s => s.Supplier).WithMany(s => s.SupplierStocks)
                .HasForeignKey(p => p.SupplierID);
            modelBuilder.Entity<SupplierStock>()
                .HasOne<Article>(s => s.Article).WithMany(s => s.SupplierStocks)
                .HasForeignKey(p => p.ArticleID); 
        }
    }
}
