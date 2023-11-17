using System;
using System.Collections.Generic;

namespace OOO_NAN.Model;

public partial class History
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public string Operation { get; set; } = null!;

    public DateTime CreateAt { get; set; }
}
