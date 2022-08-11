// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using ZeroToHero.CodeFirst;
using ZeroToHero.CodeFirst.DAL;

Initializer.Build();
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
    var category = _context.Categories.First();
    _context.Categories.Remove(category);

    _context.SaveChanges();
}