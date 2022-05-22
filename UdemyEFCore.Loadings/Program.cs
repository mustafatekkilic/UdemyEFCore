
using Microsoft.EntityFrameworkCore;
using UdemyEFCore.Loadings.DAL;
using UdemyEFCore.Loadings.Entity;

using (var _context = new AppDbContext())
{
    #region Add Data
    ////var category = new Category() { Name = "Silgiler" };
    //var category = _context.Category.First(x => x.Name == "Silgiler");
    //var products = new Product()
    //{
    //    Name = "Silgi2",
    //    Stock = 3,
    //    Barcode = "1234",
    //    ProductFeatures = new ProductFeatures()
    //    {
    //        Color = "Blue",
    //        Height = 20,
    //        Width = 20
    //    },
    //    Category = category
    //};
    //await _context.Product.AddAsync(products);
    ////await _context.AddAsync(products);
    //await _context.SaveChangesAsync();

    #endregion

    #region Eeager Loading
    //var categoryWithProducts = _context.Category.Include(x => x.Product).ThenInclude(x => x.ProductFeatures).First();

    //categoryWithProducts.Product.ForEach(x =>
    //{

    //    Console.WriteLine($"Kategori adı : {x.Category.Name} - Ürün adı {x.Name} - Genişlik : {x.ProductFeatures.Width}");
    //});

    //Console.WriteLine("----------");

    //var products = _context.Product.Include(x => x.ProductFeatures).Include(x => x.Category).ToList(); //ToList(); Yerine First(); ile ilk datayı çekeriz, list almayız --
    //                                                                                                   //where yapısı ile istenen de alınabilir kaffaya göre

    //products.ForEach(x =>
    //{
    //    Console.WriteLine($" Kategori Adı : {x.Category.Name} - Ürün adı {x.Name}");
    //});
    #endregion

    #region Explicit Loading 

    #region Example 1 
    //var category = _context.Category.First();

    //if (true)
    //{
    //    _context.Entry(category).Collection(item => item.Product).Load();

    //    category.Product.ForEach(item =>
    //    {
    //        Console.WriteLine(item.Name);
    //    });
    //}
    #endregion

    #region Example 2
    //var product = _context.Product.First();

    //if (true)
    //{
    //    _context.Entry(product).Reference(item => item.ProductFeatures).Load();
    //    Console.WriteLine(product.ProductFeatures.Color);
    //}
    #endregion

    #endregion

    #region Lazy Loading

    var category = await _context.Category.FirstAsync();

    Console.WriteLine(category.Name);

    category.Product.ForEach(item =>
    {
        Console.WriteLine($"{item.Name}\n\n");
        // N+1 problemi - her değer atamada veritabanına istek atıyor
        var productColor = item.ProductFeatures.Color;
        Console.WriteLine($"{productColor}\n\n");
    });

    #endregion
}