using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using UdemyEFCore.Transaction.DAL;
using UdemyEFCore.Transaction.DTO;
using UdemyEFCore.Transaction.Entity;

DbContextInitializer.Build();



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

    //ExampleCode
    //var category = _context.Category.Where(x => x.Name == "Defterler").First();
    //int i = 0;
    //while (i <= 3)
    //{
    //    addProducts+++++
    //}
    //Hatalı ürün ekleme kodu
    // gibi bir yapıda tek _context.SaveChanges(); kullandığın için hatalı bir durum ile karşılırsa başarılı işlerde iptal olacak,
    // database e yansımayacaktır.
    //_context.SaveChanges();

    #region Transaction Scope suz kullanım - savechanges sonrası geri dönüş yok
    //var category = new Category() { Name = "Kılıflar" };

    //_context.Category.Add(category);
    //_context.SaveChanges();

    //Product product = new Product()
    //{
    //    Name = $"Kılıf {1}",
    //    Barcode = "1234",
    //    Stock = 1234,
    //    Url = "kilifex.com",
    //    ProductFeatures = new ProductFeatures()
    //    {
    //        Color = "Green",
    //        Width = 20,
    //        Height = 20
    //    },
    //    CategoryId = category.Id
    //};

    //_context.SaveChanges();
    #endregion


    #region Transaction Scope Kullanım 
    using (var transaction = _context.Database.BeginTransaction())
    {
        try
        {
            var category = new Category() { Name = "Marka Kılıflar" };

            _context.Category.Add(category);

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
                CategoryId = 10
            };
            _context.SaveChanges();

            transaction.Commit();
        }
        catch (Exception)
        {

            transaction.Rollback();
            Console.WriteLine("Hata");
        }

    }
    #endregion


    Debugger.Break();
}


