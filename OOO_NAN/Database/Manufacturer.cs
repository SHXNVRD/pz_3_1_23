using System;
using System.Collections.Generic;

namespace OOO_NAN.Database;

public partial class Manufacturer
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Delivery> Deliveries { get; set; } = new List<Delivery>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
