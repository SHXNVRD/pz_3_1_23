using System;
using System.Collections.Generic;

namespace OOO_NAN.Model;

public partial class Client
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string? Email { get; set; }

    public string? Addres { get; set; }

    public string? Client_Password { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
