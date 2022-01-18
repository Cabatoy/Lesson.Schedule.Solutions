// See https://aka.ms/new-console-template for more information


using Saas.DataAccess.EntityFrameWorkCore.DbContexts;
using Saas.DataAccess.EntityFrameWorkCore.Models;

GordionDbContext ss = new GordionDbContext();
var id = ss.Company.Add(new Company()
{
    Adress = "deneme adresi",
    Deleted = false,
    Description = "",
    DescriptionThree = "",
    DescriptionTwo = "",
    FullName = "Cahatay Ozdemir Sirket ",
    PhoneNumberOne = "05315241997",
    PhoneNumberTwo = "",
    TaxNumber = "15988816994",
    TaxOffice = "kagithane"
}).Entity.Id;
ss.SaveChanges();
Console.ReadLine();


