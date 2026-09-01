using System;
using System.Collections.Generic;

namespace DemoEFCore.DataLayer.Model;

public partial class Employee
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Department { get; set; }

    public decimal Salary { get; set; }
}
