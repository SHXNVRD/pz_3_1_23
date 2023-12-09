using System;
using System.Collections.Generic;

namespace OOO_NAN.Database;

public partial class Product
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public decimal Price { get; set; }

    public string? Description { get; set; }

    public int CategoriesId { get; set; }

    public int Count { get; set; }

    public int ManufacturersId { get; set; }

    public virtual Category Categories { get; set; } = null!;

    public virtual ICollection<Delivery> Deliveries { get; set; } = new List<Delivery>();

    public virtual Manufacturer Manufacturers { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
