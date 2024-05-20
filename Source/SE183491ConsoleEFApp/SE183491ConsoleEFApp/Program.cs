// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using SE183491ConsoleEFApp.DAO;
using SE183491ConsoleEFApp.Models;

Console.WriteLine("Hello, World!");


OrderItemDAO orderItemDAO = new OrderItemDAO();
orderItemDAO.DisplayOrderItems();

OrderItem test = new OrderItem { OrderId = 1, ProductId = 1, Quantity = 1, Price = 100 };
orderItemDAO.AddOrderItem(test);
orderItemDAO.DisplayOrderItems();

test.Quantity = 2;
orderItemDAO.UpdateOrderItem(test);
orderItemDAO.DisplayOrderItems();

orderItemDAO.FindOrderItemById(1);


orderItemDAO.RemoveOrderItem(test);
orderItemDAO.DisplayOrderItems();



//orderItemDAO.AddOrderItem(new OrderItem { OrderId = 1, ProductId = 1, Quantity = 1, Price = 100 });
//orderItemDAO.DisplayOrderItems();
