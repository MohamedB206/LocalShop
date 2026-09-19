using System;
using System.Collections.Generic;

namespace LocalShopDataAccessLayer.Models;

public partial class Address
{
    public int AddressId { get; set; }

    public int CountryId { get; set; }

    public string City { get; set; } = null!;

    public string Street { get; set; } = null!;

    public int Phone { get; set; }

    public string Zipcode { get; set; } = null!;

    public int PersonId { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Person Person { get; set; } = null!;
}
