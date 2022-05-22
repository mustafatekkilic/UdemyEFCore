using Microsoft.EntityFrameworkCore;
using System;
using UdemyEFCore.DatabaseFirstByScaffold.Models;

using (var _context = new UdemyEFCoreDatabaseFirstDBContext())
{
    var products = await _context.Products.ToListAsync();

    products.ForEach(p =>
    {
        Console.WriteLine($"{p.Id} : {p.Name}  : {p.Price} : {p.Stock} Scaffold");
    });
}
