using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System.Data.Common;
using System.Diagnostics;
using UdemyEFCore.MultipleDbContext.DAL;
using UdemyEFCore.MultipleDbContext.DTO;
using UdemyEFCore.MultipleDbContext.Entity;

DbContextInitializer.Build();

var connection = new SqlConnection(DbContextInitializer.Configuration.GetConnectionString("SqlCon"));
IDbContextTransaction transaction = null;

//using (var _context = new AppDbContext(connection))
using (var _context = new AppDbContext(connection))
{

    #region Add Data - Category
    _context.Category.Add(new Category()
    {
        Name = "Defterler"
    });
    _context.SaveChanges();
    #endregion

    #region Add Data - Product
    var category = _context.Category.Where(x => x.Name == "Defterler").First();
    int i = 0;
    while (i <= 3)
    {
        _context.Product.Add(new()
        {
            Name = $"Defterler {i + 1}",
            Barcode = "1234",
            Stock = 1234,
            Url = "defterex.com",
            ProductFeatures = new ProductFeatures()
            {
                Color = "Green",
                Width = 20,
                Height = 20
            },
            Category = category
        });
        i++;
    }
    _context.SaveChanges();
    #endregion

    using (transaction = _context.Database.BeginTransaction())
    {
        var category2 = new Category() { Name = "Marka Kılıflar" };

        _context.Category.Add(category2);

        Product product = new Product()
        {
            Name = $"Kılıf {1}",
            Barcode = "1234",
            Stock = 1234,
            Url = "kilifex.com",
            ProductFeatures = new ProductFeatures()
            {
                Color = "Green",
                Width = 20,
                Height = 20
            },
            Category = category2
        };
        _context.SaveChanges();

        using (var _context2 = new AppDbContext(connection))
        {
            _context2.Database.UseTransaction(transaction.GetDbTransaction());

            var product3 = _context2.Product.First();
            product3.Name = "İlk Ürün";
            _context2.SaveChanges();
        }
        transaction.Commit();

    }
}



