using System;
using System.Collections.Generic;

namespace OOO_NAN.Database;

public partial class Client
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Phone { get; set; }

    public string Email { get; set; } = null!;

    public string? Addres { get; set; }

    public string Password { get; set; } = null!;

    public DateTime? DayOfBirth { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
