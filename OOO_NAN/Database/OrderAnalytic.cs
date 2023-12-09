using System;
using System.Collections.Generic;

namespace OOO_NAN.Database;

public partial class OrderAnalytic
{
    public int OrderId { get; set; }

    public string ClientName { get; set; } = null!;

    public string EmployeeName { get; set; } = null!;

    public string? ProductTitle { get; set; }

    public DateTime OrderDate { get; set; }

    public decimal OrderPrice { get; set; }

    public string OrderStatus { get; set; } = null!;
}
