//using System;

//namespace UdemyEFCore.DatabaseFirst
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Hello World!");
//        }
//    }
//}


using Microsoft.EntityFrameworkCore;
using System;
using UdemyEFCore.DatabaseFirst.DAL;

DbContextInitializer.Build();

//using (var _context = new AppDbContext(DbContextInitializer.OptionsBuilder.Options))
using (var _context = new AppDbContext())
{
    var products = await _context.Products.ToListAsync();

    products.ForEach(p =>
    {
        Console.WriteLine($"{p.Id} : {p.Name}  : {p.Price} : {p.Stock}");
    });
}