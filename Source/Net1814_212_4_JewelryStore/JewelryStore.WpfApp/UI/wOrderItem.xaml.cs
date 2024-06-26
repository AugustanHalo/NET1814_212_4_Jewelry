﻿using JewelryStore.Business;
using JewelryStore.Business.Base;
using JewelryStore.Common;
using JewelryStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace JewelryStore.WpfApp.UI
{
    /// <summary>
    /// Interaction logic for wOrderItem.xaml
    /// </summary>
    public partial class wOrderItem : Window
    {
        private readonly OrderItemBusiness _business;
        public wOrderItem()
        {
            InitializeComponent();
            _business = new OrderItemBusiness();
            GetOrderItemsAsync();
        }


        private async void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OrderItem orderItem = new OrderItem()
                {
                    OrderItemId = Convert.ToInt32(OrderItemID.Text),
                    OrderId = Convert.ToInt32(OrderID.Text),
                    ProductId = Convert.ToInt32(ProductID.Text),
                    Quantity = Convert.ToInt32(Quantity.Text),
                    Price = Convert.ToInt32(Price.Text),
                    Subtotal = Convert.ToInt32(Quantity.Text) * Convert.ToInt32(Price.Text)
                };
                var existingOrderItem = await _business.GetById(orderItem.OrderItemId);

                if (existingOrderItem.Data as OrderItem == null)
                {
                    var result = await _business.Save(orderItem);
                    MessageBox.Show(result.Message, "Save");

                    OrderItemID.Text = string.Empty;
                    OrderID.Text = string.Empty;
                    ProductID.Text = string.Empty;
                    Quantity.Text = string.Empty;
                    Price.Text = string.Empty;
                    GetOrderItemsAsync();

                }
                else
                {
                    MessageBox.Show("OrderItemID already exists", "Warning");
                    await _business.Update(orderItem);

                    return;
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
            }

        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            OrderItemID.Text = string.Empty;
            OrderID.Text = string.Empty;
            ProductID.Text = string.Empty;
            Quantity.Text = string.Empty;
            Price.Text = string.Empty;
        }
        private async void GetOrderItemsAsync()
        {
            var result = await _business.GetAll();
           

            if (result.Status > 0 && result.Data != null)
            {
                grdOrderItem.ItemsSource = result.Data as List<OrderItem>;
            }
            else
            {
                grdOrderItem.ItemsSource = new List<OrderItem>();
            }
        }
        private async void ButtonSelect_Click(object sender, RoutedEventArgs e)
        {
            OrderItem orderItem = grdOrderItem.SelectedItem as OrderItem;
            if (orderItem != null)
            {
                OrderItemID.Text = orderItem.OrderItemId.ToString();
                OrderID.Text = orderItem.OrderId.ToString();
                ProductID.Text = orderItem.ProductId.ToString();
                Quantity.Text = orderItem.Quantity.ToString();
                Price.Text = orderItem.Price.ToString();
            }
        }

        private async void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            OrderItem orderItem = grdOrderItem.SelectedItem as OrderItem;
            if(orderItem == null)
            {
                MessageBox.Show("OrderItemID not found", "Warning");
                return;
            }

            var result = await _business.DeleteById(orderItem.OrderItemId);
            MessageBox.Show(result.Message, "Delete");
            GetOrderItemsAsync();
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            var existingOrderItem = _business.GetById(Convert.ToInt32(OrderID.Text));
            if (existingOrderItem.Data as OrderItem == null)
            {
                MessageBox.Show("OrderItemID not found", "Warning");
                return;
            }

            existingOrderItem.OrderId = Convert.ToInt32(OrderID.Text);
            existingOrderItem.ProductId = Convert.ToInt32(ProductID.Text);
            existingOrderItem.Quantity = Convert.ToInt32(Quantity.Text);
            existingOrderItem.Price = Convert.ToInt32(Price.Text);
            existingOrderItem.Subtotal = Convert.ToInt32(Quantity.Text) * Convert.ToInt32(Price.Text);
             _business.Update(existingOrderItem);
            GetOrderItemsAsync();
        }
    }
}
