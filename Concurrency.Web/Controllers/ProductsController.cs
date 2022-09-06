using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Concurrency.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Concurrency.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> List()
        {
            return View(await _context.Products.ToListAsync());
        }

        public async Task<IActionResult> Update(int id)
        {
            var product = await _context.Products.FindAsync(id);

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Product product)
        {
            try
            {
                _context.Products.Update(product);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(List));
            }
            catch (DbUpdateConcurrencyException exception)
            {
                var exceptionEntry = exception.Entries.First();
                var currentProduct = exceptionEntry.Entity as Product;
                var databaseValues = exceptionEntry.GetDatabaseValues();
                
                var clientValues = exceptionEntry.CurrentValues;

                if(databaseValues == null)
                {
                    ModelState.AddModelError(string.Empty, "This product deleted from another user");
                }
                else
                {
                    var databaseProduct = databaseValues.ToObject() as Product;
                    ModelState.AddModelError(string.Empty, "This product updated from another user");
                    ModelState.AddModelError(string.Empty, $"Updated Values: Name:{databaseProduct.Name}, Price:" +
                        $"{databaseProduct.Price}, Stock:{databaseProduct.Stock}");
                }

                return View(product);
            }
        }
    }
}

