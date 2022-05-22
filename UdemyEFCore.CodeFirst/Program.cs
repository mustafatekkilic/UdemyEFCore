using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using UdemyEFCore.CodeFirst.DAL;

DbContextInitializer.Build();
using (var _context = new AppDbContext())
{
    #region DataRead
    //var products = await _context.Products.ToListAsync();

    //products.ForEach(p =>
    //{
    //    var state = _context.Entry(p).State;

    //    Console.Write($"{p.Id} - Name : {p.Name} - Price : {p.Price} - Stock : {p.Stock} - State : {state}");
    //});
    #endregion

    #region DataAdded
    //var newProduct = new Product { Name = "Urun4", Price = 2.50M, Stock = 3 };

    //Console.WriteLine($"İlk state {_context.Entry(newProduct).State}");

    ////await _context.AddAsync(newProduct);
    //_context.Entry(newProduct).State = EntityState.Added;

    //Console.WriteLine($"Son state {_context.Entry(newProduct).State}");

    //await _context.SaveChangesAsync();

    //Console.WriteLine($"Savechange state {_context.Entry(newProduct).State}");

    #endregion

    #region DataModified

    //var product = await _context.Products.FirstAsync();

    //Console.WriteLine($"İlk State: {_context.Entry(product).State}");

    //product.Stock = 1001;

    //Console.WriteLine($"Modified State: {_context.Entry(product).State}");

    //await _context.SaveChangesAsync();

    //Console.WriteLine($"SaveChange State: {_context.Entry(product).State}");


    #endregion

    #region DataRemove

    //var product = await _context.Products.FirstAsync();

    //Console.WriteLine(_context.Entry(product).State);

    //_context.Remove(product);

    //Console.WriteLine(_context.Entry(product).State);

    //await _context.SaveChangesAsync();

    //Console.WriteLine(_context.Entry(product).State);

    #endregion

    #region DetachedExample

    //var product = await _context.Products.FirstAsync();

    //Console.WriteLine(_context.Entry(product).State);

    //_context.Entry(product).State = EntityState.Detached; // Detach yaptık, artık işi izlemiyor. Veritabanına yansımayacak

    //Console.WriteLine(_context.Entry(product).State);

    //product.Name = "Urun220";

    //Console.WriteLine(_context.Entry(product).State);

    //await _context.SaveChangesAsync();

    //Console.WriteLine(_context.Entry(product).State);

    #endregion

    #region Context.Update - Example 

    //_context.Update(new Product() { Id = 3, Name = "UrunUpdateExample" , Stock=255}); // Track edilmeyen data için direkt update sağlar, alan bazlı değil yeni bir
    //                                                                                  // object oluşturduğun için diğer alanları patlatıyor, Örnek ; Barcode prop u girmedim null a çekti
    //                                                                                  //Mantıklı olan track kullanıp ilerlemek, bunun da yeri gelirse ayrı bir konu

    //await _context.SaveChangesAsync();

    #endregion

    #region AsNoTrackingExample

    ////var products = await _context.Products.AsNoTracking().ToListAsync(); //Update, delete işlem yapıyorsan eyvallah tracking yapmalı ama sade bir şekilde
    ////list yapıyorsan AsNoTracking kullan ki memory e yüklenmesin, ram i rahat bırak sana sövmesinler

    ////products.ForEach(p =>
    ////{
    ////    p.Stock += 100; //AsNoTracking metodu kullanıldığı için update yapmadı mesela 

    ////});

    ////await _context.SaveChangesAsync();


    ////var products = await _context.Products.ToListAsync();

    ////_context.ChangeTracker.Entries().ToList().ForEach(e=>
    ////{

    ////    if(e.Entity is Product product)
    ////    {
    ////        Console.WriteLine($"Name : {product.Name} - Price : {product.Price} - Barkode : {product.Barcode}");
    ////    }

    ////});

    //_context.Products.Add(new Product() { Name = "YeniUrun1", Price = 2.1M, Stock = 1, Barcode = "1234" });
    //_context.Products.Add(new Product() { Name = "YeniUrun2", Price = 2.2M, Stock = 2, Barcode = "1234" });
    //_context.Products.Add(new Product() { Name = "YeniUrun3", Price = 2.3M, Stock = 3, Barcode = "1234" });
    //_context.Products.Add(new Product() { Name = "YeniUrun4", Price = 2.4M, Stock = 4, Barcode = "1234" });


    ////SaveChanges override edildi, datetime ekleniyor

    //_context.SaveChanges();
    #endregion

    #region DbSet Methods

    //var product = _context.Products.First(x => x.Id == 100); //Sequence contains no elements - eşleşen eleman yook exception atıyor
    //var product = _context.Products.FirstOrDefault(x => x.Id == 100); // Hata yerine null dönüyor
    //var product = _context.Products.FirstOrDefault(x => x.Id == 100, new Product() { Id=1,Name = "DefaultProduct", Stock = 1 }); //Hata alıyorum
    //var product = await _context.Products.SingleAsync(x => x.Id == 6); //Tekil aldık, sorun yok. Çoklu sorguda hata fırlatıyor
    //var product = await _context.Products.SingleAsync(x => x.Id > 3); //Tekil aldık, sorun yok. Çoklu sorguda hata fırlatıyor ---- Tek data beklediğinde kullanki gelen belli olsun

    /*var products = await _context.Products.Where(x => x.Id > 6).ToListAsync();

    products.ForEach(p =>
    {
        Console.WriteLine($"Name : {p.Name} - Stock : {p.Stock}");
    });*/

    var product = await _context.Products.FindAsync(6);

    Console.WriteLine($"Sorgunun ilk elamanı : {product.Name}");

    #endregion

}
