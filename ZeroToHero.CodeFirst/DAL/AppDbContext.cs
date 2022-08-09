using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ZeroToHero.CodeFirst.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Initializer.Build();
            optionsBuilder.UseSqlServer(Initializer.Configuration.GetConnectionString("SqlCon"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //second way change for table name
            //modelBuilder.Entity<Product>().ToTable("ProductTBB", "productstbb");
            //second way selected primary key
            modelBuilder.Entity<Product>().HasKey(x => x.Product_Id);

            base.OnModelCreating(modelBuilder);
        }

        //public override int SaveChanges()
        //{
        //    ChangeTracker.Entries().ToList().ForEach(e =>
        //    {
        //        if (e.Entity is Product p)
        //        {
        //            if (e.State == EntityState.Added)
        //            {
        //                p.CreatedDate = DateTime.Now;
        //            }
        //        }
        //    });
        //    return base.SaveChanges();
        //}
    }
}
