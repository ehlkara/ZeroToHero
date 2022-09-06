// See https://aka.ms/new-console-template for more information

using System.Data.Common;
using AutoMapper.QueryableExtensions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using ZeroToHero.CodeFirst;
using ZeroToHero.CodeFirst.DAL;
using ZeroToHero.CodeFirst.DTOs;
using ZeroToHero.CodeFirst.Mappers;

Initializer.Build();

//var connection = new SqlConnection(Initializer.Configuration.GetConnectionString("SqlCon"));

//IDbContextTransaction transaction = null;
using (var _context = new AppDbContext())
{
    //var products = await _context.Products.AsNoTracking().ToListAsync();

    //products.ForEach(p =>
    //{
    //    //p.Stock += 100;
    //    //var state = _context.Entry(p).State;

    //    Console.WriteLine($"{p.Id}: {p.Name} - {p.Price} - {p.Stock}");
    //});

    //_context.Products.Add(new() { Name = "Pen 101", Price = 200, Stock = 100, Barcode = 123 });
    //_context.Products.Add(new() { Name = "Pen 102", Price = 300, Stock = 200, Barcode = 345 });
    //_context.Products.Add(new() { Name = "Pen 103", Price = 400, Stock = 300, Barcode = 789 });

    //Console.WriteLine($"Context Id: {_context.ContextId}");

    //_context.SaveChanges();

    // States Notion
    //var newProduct = new Product { Name = "Pen 300", Price = 200, Stock = 100, Barcode = 333 };

    //var product = await _context.Products.FirstAsync();

    //_context.Update(new Product() { Id = 5, Name = "Notebook", Price = 500, Stock = 500, Barcode = 500 });

    //Console.WriteLine($"First State: {_context.Entry(product).State}");

    //_context.Entry(product).State = EntityState.Detached;

    //Console.WriteLine($"Last State: {_context.Entry(product).State}");

    //product.Stock = 1000;

    //product.Name = "Pen 2000";

    //_context.Remove(product);
    //_context.Entry(product).State = EntityState.Deleted;

    //_context.Entry(newProduct).State = EntityState.Added;

    //await _context.AddAsync(newProduct);

    //await _context.SaveChangesAsync();

    //Console.WriteLine($"State after save changes: {_context.Entry(product).State}");

    //Update method clue
    //var products = _context.Products.ToList();

    //products.ForEach(p =>
    //{
    //    p.Stock += 100;
    //});
    //_context.ChangeTracker.Entries().ToList().ForEach(e =>
    //{
    //    if (e.Entity is Product p)
    //    {
    //        Console.WriteLine(e.State);
    //    }
    //});
    //_context.SaveChanges();

    // Linq queries
    //var products = _context.Products.First(x => x.Id == 100); // Throw exception
    //var products2 = _context.Products.FirstOrDefault(x => x.Id == 100); // return null
    //var products3 = await _context.Products.SingleAsync(x => x.Id == 100); // Throw exception
    //var products4 = await _context.Products.Where(x => x.Id > 10 && x.Name == "Pen 101" || x.Stock > 300).ToListAsync();
    //var products5 = await _context.Products.FirstAsync(x => x.Id == 8);
    //var products6 = await _context.Products.SingleAsync(x => x.Id == 8);
    //var products7 = await _context.Products.FindAsync(8);
    //var products8 = await _context.Products.AsNoTracking().FirstAsync(x => x.Id == 8);
    //Console.WriteLine(_context.Entry(products8).State);

    //--------------------------------------------------------------------
    // Domain Driven Design best practice
    //var category = _context.Categories.First();
    //category.Products.Add(new Product() { });

    //--------------------------------------------------------
    // Data Add(One To Many)
    //var category = new Category() { Name = "NoteBooks" };
    //var category = _context.Categories.First(x => x.Name == "NoteBooks");

    //First Way
    //var product = new Product() { Name = "Pen 1", Price = 100, Stock = 200, CreatedDate = DateTime.Now, Barcode = 123, Category = category };

    // Second Way
    //category.Products.Add(new Product() { Name = "Notebook 1", Price = 100, Stock = 200, CreatedDate = DateTime.Now, Barcode = 123 });
    //category.Products.Add(new Product() { Name = "Notebook 2", Price = 100, Stock = 200, CreatedDate = DateTime.Now, Barcode = 123 });

    // Third Way
    //var product = new Product() { Name = "Notebook 3", Price = 100, Stock = 200, CreatedDate = DateTime.Now, Barcode = 123, Category = category };

    //_context.Categories.Add(category); // Not need this code
    //_context.Add(product);
    //_context.Add(product);
    //_context.SaveChanges();

    //--------------------------------------------------------
    // Data Add(One To One)
    // Product => Parent
    // ProductFeature => childed

    //var category = new Category() { Name = "Rubbers" };
    //var category = _context.Categories.First(x => x.Name == "Rubbers");

    //var product = new Product
    //{
    //    Name = "Rubber 5",
    //    Price = 200,
    //    Stock = 200,
    //    CreatedDate = DateTime.Now,
    //    Barcode = 123,
    //    Category = category,
    //    ProductFeature = new ProductFeature() { Color = "Red", Height = 100, Width = 200 }
    //};

    // Another way
    //var product = new Product
    //{
    //    Name = "Rubber 5",
    //    Price = 200,
    //    Stock = 200,
    //    CreatedDate = DateTime.Now,
    //    Barcode = 123,
    //    Category = category
    //};

    //ProductFeature productFeature = new ProductFeature() { Color = "Blue", Height = 100, Width = 200, Product = product };

    //_context.Products.Add(product);
    //_context.ProductFeature.Add(productFeature);
    //_context.SaveChanges();

    //--------------------------------------------------------
    // Data Add(Many To Many)
    //var student = new Student() { Name = "Ahmet", Age = 23, };
    //student.Teachers.Add(new() { Name = "Ahmet Teacher"});
    //student.Teachers.Add(new() { Name = "Mehmet Teacher" });

    //_context.Add(student);

    // Second way
    //var teacher = new Teacher()
    //{
    //    Name = "Hasan Teacher",
    //    Students = new() {
    //new Student() {Name = "Hasan1", Age = 22},
    //new Student() {Name = "Hasan2", Age = 23}
    //}
    //};

    //_context.Add(teacher);

    //data add with existing teacher
    //var teacher = _context.Teachers.First(x => x.Name == "Hasan Teacher");

    //teacher.Students.AddRange(new List<Student> {
    //    new() { Name = "Hasan 100", Age = 20 }, new() { Name = "Hasan 200", Age = 25 } });

    //_context.SaveChanges();

    //--------------------------------------------------------
    // Delete Behaviors => Cascade, Restrict, SetNull, NoAction

    //var category = new Category()
    //{
    //    Name = "Pens",
    //    Products = new List<Product>()
    //{
    //    new() {Name = "Pen 1", Price = 100, Stock = 100, CreatedDate = DateTime.Now, Barcode = 123},
    //    new() {Name = "Pen 2", Price = 200, Stock = 100, CreatedDate = DateTime.Now, Barcode = 123},
    //    new() {Name = "Pen 3", Price = 300, Stock = 100, CreatedDate = DateTime.Now, Barcode = 123}
    //}
    //};
    //_context.Add(category);

    // Cascade behaviors
    //var category = _context.Categories.First();
    //_context.Categories.Remove(category);

    // Restrict behaviors
    //var category = _context.Categories.First();

    //var products = _context.Products.Where(x=>x.CategoryId == category.Id).ToList();

    //_context.RemoveRange(products);

    //_context.Categories.Remove(category);

    // SetNull behaviours
    //var category = _context.Categories.First();
    //_context.Categories.Remove(category);

    //_context.SaveChanges();

    //--------------------------------------------------------
    // DatabaseGenerated attribute

    //_context.Products.Add(new() { Name = "Pen 1", Price = 100, Stock = 200, Barcode = 123, LastAccessDate = DateTime.Now, Kdv = 18 });
    //_context.SaveChanges();

    //--------------------------------------------------------
    // Data Add

    //var category = new Category() { Name = "Pens" };

    //category.Products.Add(new()
    //{
    //    Name = "Pen 1",
    //    Price = 100,
    //    Stock = 100,
    //    Barcode = 123,
    //    ProductFeature = new()
    //    {
    //        Color = "Red",
    //        Height = 100,
    //        Width = 200
    //    }
    //});
    //category.Products.Add(new()
    //{
    //    Name = "Pen 2",
    //    Price = 100,
    //    Stock = 100,
    //    Barcode = 123,
    //    ProductFeature = new()
    //    {
    //        Color = "Blue",
    //        Height = 100,
    //        Width = 200
    //    }
    //});

    //await _context.AddAsync(category);
    //await _context.SaveChangesAsync();

    // Eager Loading
    //var categoryWithProducts = _context.Categories.Include(x => x.Products).ThenInclude(x => x.ProductFeature).First();

    //categoryWithProducts.Products.ForEach(product =>
    //{
    //    Console.WriteLine($"{categoryWithProducts.Name} {product.Name} {product.ProductFeature.Width}");
    //});

    //var productFeature = _context.ProductFeature.Include(x => x.Product).ThenInclude(x => x.Category).First();

    //var product = _context.Products.Include(x => x.ProductFeature).Include(x => x.Category).First();

    //Console.WriteLine("Proccess finished");

    // Explicit Loading
    //var catagory = _context.Categories.First();
    //var product = _context.Products.First();
    ////
    ////
    ////
    //if (true)
    //{
    //    _context.Entry(catagory).Collection(x => x.Products).Load();

    //    _context.Entry(product).Reference(x => x.ProductFeature).Load();

    //    catagory.Products.ForEach(x =>
    //    {
    //        Console.WriteLine(x.Name);
    //    });
    //}
    //////
    ///

    // Lazy Loading
    //var category = await _context.Categories.FirstAsync();

    //Console.WriteLine("Loaded category");

    //var products = category.Products;

    //// (N+1 Problem)
    //products.ForEach(x =>
    //{
    //    var productFeature = x.ProductFeature;
    //});

    //--------------------------------------------------------
    // Table Per Hierarchy

    // Data Add
    //_context.Persons.Add(new Manager() { FirstName = "m1", LastName = "m2", Age = 22, Grade = 1 });
    //_context.Persons.Add(new Employee() { FirstName = "e1", LastName = "e2", Age = 22, Salary = 1000 });

    //_context.SaveChanges();

    // Get Data Queries
    //var managers = _context.Managers.ToList();

    //var employees = _context.Employees.ToList();

    //var persons = _context.Persons.ToList();

    //persons.ForEach(p =>
    //{
    //    switch (p)
    //    {
    //        case Manager manager:
    //            Console.WriteLine($"Manager entity: {manager.Grade}");
    //            break;
    //        case Employee employee:
    //            Console.WriteLine($"Employee entity: {employee.Salary}");
    //            break;
    //        default:
    //            break;
    //    }
    //});

    //--------------------------------------------------------
    // Table Per Type

    //Data Add
    //_context.Managers.Add(new Manager() { FirstName = "m3", LastName = "m4", Age = 22, Grade = 1 });
    //_context.Employees.Add(new Employee() { FirstName = "e3", LastName = "e4", Age = 22, Salary = 1000 });

    //_context.SaveChanges();

    // Get Data Queries
    //var managers = _context.Managers.ToList();

    //var employees = _context.Employees.ToList();

    //var persons = _context.Persons.ToList();

    //persons.ForEach(p =>
    //{
    //    switch (p)
    //    {
    //        case Manager manager:
    //            Console.WriteLine($"Manager entity: {manager.Grade}");
    //            break;
    //        case Employee employee:
    //            Console.WriteLine($"Employee entity: {employee.Salary}");
    //            break;
    //        default:
    //            break;
    //    }
    //});

    //--------------------------------------------------------
    // Keyless Entity Type

    //var productFulls = _context.ProductFulls.FromSqlRaw(@"Select p.Id 'Product_Id', c.Name 'CategoryName', p.Name, p.Price, pf.Height From Products p join ProductFeature pf on p.Id = pf.Id join Categories c on p.CategoryId=c.Id").ToList();

    //Console.WriteLine("Proccess finished");

    // You cannot track proccesses.(Insert, delete, update)
    //_context.People.Add(new Person() { FirstName = "Ahmet", LastName = "Yılmaz", Age = 23 });

    //--------------------------------------------------------
    // Indexes

    //_context.Products.Where(x => x.Name == "Pen 1").Select(x => new { name = x.Name, Price = x.Price, Stock = x.Stock, Barcode = x.Barcode });

    //_context.Products.Add(new() { Name = "Pen 5", Price = 100, DiscountPrice = 120, Barcode = 123, Stock = 1, Url = "abc" });

    //_context.SaveChanges();

    //--------------------------------------------------------
    // Client vs Server Evaluation

    //_context.People.Add(new Person() { FirstName = "Ahmet", LastName = "Aslan", Age = 23, Phone = "05554443322" });
    //_context.People.Add(new Person() { FirstName = "Mehmet", LastName = "Aslan", Age = 24, Phone = "05554443322" });

    //_context.SaveChanges();

    //string FormatPhone(string phone)
    //{
    //    return phone.Substring(1, phone.Length - 1);
    //}

    //var persons = _context.People.ToList().Where(x => FormatPhone( x.Phone) == "5554443322").ToList();

    //var person = _context.People.ToList().Select(x => new { PersonName = x.FirstName, PersonPhone = FormatPhone(x.Phone) }).ToList();

    //Console.WriteLine("Proccess Finished");

    //--------------------------------------------------------
    // Data Added
    //var category = new Category() { Name = "NoteBooks" };

    //category.Products.Add(new()
    //{
    //    Name = "NoteBook 1",
    //    Price = 100,
    //    Stock = 200,
    //    Barcode = 123,
    //    ProductFeature = new ProductFeature()
    //    {
    //        Color = "Red",
    //        Height = 200,
    //        Width = 100
    //    }
    //});
    //category.Products.Add(new()
    //{
    //    Name = "NoteBook 2",
    //    Price = 200,
    //    Stock = 200,
    //    Barcode = 123,
    //    ProductFeature = new ProductFeature()
    //    {
    //        Color = "Red",
    //        Height = 200,
    //        Width = 100
    //    }
    //});
    //category.Products.Add(new()
    //{
    //    Name = "NoteBook 3",
    //    Price = 300,
    //    Stock = 200,
    //    Barcode = 123,
    //    ProductFeature = new ProductFeature()
    //    {
    //        Color = "Red",
    //        Height = 200,
    //        Width = 100
    //    }
    //});
    //category.Products.Add(new()
    //{
    //    Name = "NoteBook 4",
    //    Price = 400,
    //    Stock = 200,
    //    Barcode = 123,
    //    ProductFeature = new ProductFeature()
    //    {
    //        Color = "Red",
    //        Height = 200,
    //        Width = 100
    //    }
    //});

    //_context.Categories.Add(category);
    //_context.SaveChanges();

    //--------------------------------------------------------
    // Inner Join

    // First Way(Two tables between join proccess)
    //var result = _context.Categories.Join(_context.Products, x => x.Id, y => y.CategoryId, (c, p) => new
    //{
    //    CategoryName = c.Name,
    //    ProductName = p.Name,
    //    ProductPrice = p.Price
    //}).ToList();

    //var result = _context.Categories.Join(_context.Products, x => x.Id, y => y.CategoryId, (c, p) => p).ToList();

    //Second Way
    //var result2 = (from c in _context.Categories
    //               join p in _context.Products on c.Id equals p.CategoryId
    //               select p).ToList();

    //var result3 = (from c in _context.Categories
    //               join p in _context.Products on c.Id equals p.CategoryId
    //               select new
    //               {
    //                   CategoryName = c.Name,
    //                   ProductName = p.Name,
    //                   ProductPrice = p.Price
    //               }).ToList();

    // Third join

    //var result = _context.Categories.Join(_context.Products, c => c.Id, p => p.CategoryId, (c, p) => new { c, p })
    //    .Join(_context.ProductFeatures, x => x.p.Id, y => y.Id, (c, pf) => new
    //    {
    //        CategoryName = c.c.Name,
    //        ProductName = c.p.Name,
    //        PRoductFeatureColor = pf.Color
    //    }).ToList();

    //var result2 = (from c in _context.Categories
    //               join p in _context.Products on c.Id equals p.CategoryId
    //               join pf in _context.ProductFeatures on p.Id equals pf.Id
    //               select new
    //               {
    //                   CategoryName = c.Name,
    //                   ProductName = p.Name,
    //                   PRoductFeatureColor = pf.Color
    //               }).ToList();

    //var result3 = (from c in _context.Categories
    //               join p in _context.Products on c.Id equals p.CategoryId
    //               join pf in _context.ProductFeatures on p.Id equals pf.Id
    //               select new { c, p, pf }).ToList();

    //Console.WriteLine("Proccess Finished");

    //--------------------------------------------------------
    // Left/Right Join

    // left Join
    //var leftResult = await (from p in _context.Products
    //              join pf in _context.ProductFeatures on p.Id equals pf.Id into pfList
    //              from pf in pfList.DefaultIfEmpty()
    //              select new { p,pf }).ToListAsync();

    //var leftResult2 = await (from p in _context.Products
    //                    join pf in _context.ProductFeatures on p.Id equals pf.Id into pfList
    //                    from pf in pfList.DefaultIfEmpty()
    //                    select new 
    //                    {
    //                        ProductName = p.Name,
    //                        PRoductColor = pf.Color,
    //                        ProductWidth =(int?)pf.Width == null ? 5 : pf.Width
    //                    }).ToListAsync();

    // Right Join
    //var rightResult2 = await (from pf in _context.ProductFeatures
    //                         join p in _context.Products on pf.Id equals p.Id into pList
    //                         from p in pList.DefaultIfEmpty()
    //                         select new
    //                         {
    //                             ProductName = p.Name,
    //                             ProductPrice = (decimal?)p.Price,
    //                             PRoductColor = pf.Color,
    //                             ProductWidth = pf.Width
    //                         }).ToListAsync();

    //Console.WriteLine("Proccess Finished");

    //--------------------------------------------------------
    // FullOuter Join

    //Query syntax
    //var left = await (from p in _context.Products
    //            join pf in _context.ProductFeatures on p.Id equals pf.Id into pfList
    //            from pf in pfList.DefaultIfEmpty()
    //            select new
    //            {
    //                Id = p.Id,
    //                Name = p.Name,
    //                Color = pf.Color
    //            }).ToListAsync();

    //var right = await (from pf in _context.ProductFeatures
    //             join p in _context.Products on pf.Id equals p.Id into plist
    //             from p in plist.DefaultIfEmpty()
    //             select new
    //             {
    //                 Id = p.Id,
    //                 Name = p.Name,
    //                 Color = pf.Color
    //             }).ToListAsync();

    //var outerJoin = left.Union(right);

    //Console.WriteLine("Proccess Finished");

    //--------------------------------------------------------
    // Raw Sql Query

    //var id = 4;

    //decimal price = 100;

    //var products = await _context.Products.FromSqlRaw("Select * From products").ToListAsync();

    // With Parameter
    //var product = await _context.Products.FromSqlRaw("Select * From products where id = {0}", id).FirstAsync();

    //var product2 = await _context.Products.FromSqlRaw("Select * From products where price > {0}", price).ToListAsync();

    //var product3 = await _context.Products.FromSqlInterpolated($"Select * From products where price > {price}").ToListAsync();

    // Custome Query
    //var product4 = await _context.ProductEssentials.FromSqlRaw("Select Id,Name,Price From products").ToListAsync();

    //var product5 = await _context.ProductEssentials.FromSqlRaw("Select Name,Price From products").ToListAsync();

    //var productwithFeature = await _context.ProductWithFeatures.FromSqlRaw("SELECT p.Id,p.Name,p.Price,pf.Color,pf.Height From Products p INNER JOIN ProductFeatures pf on p.Id = pf.Id").ToListAsync();

    //--------------------------------------------------------
    // ToSql Query

    //var products = _context.ProductEssentials.Where(x=>x.Price > 200).ToList();

    //--------------------------------------------------------
    // ToView Query

    //var products = _context.ProductFulls.Where(x => x.Width > 100).ToList();

    //--------------------------------------------------------
    // Global Query Filters (Soft Delete)

    //var products = _context.Products.IgnoreQueryFilters().ToList();

    //--------------------------------------------------------
    // Query Tags

    //var productsWithFeatures = _context.Products.TagWith("This query is getting products and products relations to get properties").Include(x => x.ProductFeature).Where(x => x.Price > 100).ToList();

    //--------------------------------------------------------
    // Tracking / No Tracking

    //var product = _context.Products.First(x => x.Id == 2);

    //product.Name = "Pen 22";

    //// if use AsNoTracking
    //_context.Entry(product).State = EntityState.Modified;
    //// or
    //_context.Update(product);

    //_context.SaveChanges();

    //--------------------------------------------------------
    // Stored Procedure

    //var products = await _context.Products.FromSqlRaw("exec sp_get_products").ToListAsync();

    //var productFull = await _context.ProductFulls.FromSqlRaw("EXEC sp_get_product_full").ToListAsync();

    //var product2 = productFull.Where(x => x.Width > 100);

    //int categoryId = 1;
    //decimal price = 100;
    //var productWithParameter = await _context.ProductFulls.FromSqlInterpolated($"EXEC sp_get_product_full_parameters {categoryId},{price}").ToListAsync();

    //var product = new Product()
    //{
    //    Name = "Pen 2000",
    //    Price = 300,
    //    Stock = 70,
    //    Barcode = 123,
    //    DiscountPrice = 50,
    //    CategoryId = 1
    //};

    //var newProductIdParameter = new SqlParameter("@newId", System.Data.SqlDbType.Int);
    //newProductIdParameter.Direction = System.Data.ParameterDirection.Output;

    //_context.Database.ExecuteSqlInterpolated($"EXEC sp_insert_product {product.Name},{product.Price},{product.DiscountPrice},{product.Stock}, {product.Barcode}, {product.CategoryId}, {newProductIdParameter} out");

    //var newProductId = newProductIdParameter.Value;

    //var result = _context.Database.ExecuteSqlInterpolated($"EXEC sp_insert_product2 {product.Name},{product.Price},{product.DiscountPrice},{product.Stock}, {product.Barcode}, {product.CategoryId}");

    //--------------------------------------------------------
    // Functions

    //var products = await _context.ProductFulls.ToListAsync();

    //int categoryId = 1;

    //var productWithFeatures = await _context.ProductWithFeatures.FromSqlInterpolated($"SELECT * FROM fc_product_full_with_parameters({categoryId})").ToListAsync();

    //var product = _context.GetProductWithFeatures(1).Where(x => x.Width > 100).ToList();

    //var count = _context.GetProductCount(1); // Cannot used

    //var categories = await _context.Categories.Select(x => new
    //{
    //    CategoryName = x.Name,
    //    ProductCount = _context.GetProductCount(x.Id)
    //}).Where(x => x.ProductCount > 10).ToListAsync();

    //int categoryId = 1;
    //var productCount = _context.ProductCounts.FromSqlInterpolated($"SELECT dbo.fc_get_product_count({categoryId}) As COUNT").First().Count;

    //--------------------------------------------------------
    // Projections

    //var products = await _context.Products.Select(x => new
    //{
    //    CategoryName = x.Category.Name,
    //    ProductName = x.Name,
    //    ProductPrice = x.Price,
    //    Width = (int?)x.ProductFeature.Width
    //}).Where(x => x.Width > 10 && x.ProductName.StartsWith("P")).ToListAsync();

    //var categories = await _context.Categories.Select(x => new
    //{
    //    CategoryName = x.Name,
    //    Products = String.Join(',', x.Products.Select(z => z.Name)), // Pen 1, Pen 2
    //    TotalPrice = x.Products.Sum(x => x.Price),
    //    TotalWidth = (int?)x.Products.Select(x=>x.ProductFeature.Width).Sum()
    //}).Where(y => y.TotalPrice > 100).OrderBy(x => x.TotalPrice).ToListAsync();

    // DTO version

    //var products = await _context.Products.Select(x => new ProductDto
    //{
    //    CategoryName = x.Category.Name,
    //    ProductName = x.Name,
    //    ProductPrice = x.Price,
    //    Width = (int?)x.ProductFeature.Width
    //}).Where(x => x.Width > 10 && x.ProductName.StartsWith("P")).ToListAsync();

    //var categories = await _context.Categories.Select(x => new ProductDto2
    //{
    //    CategoryName = x.Name,
    //    ProductNames = String.Join(',', x.Products.Select(z => z.Name)), // Pen 1, Pen 2
    //    TotalPrice = x.Products.Sum(x => x.Price),
    //    TotalWidth = (int?)x.Products.Select(x => x.ProductFeature.Width).Sum()
    //}).Where(y => y.TotalPrice > 100).OrderBy(x => x.TotalPrice).ToListAsync();

    // AutoMapper version

    //var productsDto = _context.Products.Select(x => new ProductDTOs
    //{
    //    Id = x.Id,
    //    Name = x.Name,
    //    Price = x.Price,
    //    DiscountPrice = x.DiscountPrice,
    //    Stock = x.Stock
    //}).ToList();

    //var product = _context.Products.ToList();

    //var productDto = ObjectMapper.Mapper.Map<List<ProductDTOs>>(product);

    //var productDto = _context.Products.ProjectTo<ProductDTOs>(ObjectMapper.Mapper.ConfigurationProvider).Where(x => x.Price > 10).ToList();

    //--------------------------------------------------------
    // Transactions

    // Wihout transaction
    //var category = new Category() { Name = "Kılıflar" };

    //_context.Categories.Add(category);


    ////var product = await _context.Products.FirstAsync();

    ////product.Name = "Pen 123987";
    ////product.CategoryId = 10;

    //Product product =
    //    new()
    //    {
    //        Name = "Kılıf 1",
    //        Price = 100,
    //        Stock = 200,
    //        Barcode = 123,
    //        DiscountPrice = 100,
    //        Category = category
    //    };

    //_context.Products.Add(product);
    //_context.SaveChanges();

    //With transaction
    //using (transaction = _context.Database.BeginTransaction())
    //{

    //    var category = new Category() { Name = "Kılıflar" };

    //    _context.Categories.Add(category);
    //    _context.SaveChanges();

    //    Product product =
    //        new()
    //        {
    //            Name = "Kılıf 2",
    //            Price = 100,
    //            Stock = 200,
    //            Barcode = 123,
    //            DiscountPrice = 100,
    //            CategoryId = category.Id
    //        };

    //    _context.Products.Add(product);
    //    _context.SaveChanges();

    //    using (var dbContext2 = new AppDbContext(connection))
    //    {
    //        dbContext2.Database.UseTransaction(transaction.GetDbTransaction());

    //        var product3 = dbContext2.Products.First();
    //        product3.Stock = 3000;
    //        dbContext2.SaveChanges();
    //    }


    //    transaction.Commit();
    //    Console.WriteLine("Proccess Finished");
    //}

    //--------------------------------------------------------
    // ISOLATION LEVEL

    //Read uncomitted

    //using(var trasanction = _context.Database.BeginTransaction())
    //{

    //    var products = _context.Products.ToList();

    //var categories = _context.Categories.ToList();
    //var product = _context.Products.First();
    //product.Price = 500;

    //_context.Products.Add(new Product() { Name = "a", Price = 1, Stock = 1, Barcode = 1, CategoryId = 1, DiscountPrice = 1 });

    //_context.SaveChanges();

    //trasanction.Commit();
    //}

    //Read comitted

    //using (var transaction = _context.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))
    //{
    //    var product = _context.Products.First();
    //    product.Price = 1;

    //    _context.SaveChanges();

    //    transaction.Commit();
    //}

    //Repeatable Read

    //using (var transaction = _context.Database.BeginTransaction(System.Data.IsolationLevel.RepeatableRead))
    //{
    //    var product = _context.Products.Take(2).ToList();

    //    transaction.Commit();
    //}

    //Serializable

    //using (var transaction = _context.Database.BeginTransaction(System.Data.IsolationLevel.Serializable))
    //{
    //    var product = _context.Products.ToList();

    //    transaction.Commit();
    //}

    //Snapshot

    using (var transaction = _context.Database.BeginTransaction(System.Data.IsolationLevel.Snapshot))
    {
        var product = _context.Products.AsNoTracking().ToList();

        // business code

        var product2 = _context.Products.AsNoTracking().ToList();

        transaction.Commit();
    }
}


//--------------------------------------------------------
// Pagination

//Take Linq method (10)
//Skip Linq method (2)

//static List<Product> GetProducts(int page, int pageSize)
//{
//    using (var _context = new AppDbContext())
//    {
//        // page=1 pageSize=3 => First 3 data => skip :0 take:3 ((page-1)*pageSize) => (1-1)*3 : 0
//        // page=2 pageSize=3 => First 3 data => skip :3 take:3 ((page-1)*pageSize) => (2-1)*3 : 3
//        // page=3 pageSize=3 => First 3 data => skip :6 take:3 ((page-1)*pageSize) => (3-1)*3 : 6

//        return _context.Products.Where(x=>x.Price > 100).OrderByDescending(x => x.Id).Skip((page - 1) * pageSize).Take(pageSize).ToList();
//    }
//}

//GetProducts(1, 5).ForEach(x =>
//{
//    Console.WriteLine($"{x.Id} {x.Name} {x.Price}");
//});