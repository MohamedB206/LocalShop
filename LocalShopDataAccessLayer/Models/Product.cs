using System;
using System.Collections.Generic;

namespace LocalShopDataAccessLayer.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public int Amount { get; set; }

    public int Price { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<ProductsImage> ProductsImages { get; set; } = new List<ProductsImage>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
