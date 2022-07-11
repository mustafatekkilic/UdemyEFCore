using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using UdemyEFCore.StoredProcedure_Function.DAL;
using UdemyEFCore.StoredProcedure_Function.DTO;
using UdemyEFCore.StoredProcedure_Function.Entity;

using (var _context = new AppDbContext())
{

    #region Add Data - Category
    //_context.Category.Add(new Category()
    //{
    //    Name = "Kitaplar"
    //});
    //_context.SaveChanges();
    #endregion

    #region Add Data - Product
    //var category = _context.Category.Where(x => x.Name == "Kitaplar").First();
    //int i = 0;
    //while (i <= 20)
    //{
    //    _context.Product.Add(new()
    //    {
    //        Name = $"Kitaplar {i + 1}",
    //        Barcode = 1234,
    //        Stock = 1234,
    //        Url = "kitapex.com",
    //        Price=150,
    //        ProductFeatures = new ProductFeatures()
    //        {
    //            Color = "Green",
    //            Width = 20,
    //            Height = 20
    //        },
    //        Category = category
    //    });
    //    i++;
    //    //Debugger.Break();
    //}
    //_context.SaveChanges();
    #endregion

    #region StoredProcedure

    //    //var products = await _context.Product.FromSqlRaw("exec sp_get_products").ToListAsync();
    //    //var productsFull = await _context.ProductFull.FromSqlRaw("exec sp_get_products_full").ToListAsync();
    //    var productsFullWithParams = await _context.ProductFull.FromSqlRaw($"exec sp_get_products_full_params {5},{100}").ToListAsync();

    //    var product = new Product()
    //    {
    //        Name = "Güzeliş",
    //        Price = 1450,
    //        DiscountPrice = 1250,
    //        Stock = 1,
    //        Barcode = 1234,
    //        CategoryId = 5
    //    };
    //    var newProductIdParameter = new SqlParameter("@newId", System.Data.SqlDbType.Int);
    //    newProductIdParameter.Direction = System.Data.ParameterDirection.Output;

    //    await _context.Database.ExecuteSqlInterpolatedAsync(@$"sp_insert_product 
    //{product.Name},{product.Price},{product.DiscountPrice},{product.Stock},{product.Barcode},{product.CategoryId},{newProductIdParameter} output");

    //    var newProductId = newProductIdParameter.Value;

    //    Debugger.Break();
    #endregion

    #region SqlFunctions
    //var products = _context.ProductFull.ToList();
    //var productsWithFeatures = _context.ProductWithFeatures.FromSqlInterpolated($"select * from fc_productFeatures_full_with_params(5)").ToList();
    //var products = _context.GetProductWithFeatures(6).ToList();


    //var categories = _context.Category.Select(x => new
    //{
    //    CategoryName = x.Name,
    //    ProductCount = _context.GetProductCount(x.Id)
    //}).ToList();
    //var count = _context.GetProductCount(6);//Hata alıyor, kullanılamıyor bu şekilde
    ////Console.WriteLine(categories[0].);
    //Debugger.Break();
    #endregion


}
