using SE183491ConsoleEFApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE183491ConsoleEFApp.DAO
{
    internal class OrderItemDAO
    {
        public void AddOrderItem(OrderItem orderItem)
        {
            using (var _context = new NET1814_212_4_JewelryStoreContext(new Microsoft.EntityFrameworkCore.DbContextOptions<NET1814_212_4_JewelryStoreContext>()))
            {
                _context.OrderItems.Add(orderItem);
                _context.SaveChanges();
                
            }
        }

        public void RemoveOrderItem(OrderItem orderItem)
        {
            using (var _context = new NET1814_212_4_JewelryStoreContext(new Microsoft.EntityFrameworkCore.DbContextOptions<NET1814_212_4_JewelryStoreContext>()))
            {
                _context.OrderItems.Remove(orderItem);
                _context.SaveChanges();
            }
        }

        public void DisplayOrderItems()
        {
            using (var _context = new NET1814_212_4_JewelryStoreContext(new Microsoft.EntityFrameworkCore.DbContextOptions<NET1814_212_4_JewelryStoreContext>()))
            {
                foreach (var orderItem in _context.OrderItems)
                {
                    Console.WriteLine(orderItem.OrderId + " " + orderItem.ProductId + " " + orderItem.Quantity + " " + orderItem.Price);
                }
            }
        }
    }
}
