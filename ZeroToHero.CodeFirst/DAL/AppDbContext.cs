using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ZeroToHero.CodeFirst.DAL
{
    public class AppDbContext : DbContext
    {
        //public DbSet<BasePerson> Persons { get; set; }

        //public DbSet<Manager> Managers { get; set; }
        //public DbSet<Employee> Employees { get; set; }

        public DbSet<Person> People { get; set; }

        public DbSet<ProductFull> ProductFulls { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductFeature> ProductFeature { get; set; }
        //public DbSet<Student> Students { get; set; }
        //public DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Trace, Debug, Information, Warning, Error, Critical

            Initializer.Build();
            // Lazy Loading Proxies
            //optionsBuilder.LogTo(Console.WriteLine,LogLevel.Information).UseLazyLoadingProxies().UseSqlServer(Initializer.Configuration.GetConnectionString("SqlCon"));
            optionsBuilder.UseSqlServer(Initializer.Configuration.GetConnectionString("SqlCon"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //second way change for table name
            //modelBuilder.Entity<Product>().ToTable("ProductTBB", "productstbb");

            //second way selected primary key
            //modelBuilder.Entity<Product>().HasKey(x => x.Product_Id);

            //second way for required
            //modelBuilder.Entity<Product>().Property(x => x.Name).IsRequired();

            //second way for string maxlength
            //modelBuilder.Entity<Product>().Property(x => x.Name).IsRequired().HasMaxLength(100).IsFixedLength();

            //start with has everytime
            // Fluent way one to many
            //modelBuilder.Entity<Category>().HasMany(x=>x.Products).WithOne(x => x.Category).HasForeignKey(x=>x.Category_Id);

            // Fluent way for one to one relationships
            //modelBuilder.Entity<Product>().HasOne(x => x.ProductFeature).WithOne(x => x.Product).HasForeignKey<ProductFeature>(x => x.ProductRef_Id);
            // Another way
            //modelBuilder.Entity<Product>().HasOne(x => x.ProductFeature).WithOne(x => x.Product).HasForeignKey<ProductFeature>
            //    (x => x.Id);

            // Fluent way for many to many
            //modelBuilder.Entity<Student>()
            //    .HasMany(x => x.Teachers)
            //    .WithMany(x => x.Students)
            //    .UsingEntity<Dictionary<string, object>>(
            //    "StudentTeacherManyToMany",
            //    x => x.HasOne<Teacher>().WithMany().HasForeignKey("Teacher_Id").HasConstraintName("FK__TeacherId"),
            //    x => x.HasOne<Student>().WithMany().HasForeignKey("Student_Id").HasConstraintName("FK__StudentId")
            //    );

            // Delete Behaviors Cascade
            //modelBuilder.Entity<Category>().HasMany(x => x.Products).WithOne(x => x.Category)
            //    .HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.Cascade);

            // Delete Behaviors Restrict
            //modelBuilder.Entity<Category>().HasMany(x => x.Products).WithOne(x => x.Category)
            //    .HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.Restrict);

            // Delete Behaviors SetNull
            //modelBuilder.Entity<Category>().HasMany(x => x.Products).WithOne(x => x.Category)
            //    .HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.SetNull);

            //modelBuilder.Entity<Product>().Property(x => x.PriceKdv).HasComputedColumnSql("[Price]*[Kdv]");

            //modelBuilder.Entity<Product>().Property(x=>x.PriceKdv).ValueGeneratedOnAdd(); // Identity
            //modelBuilder.Entity<Product>().Property(x => x.PriceKdv).ValueGeneratedOnAddOrUpdate(); // Computed
            //modelBuilder.Entity<Product>().Property(x => x.PriceKdv).ValueGeneratedNever(); // None

            // Table Per Type
            //modelBuilder.Entity<Person>().ToTable("Persons");
            //modelBuilder.Entity<Employee>().ToTable("Employees");
            //modelBuilder.Entity<Manager>().ToTable("Managers");

            // Owned Entity Type
            //modelBuilder.Entity<Manager>().OwnsOne(x => x.Person,p => {
            //    p.Property(x => x.FirstName).HasColumnName("FirstName");
            //    p.Property(x => x.LastName).HasColumnName("LastName");
            //    p.Property(x => x.Age).HasColumnName("Age");
            //});
            //modelBuilder.Entity<Employee>().OwnsOne(x => x.Person, p => {
            //    p.Property(x => x.FirstName).HasColumnName("FirstName");
            //    p.Property(x => x.LastName).HasColumnName("LastName");
            //    p.Property(x => x.Age).HasColumnName("Age");
            //});

            // Keyless Entity second option
            modelBuilder.Entity<ProductFull>().HasNoKey();

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
