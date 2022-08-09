// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using ZeroToHero.CodeFirst;
using ZeroToHero.CodeFirst.DAL;

Initializer.Build();
using(var _context = new AppDbContext())
{
    //var products = await _context.Products.AsNoTracking().ToListAsync();

    //products.ForEach(p =>
    //{
    //    //p.Stock += 100;
    //    //var state = _context.Entry(p).State;

    //    Console.WriteLine($"{p.Id}: {p.Name} - {p.Price} - {p.Stock}");
    //});

    _context.Products.Add(new() { Name = "Pen 101", Price = 200, Stock = 100, Barcode = 123 });
    _context.Products.Add(new() { Name = "Pen 102", Price = 300, Stock = 200, Barcode = 345 });
    _context.Products.Add(new() { Name = "Pen 103", Price = 400, Stock = 300, Barcode = 789 });

    Console.WriteLine($"Context Id: {_context.ContextId}");

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
}