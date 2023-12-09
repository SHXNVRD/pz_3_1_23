using System;
using System.Collections.Generic;

namespace OOO_NAN.Database;

public partial class EmployeesAudit
{
    public int AuditId { get; set; }

    public int? EmployeeId { get; set; }

    public string EmployeeName { get; set; } = null!;

    public int? EmployeeJob { get; set; }

    public decimal? MonthSalary { get; set; }

    public string? EmployeePhone { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? Operation { get; set; }
}
