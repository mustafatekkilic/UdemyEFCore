
using System.Diagnostics;
using UdemyEFCore.TPT.DAL;
using UdemyEFCore.TPT.Entity;

DbContextInitializer.Build();
using (var _context = new AppDbContext())
{

    #region Add Data
    //_context.Managers.Add(new Manager()
    //{
    //    FirstName ="Mustafa",
    //    LastName = "Tek.",
    //    Age =25,
    //    Grade =99
    //});
    //_context.Employees.Add(new Employee()
    //{
    //    FirstName = "Alp",
    //    LastName = "Arsl.",
    //    Age = 25,
    //    Salary = 10000
    //});
    //Farkmaz BaseProp dan da eklemeni yapabilirsin. Zaten eklerken tür belirtiyon
    //_context.Persons.Add(new Employee()
    //{
    //    FirstName = "Alp",
    //    LastName = "Arsl.",
    //    Age = 25,
    //    Salary = 10000
    //});
    //_context.SaveChanges();
    #endregion

    #region Read Data
    var persons = _context.Persons.ToList();
    var managers = _context.Managers.ToList();
    var employes = _context.Employees.ToList();
    Debugger.Break();

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
    #endregion
}