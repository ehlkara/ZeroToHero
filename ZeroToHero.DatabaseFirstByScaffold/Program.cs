// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using ZeroToHero.DatabaseFirstByScaffold.Models;

using (var context = new ZeroToHeroDbContext())
{
    var products = await context.Products.ToListAsync();

    products.ForEach(p =>
    {
        Console.WriteLine($"{p.Id}: {p.Name} - {p.Price} - {p.Stock}");
    });
}