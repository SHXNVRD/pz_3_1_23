using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace OOO_NAN.Model;

public partial class Job
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<Employe> Employes { get; set; } = new List<Employe>();
}
