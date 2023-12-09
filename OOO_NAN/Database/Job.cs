using System;
using System.Collections.Generic;

namespace OOO_NAN.Database;

public partial class Job
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
