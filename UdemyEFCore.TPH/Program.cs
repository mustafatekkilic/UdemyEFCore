
using UdemyEFCore.TPH.DAL;
using UdemyEFCore.TPH.Entity;

DbContextInitializer.Build();
using (var _context = new AppDbContext())
{
    //DbContext altına BasePerson class ı ekledik, tek tablo içinde kayıtları ayıran bir alan oluşturdu.
    //Sütunu entity adı olan Employee, Manager ile doldurarak ayırt edici özellik sağladı.

    #region Add Data
    //_context.Persons.Add(new Manager()
    //{
    //    FirstName = "Mustafa",
    //    LastName = "T.",
    //    Age =18,   
    //    Grade = 99
    //});
    //_context.Persons.Add(new Employee()
    //{
    //    FirstName="Yusuf",
    //    LastName="Ç.",
    //    Age=55,
    //    Salary=3
    //});

    //_context.SaveChanges();
    #endregion

    var persons = _context.Persons.ToList();
    var managers = _context.Managers.ToList();
    var employes = _context.Employees.ToList();

    persons.ForEach(person =>
    {
        switch (person)
        {
            case Manager manager:
                Console.WriteLine($"{manager.FirstName} {manager.Grade}");
                break;

            case Employee employee:
                Console.WriteLine($"{employee.FirstName} {employee.Salary}");
                break;
        }
    });


}