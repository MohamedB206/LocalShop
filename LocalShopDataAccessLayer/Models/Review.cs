using System;
using System.Collections.Generic;

namespace LocalShopDataAccessLayer.Models;

public partial class Review
{
    public int ReviewId { get; set; }

    public int ProductId { get; set; }

    public int OrderId { get; set; }

    public int PersonId { get; set; }

    public int Rateing { get; set; }

    public string ReviewText { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;

    public virtual Person Person { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
