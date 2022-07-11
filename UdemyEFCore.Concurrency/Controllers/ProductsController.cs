using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using UdemyEFCore.Concurrency.Models;

namespace UdemyEFCore.Concurrency.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Update(int id)
        {

            var product = await _context.Products.FindAsync(id);
            return View(product);
        }

        public async Task<IActionResult> List()
        {
            return View(await _context.Products.ToListAsync());
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

                if (databaseValues == null)
                {
                    ModelState.AddModelError(string.Empty, "Bu ürün silinmiş kardeşim üzgünüm");
                }
                else
                {
                    var databaseProduct = databaseValues.ToObject() as Product;
                    ModelState.AddModelError(string.Empty, "Bu ürün güncellenmiş kardeşim üzgünüm");
                    ModelState.AddModelError(string.Empty, $"Güncellenen veriler : {databaseProduct.Name}{databaseProduct.Price}{databaseProduct.Stock}");
                }

            }

            return View(product);
        }
    }
}
