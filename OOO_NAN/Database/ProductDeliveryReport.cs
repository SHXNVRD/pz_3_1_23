using System;
using System.Collections.Generic;

namespace OOO_NAN.Database;

public partial class ProductDeliveryReport
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public string ManufacturerName { get; set; } = null!;

    public string CategoryName { get; set; } = null!;

    public DateTime DeliveryDate { get; set; }

    public int ProductCount { get; set; }
}
