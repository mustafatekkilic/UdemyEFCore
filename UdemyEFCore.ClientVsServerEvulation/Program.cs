using System.Diagnostics;
using UdemyEFCore.ClientVsServerEvulation.DAL;
using UdemyEFCore.ClientVsServerEvulation.Entity;

using (var _context = new AppDbContext())
{
    #region Add Data - Products
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

    #region Add Data - Person

    //List<Person> people = new List<Person>() { };
    //people.Add(new Person()
    //{
    //    Name = "Mustafa",
    //    Phone = "05555555555"
    //});
    //people.Add(new Person
    //{
    //    Name = "Onur",
    //    Phone = "04444444444"
    //});

    //_context.People.AddRangeAsync(people);
    //_context.SaveChanges(); 


    #endregion

    //var person = _context.People.ToList().Where(x => FormatPhone(x.Phone) == "4444444444");
    //Formatlı bir şekilde alacaksak eğer
    var person = _context.People.ToList().Where(x => FormatPhone(x.Phone) == "4444444444").Select(x => new
    {
        PersonName = x.Name,
        PersonsadadasdPhone = FormatPhone(x.Phone)
    });

    Debugger.Break();

}

string FormatPhone(string phone)
{
    return phone.Substring(1, phone.Length - 1);
}