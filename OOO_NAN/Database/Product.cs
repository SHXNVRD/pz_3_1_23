using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace OOO_NAN.Model;

public partial class Product
{   
    public int Id { get; set; }

    public string? Title { get; set; }

    public decimal Price { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Consignment> Consignments { get; set; } = new List<Consignment>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
