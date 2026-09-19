using System;
using System.Collections.Generic;

namespace LocalShopDataAccessLayer.Models;

public partial class OrderProduct
{
    public int OrderProductId { get; set; }

    public int ProductId { get; set; }

    public int OrderId { get; set; }

    public int ProductAmount { get; set; }

    public int TotalPrice { get; set; }

    public int PersonId { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Person Person { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
