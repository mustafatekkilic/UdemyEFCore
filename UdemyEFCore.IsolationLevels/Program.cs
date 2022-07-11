using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System.Data.Common;
using System.Diagnostics;
using UdemyEFCore.IsolationLevels.DAL;
using UdemyEFCore.IsolationLevels.DTO;
using UdemyEFCore.IsolationLevels.Entity;


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

    /*SQL Codes
    set transaction isolation level read uncommitted
    begin transaction MyTransaction
    Begin try
    select * from Product
    commit transaction MyTransaction
    print 'transaction success'
    end try
    begin catch
    rollback transaction MyTransaction
    print 'transaction fail'
    end catch
     */

    //Anlaşılan; veritabanına atılan istek sonucu çıkacak sonucu okur, işlem daha gerçekleşmediğinden select * from gibi base
    //sorguda data değişikliği gözlenmez. Commit - işlemek, Uncommitted - İşlenmemiş
    using (var transaction = _context.Database.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted))
    {
        var product = _context.Product.First();
        product.Price = 3000;
        _context.SaveChanges();

        transaction.Commit();
    }
}



