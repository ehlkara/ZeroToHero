﻿// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using ZeroToHero.DatabaseFirst.DAL;

DbContextInitializer.Build();

using (var _context = new AppDbContext())
{
    var products = await _context.Products.ToListAsync();

    products.ForEach(p =>
    {
        Console.WriteLine($"{p.Id} : {p.Name}");
    });
}
