using System;
using System.Collections.Generic;

namespace OOO_NAN.Model;

public partial class Consignment
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public int? PoductId { get; set; }

    public virtual Product? Poduct { get; set; }
}
