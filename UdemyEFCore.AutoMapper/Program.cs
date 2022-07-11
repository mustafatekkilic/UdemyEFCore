using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using UdemyEFCore.AutoMapper.DAL;
using UdemyEFCore.AutoMapper.DTO;
using UdemyEFCore.AutoMapper.Entity;
using UdemyEFCore.AutoMapper.Mappers;

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

    ////Tüm data yı çeker, sonra dto mapler. Yüksek boyutlu data lar için problem çıkaracak bir durum 
    //var product = _context.Product.ToList();
    //var productDto = ObjectMapper.mapper.Map<List<ProductDto>>(product);

    //Datayı çekerken dto proplarına mapler
    var productDto = _context.Product.ProjectTo<ProductDto>(ObjectMapper.mapper.ConfigurationProvider).ToList();

    Debugger.Break();
}


