using System;
using System.Collections.Generic;

namespace OOO_NAN.Database;

public partial class Delivery
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int ProductCount { get; set; }

    public DateTime Date { get; set; }

    public int? ManufacturersId { get; set; }

    public virtual Manufacturer? Manufacturers { get; set; }

    public virtual Product Product { get; set; } = null!;
}
