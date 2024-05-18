// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using SE183491ConsoleEFApp.DAO;
using SE183491ConsoleEFApp.Models;

Console.WriteLine("Hello, World!");


OrderItemDAO orderItemDAO = new OrderItemDAO();
orderItemDAO.DisplayOrderItems();
//orderItemDAO.AddOrderItem(new OrderItem { OrderId = 1, ProductId = 1, Quantity = 1, Price = 100 });
//orderItemDAO.DisplayOrderItems();
