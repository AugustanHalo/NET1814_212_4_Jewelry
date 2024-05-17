// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using SE183491ConsoleEFApp.Models;

Console.WriteLine("Hello, World!");


var _context = new NET1814_212_4_JewelryStoreContext(new Microsoft.EntityFrameworkCore.DbContextOptions<NET1814_212_4_JewelryStoreContext>());
var customerAccounts = _context.SiCustomers.ToArray();

foreach (var customer in customerAccounts)
{
    Console.WriteLine(customer.CustomerId  + customer.Name);
}