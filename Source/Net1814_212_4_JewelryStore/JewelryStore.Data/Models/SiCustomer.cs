﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace JewelryStore.Data.Models;

public partial class SiCustomer
{
    public int CustomerId { get; set; }

    public string Name { get; set; }

    public string Phone { get; set; }

    public string Address { get; set; }

    public virtual ICollection<SiOrder> SiOrders { get; set; } = new List<SiOrder>();
}