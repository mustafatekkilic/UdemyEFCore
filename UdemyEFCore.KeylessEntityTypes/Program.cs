using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using UdemyEFCore.KeylessEntityTypes.DAL;
using UdemyEFCore.KeylessEntityTypes.Entity;

using (var _context = new AppDbContext())
{
    #region Add Data
    //var category = new Category() { Name = "Bilgisayarlar" };
    //category.Products.Add(new Product()
    //{
    //    Name = "Bilgisayar1",
    //    Barcode = "1234",
    //    Price = 1.100M,
    //    Stock = 1,
    //    ProductFeatures = new ProductFeatures()
    //    {
    //        Color = "Aqua",
    //        Height = 20,
    //        Width = 20
    //    }
    //});

    //category.Products.Add(new Product()
    //{
    //    Name = "Bilgisayar2",
    //    Barcode = "12345",
    //    Price = 2.200M,
    //    Stock = 2,
    //    ProductFeatures = new ProductFeatures()
    //    {
    //        Color = "Blue",
    //        Height = 20,
    //        Width = 20
    //    }
    //});

    //_context.Categories.Add(category);
    //_context.SaveChanges();

    #endregion

    var people = _context.People.ToList();

    var productFulls = _context.ProductFulls.FromSqlRaw(@"select p.Id as 'Product_Id',C.Name as 'CategoryName',P.Name as 'ProductName',p.Price,PF.Color,PF.Height,PF.Width from Products P
JOIN ProductFeatures PF on P.Id=PF.id 
JOIN Categories C on C.id=P.CategoryId").ToList();

    Debugger.Break();
}