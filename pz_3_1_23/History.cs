using System;
using System.Collections.Generic;

namespace pz_3_1_23;

public partial class History
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public string Operation { get; set; } = null!;

    public DateTime CreateAt { get; set; }
}
