using SE183491ConsoleEFApp.Models;
using SE183491OConsoleEFApp.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE183491ConsoleEFApp.DAO
{
    public class OrderItemDAO : BaseDAO<OrderItem>
    {
        public OrderItemDAO()
        {
            
        }
        public void AddOrderItem(OrderItem orderItem)
        {
            if(orderItem != _context.OrderItems.Find(orderItem.OrderItemId))
            {
                _context.OrderItems.Add(orderItem);
                _context.SaveChanges();
                
            }
        }

        public void RemoveOrderItem(OrderItem orderItem)
        {
            if (orderItem == _context.OrderItems.Find(orderItem.OrderItemId))

            {
                _context.OrderItems.Remove(orderItem);
                _context.SaveChanges();
            }
        }

        public void UpdateOrderItem(OrderItem orderItem)
        {
            if (orderItem == _context.OrderItems.Find(orderItem.OrderItemId))
            {
                _context.OrderItems.Update(orderItem);
                _context.SaveChanges();
            }
        }

        public void FindOrderItemById(int id)
        {
            {
                var orderItem = _context.OrderItems.Find(id);
                Console.WriteLine(orderItem.OrderId + " " + orderItem.ProductId + " " + orderItem.Quantity + " " + orderItem.Price);
            }
        }

        public void DisplayOrderItems()
        {
            if(GetAll() != null)
            {
                foreach (var orderItem in GetAll())
                {
                    Console.WriteLine(orderItem.OrderItemId+" "+orderItem.OrderId + " " + orderItem.ProductId + " " + orderItem.Quantity + " " + orderItem.Price);
                }
            }
            else
            {
                Console.WriteLine("No Order Items");
            }
        }
    }
}
