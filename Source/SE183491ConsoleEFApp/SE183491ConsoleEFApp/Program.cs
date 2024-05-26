// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using SE183491ConsoleEFApp.DAO;
using SE183491ConsoleEFApp.Models;

Console.WriteLine("Hello, World!");


OrderItemDAO orderItemDAO = new OrderItemDAO();
orderItemDAO.DisplayOrderItems();
OrderItem test = new OrderItem { OrderItemId = 6, OrderId = 1001, ProductId = 102, Quantity = 4, Price = 200 };
test.Subtotal = test.Quantity * test.Price;
orderItemDAO.Update(test);
orderItemDAO.DisplayOrderItems();
//Console.WriteLine("Order Items: ");
//orderItemDAO.DisplayOrderItems();
//Console.WriteLine("");


//OrderItem test = new OrderItem {OrderItemId =6 ,OrderId = 1001, ProductId = 102, Quantity = 4, Price = 200 };
//test.Subtotal = test.Quantity * test.Price;
//orderItemDAO.AddOrderItem(test);
//orderItemDAO.DisplayOrderItems();
//Console.WriteLine("");

//test.Quantity = 2;
//orderItemDAO.UpdateOrderItem(test);
//orderItemDAO.DisplayOrderItems();
//Console.WriteLine("");

//orderItemDAO.FindOrderItemById(1);
//Console.WriteLine("");


//orderItemDAO.RemoveOrderItem(test);
//orderItemDAO.DisplayOrderItems();

