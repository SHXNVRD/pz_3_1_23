using System;
using System.Collections.Generic;

namespace pz_3_1_23;

public partial class Order
{
    public int Id { get; set; }

    public int? DeliveryMethodId { get; set; }

    public int? EmployeId { get; set; }

    public int? ClientId { get; set; }

    public int? ProductId { get; set; }

    public DateTime Date { get; set; }

    public decimal Price { get; set; }

    public int StatusId { get; set; }

    public virtual Client? Client { get; set; }

    public virtual DeliveryMethod? DeliveryMethod { get; set; }

    public virtual Employe? Employe { get; set; }

    public virtual Product? Product { get; set; }

    public virtual Status Status { get; set; } = null!;
}
