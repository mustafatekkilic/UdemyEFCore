using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using UdemyEFCore.GlobalQueryFilters.DAL;
using UdemyEFCore.GlobalQueryFilters.Entity;

//using (var _context = new AppDbContext(barcode:1234))
using (var _context = new AppDbContext())
{

    #region Add Data - Category
    //_context.Category.Add(new Category()
    //{
    //    Name = "Defterler"
    //});
    //_context.SaveChanges();
    #endregion

    #region Add Data - Product
    //var category = _context.Category.Where(x => x.Name == "Defterler").First();
    //int i = 0;
    //while (i <= 3)
    //{
    //    _context.Product.Add(new()
    //    {
    //        Name = $"Defterler {i + 1}",
    //        Barcode = "1234",
    //        Stock = 1234,
    //        Url = "defterex.com",
    //        ProductFeatures = new ProductFeatures()
    //        {
    //            Color = "Green",
    //            Width = 20,
    //            Height = 20
    //        },
    //        Category = category
    //    });
    //    i++;
    //}
    //_context.SaveChanges();
    #endregion


    //var products = _context.Product.ToList();
    //var products2 = _context.Product.IgnoreQueryFilters().ToList();


    var productWithFeatures = _context.Product.TagWith($@"Ürünler ve özellikleri
{"salamcanım"}").Include(x => x.ProductFeatures).Where(x => x.Price <= 100).ToList();

    productWithFeatures[0].Name = "marabacanim22";

    //Tracking edilmeyen veriler db ye sadece savechanges method u ile yazılamaz. Bu iki satır koddan biri kullanılmalı
    //_context.Entry(productWithFeatures[0]).State = EntityState.Modified;
    _context.Update(productWithFeatures[0]);

    _context.SaveChanges();
    //Debugger.Break();
}
