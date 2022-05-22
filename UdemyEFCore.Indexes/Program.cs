using UdemyEFCore.Indexes.DAL;

using (var _context = new AppDbContext())
{
    //Sorgu index almadığın bir alanı eklersen index yapısında olmadığından ana kaynağa gidip alacak, kazanılan hız yavaşlayacak
    //_context.Product.Where(x => x.Name == "kalem1").Select(x => new
    //{
    //    x.Price,
    //    x.Stock,
    //    x.Barcode
    //});
    try
    {
        _context.Product.Add(new()
        {
            Name = "Ürün1",
            Barcode = "1234",
            Price = 1.3M,
            DiscountPrice = 1.2M,
            Stock = 123,
            Url = "https:\\www.BaseUrl.com"
        });
        _context.SaveChanges();
    }
    catch (Exception e)
    {

        Console.WriteLine(e);
    }

}