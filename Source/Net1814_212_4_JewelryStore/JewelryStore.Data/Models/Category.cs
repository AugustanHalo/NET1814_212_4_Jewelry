﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace JewelryStore.Data.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; }

    public virtual ICollection<SiProduct> SiProducts { get; set; } = new List<SiProduct>();
}