using System;
using System.Collections.Generic;
using System.Linq;
using UdemyEFCore.ReleationShipsExample.DAL;
using Microsoft.Data.SqlClient;

using (var _context = new AppDbContext())
{
    #region Db Create Test Codes

    //var categories = new List<Category>()
    //{
    //    new Category{Name="LegalMallar"},
    //    new Category{Name="İllegalMallar"},
    //    new Category{Name="Kimenemallar"},
    //    new Category{Name="Şakabuyarin"},
    //    new Category{Name="oburgunbasimabela"},
    //    new Category{Name="olmasinmallar"}

    //};
    ////var product = new Product() { Name = "Urun1", Stock = 1, Description = "Aciklama1", Price = 2.1M };

    //await _context.AddRangeAsync(categories);
    //await _context.SaveChangesAsync();

    //Console.WriteLine("Ürün eklendi mi? Git bir bak");

    #endregion

    #region DeleteAllRows

    //foreach (var item in _context.Category)
    //{
    //    _context.Category.Remove(item);
    //}
    //_context.SaveChanges();


    //Console.WriteLine("Silindi cano, gitti alayı");


    #endregion

    #region One to Many - Shadow Property - Add Data

    //var category = _context.Categories.First();
    //category.Product.Add(new Product() { Name="selam canım",Description="waeae"});
    //_context.SaveChanges();

    //-----
    //var category = new Category() { Name="Dizüstü"};
    //var product = new Product() { Name = "Dizüstü Ürün 1", Stock = 2, Price = 2555.9M, Description = "Açıklama", Category = category };

    ////_context.Add(category); //Bu yazıma gerek yok, product değişkenine category eklendiğinden oto kategori ekliyor. 
    ////_context.Add(product);
    //_context.Products.Add(product);


    //----
    //var category = new Category() { Name = "defterler" };

    //category.Product.Add(new() { Name = "defter1", Stock = 2 });
    //category.Product.Add(new() { Name = "defter2", Stock = 3 });

    //_context.Add(category);
    //_context.SaveChanges();


    //---- Hata ????
    //var category = _context.Categories.First(x=>x.Name== "olmasinmallar");

    //category.Product.Add(new Product() { Name = "Bu nasıl kategori mübarek" ,CategoryId=category.CategoryId});
    //category.Product.Add(new Product() { Name = "Şöyle böyle" , CategoryId = category.CategoryId });

    //_context.Add(category);
    //_context.SaveChanges();

    #endregion

    #region One to  One - Add Data

    // Product => Parent
    //ProductFeature => Childed
    //------
    //Bir tık hoş bir kullanım
    //var product = new Product()
    //{
    //    Name = "urun1",
    //    Price = 2.1M,
    //    Stock = 1,
    //    Barcode = 1234,
    //    Category = new() { Name = "abimebirkategoricek" },
    //    ProductFeature = new() { Width = 100, Height = 100, Color = "Red" }
    //};

    //-----
    //for (int i = 1; i <= 5; i++)
    //{
    //    var category = _context.Categories.First(x => x.Name == "Mouse");
    //    var product = new Product()
    //    {
    //        Name = $"Şekilli Mouse {i}",
    //        Price = 2.1M,
    //        Stock = 1,
    //        Barcode = 1234,
    //        Category = category,
    //        ProductFeature = new() { Width = 100, Height = 100, Color = "Red" }
    //    };
    //    _context.Add(product);
    //}


    //----
    //var category = _context.Categories.First(x => x.Name == "Klavye");
    //var product = new Product()
    //{
    //    Name = $"Şekilli Klavye",
    //    Price = 2.1M,
    //    Stock = 1,
    //    Barcode = 1234,
    //    Category = category
    //};
    //var productFeature = new ProductFeature()
    //{
    //    Color = "HojRenk",
    //    Height = 150,
    //    Width = 25,
    //    Product = product
    //};

    //_context.Add(productFeature);
    //_context.SaveChanges();


    #endregion

    #region Many to Many - Add Data

    //----
    //var student = new Student() { Name = "Öğrenci1", Age = 18 };
    //student.Teachers.Add(new() { Name = "Öğretmen1" });
    //student.Teachers.Add(new() { Name = "Öğretmen2" });


    //var student2 = new Student() { Name = "Öğrenci2", Age = 18 };
    //student.Teachers.Add(_context.Teachers.First(x => x.TeacherId == 1));
    //----

    //var teacher = new Teacher()
    //{
    //    Name = "HocaCamide",
    //    Students = new List<Student>()
    //    {
    //        new Student() { Name = "Teacher üzerinden öğrenci1",Age=19},
    //        new Student() { Name = "Teacher üzerinden öğrenci2",Age=20},
    //        new Student() { Name = "Teacher üzerinden öğrenci3",Age=21}
    //    }
    //};

    //var teacher = new Teacher() { Name="Ahmet"};
    //var teacher = _context.Teachers.First(x => x.Name == "Ahmet");
    //teacher.Students.AddRange(new[]
    //{
    //    new Student() { Name = "Mustafa", Age = 25 },
    //    new Student() { Name = "Yusuf", Age = 25 }
    //});

    //_context.SaveChanges();

    //Console.WriteLine("Kaydedildi");

    #endregion

    #region Delete Behaviors

    #region Add Data
    //var category = new Category()
    //{
    //    Name = "Kalemler",
    //    Products = new List<Product>() {
    //    new Product()
    //    {
    //        Name="Kalem1",
    //        Price=1.1M,
    //        Barcode=1234,
    //        Stock=1234
    //    },
    //    new Product(){
    //        Name="Kalem2",
    //        Price=2.2M,
    //        Barcode=2234,
    //        Stock=2234
    //    }
    //    }
    //};

    //_context.Add(category);
    //_context.SaveChanges();
    #endregion

    //// Delete Category
    //var category = _context.Categories.First(x => x.Name == "Kalemler");
    //_context.Categories.Remove(category);
    //_context.SaveChanges();
    //Console.WriteLine($"{category.Name} Silindi");

    // Delete Products
    //var category = _context.Categories.First();
    //var products = _context.Products.Where(x => x.CategoryId == category.CategoryId).ToList();

    //_context.Products.RemoveRange(products);
    //_context.SaveChanges();

    // Delete Categories to Restrict
    //var category = _context.Categories.First();
    //var products = _context.Products.Where(x => x.CategoryId == category.CategoryId).ToList();

    //_context.Products.RemoveRange(products);
    //_context.Categories.Remove(category);
    //_context.SaveChanges();

    //


    #endregion

    #region Database Generated Attribute
    //_context.Products.Add(new Product()
    //{
    //    Name = "Urun1",
    //    Barcode = 1234,
    //    Price = 2.1M,
    //    Kdv = 4
    //});
    //_context.SaveChanges(); 
    #endregion

}
