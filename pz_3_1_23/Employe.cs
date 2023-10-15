using System;
using System.Collections.Generic;

namespace pz_3_1_23;

public partial class Employe
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? JobId { get; set; }

    public decimal Salary { get; set; }

    public string Phone { get; set; } = null!;

    public virtual Job? Job { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
