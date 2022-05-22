using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using UdemyEFCore.Queries.DAL;
using UdemyEFCore.Queries.Entity;

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
    //var category = _context.Category.Where(x=>x.Name== "Defterler").First();
    //int i = 0;
    //while (i <= 3)
    //{
    //    _context.Product.Add(new()
    //    {
    //        Name = $"Defterler {i+1}",
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

    #region Inner Join

    #region Yol 1 
    //İkili Join
    //var result = _context.Category.Join(_context.Product,
    //    categoryItem => categoryItem.Id,
    //    productItem => productItem.CategoryId,
    //    (category, product) => new
    //    {
    //        CategoryName=category.Name,
    //        ProductName=product.Name,
    //        ProductPrice=product.Price,
    //        ProductDiscountPrice=product.DiscountPrice
    //    }).ToList();

    //var result2 = _context.Category.Join(_context.Product,
    //    categoryItem => categoryItem.Id,
    //    productItem => productItem.CategoryId,
    //    (category, product) => product).ToList();

    //var result3 = _context.Category.Join(_context.Product,
    //    categoryItem => categoryItem.Id,
    //    productItem => productItem.CategoryId,
    //    (category, product) => category).ToList();    
    #endregion

    ////İkili Join
    //var result = (from category in _context.Category
    //              join product in _context.Product on category.Id equals product.CategoryId
    //              select product).ToList();

    //var result2 = (from category in _context.Category
    //               join product in _context.Product on category.Id equals product.CategoryId
    //               select new
    //               {
    //                   CategoryName = category.Name,
    //                   ProductName = product.Name,
    //                   ProductDiscountPrice = product.DiscountPrice
    //               }).ToList();


    ////Üçlü Join
    //var result3 = (from category in _context.Category
    //               join product in _context.Product on category.Id equals product.CategoryId
    //               join productFeatures in _context.ProductFeatures on product.Id equals productFeatures.Id
    //               select new
    //               {
    //                   CategoryName = category.Name,
    //                   ProductName = product.Name,
    //                   ProductDiscountPrice = product.DiscountPrice,
    //                   Color = productFeatures.Color
    //               }).ToList();

    //var result4 = _context.Category.Join(_context.Product,
    //    categoryItem => categoryItem.Id,
    //    productItem => productItem.CategoryId,
    //    (category, product) => new { category, product }).
    //    Join(_context.ProductFeatures, product => product.product.Id, productFeatures => productFeatures.Id, (category, productFeatures) => new
    //    {
    //        CategoryName = category.category.Name,
    //        ProductName = category.product.Name,
    //        ProductPrice = category.product.Price,
    //        ProductDiscountPrice = category.product.DiscountPrice,
    //        Color = productFeatures.Color
    //    }
    //    ).ToList();

    #endregion

    #region Left/Right Join
    //var result = await (from product in _context.Product
    //                    join productFeatures in _context.ProductFeatures on product.Id equals productFeatures.Id into pflist
    //                    from productFeatures in pflist.DefaultIfEmpty()
    //                    select new
    //                    {
    //                        product
    //                    }).ToListAsync();

    //var result2 = await (from product in _context.Product
    //                     join productFeatures in _context.ProductFeatures on product.Id equals productFeatures.Id into pflist
    //                     from productFeatures in pflist.DefaultIfEmpty()
    //                     select new
    //                     {
    //                         product,
    //                         productFeatures
    //                     }).ToListAsync();

    //var leftJoin = await (from product in _context.Product
    //                      join productFeatures in _context.ProductFeatures on product.Id equals productFeatures.Id into pflist
    //                      from productFeatures in pflist.DefaultIfEmpty()
    //                      select new
    //                      {
    //                          ProductName = product.Name,
    //                          ProductColor = productFeatures.Color,
    //                          ProductWidth = (int?)productFeatures.Width == null ? 5 : productFeatures.Width
    //                      }).ToListAsync();
    ////Ufak bir çakallıkla rightJoin, yoksa sql sorgusu yine left join
    //var rightJoin = await (from productFeatures in _context.ProductFeatures
    //                       join product in _context.Product on productFeatures.Id equals product.Id into pflist
    //                       from product in pflist.DefaultIfEmpty()
    //                       select new
    //                       {
    //                           ProductName = product.Name,
    //                           ProductColor = productFeatures.Color,
    //                           ProductWidth = (int?)productFeatures.Width == null ? 5 : productFeatures.Width
    //                       }).ToListAsync();

    #endregion

    #region OuterJoin
    //var left = await (from product in _context.Product
    //                  join productFeatures in _context.ProductFeatures on product.Id equals productFeatures.Id into pflist
    //                  from productFeatures in pflist.DefaultIfEmpty()
    //                  select new
    //                  {
    //                      Id = product.Id,
    //                      Name = product.Name,
    //                      Color = productFeatures.Color
    //                  }).ToListAsync();

    //var right = await (from productFeatures in _context.ProductFeatures
    //                   join product in _context.Product on productFeatures.Id equals product.Id into pflist
    //                   from product in pflist.DefaultIfEmpty()
    //                   select new
    //                   {
    //                       Id = product.Id,
    //                       Name = product.Name,
    //                       Color = productFeatures.Color
    //                   }).ToListAsync();

    //var outerJoin = left.Union(right);

    //outerJoin.ToList().ForEach(item =>
    //{
    //    Console.WriteLine($"{item.Id} {item.Name} {item.Color} ");
    //});

    #endregion

    #region RawSQL


    #region RawSQL - 1

    //var id = 5;

    //decimal price = 300;

    //var productList = await _context.Product.FromSqlRaw("select * from product").ToListAsync();

    //var products1 = await _context.Product.FromSqlRaw($"select * from product where id={id}").FirstAsync();
    //var products2 = await _context.Product.FromSqlRaw("select * from product where id={0}",id).FirstAsync();
    //var products3= await _context.Product.FromSqlRaw($"select * from product where Price<={price}").ToListAsync();

    #endregion

    #region RawSQL -2 

    //var productList = await _context.ProductEssentials.FromSqlRaw("select Id,Name,Price from product").ToListAsync();
    //var productList = await _context.ProductEssentials.FromSqlRaw("select Name,Price from product").ToListAsync(); //modelbuilder add hasnokey to essentials id

    //var productWithFeature = await _context.ProductEssentials.FromSqlRaw(@"select p.Id,p.Name,p.Price,pf.Color,pf.Height from Product p inner join ProductFeatures pf on p.Id=pf.id").ToListAsync();
    #endregion

    #endregion

    #region ToSql - modelBuilder.Entity<ProductEssential>().HasNoKey().ToSqlQuery("select Id,Name,Price from product");
    //var products = _context.ProductEssentials.ToList();
    //var product = await _context.ProductEssentials.Where(x=>x.Id==5).FirstAsync();

    #endregion

    #region ToView - productWithFeatures

    //var products = _context.ProductFull.ToList();

    #endregion

    GetProducts(2, 6).ForEach(item =>
    {
        Console.WriteLine(item.Name);
    });

    //Debugger.Break();
}

List<Product> GetProducts(int page, int pageSize)
{
    using (var _context = new AppDbContext())
    {
        return _context.Product.OrderByDescending(x => x.Id).Skip((page - 1) * pageSize).Take(pageSize).ToList();
    }

}


//Example
//namespace UdemyEFCore.Queries
//{
//    class Pogram
//    {

//        public class A
//        {
//            public int I { get; set; }
//        }

//        public class B
//        {
//            public int I { get; set; }
//        }

//        static void Main(string[] args)
//        {

//            A a = new A() { I = 1 };
//            B b = new B() { I = 2 };

//            a.I = b.I;

//            b.I = 4;

//            Console.WriteLine($"A.I değeri : {a.I} b.I değeri : {b.I}");


//        }
//    }
//}