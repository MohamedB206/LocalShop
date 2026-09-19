using System;
using System.Collections.Generic;

namespace LocalShopDataAccessLayer.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int PersonId { get; set; }

    public DateTime Date { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public int AddressId { get; set; }

    public int TotalPrice { get; set; }

    public virtual Address Address { get; set; } = null!;

    public virtual Person Person { get; set; } = null!;

    public int OrderStatus { get; set; }

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
