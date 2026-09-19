using System;
using System.Collections.Generic;

namespace LocalShopDataAccessLayer.Models;

public partial class ProductsImage
{
    public int ImageId { get; set; }

    public string ImagePath { get; set; } = null!;

    public int ProductId { get; set; }

    public int ImageOrder { get; set; }

    public virtual Product Product { get; set; } = null!;
}
