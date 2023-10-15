using System;
using System.Collections.Generic;

namespace pz_3_1_23;

public partial class Product
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public decimal Price { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Consignment> Consignments { get; set; } = new List<Consignment>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
