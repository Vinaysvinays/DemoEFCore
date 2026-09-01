using System;
using System.Collections.Generic;
using System.Text;

namespace DemoEFCore.Shared.DTOs;

public class EmployeeDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? Department { get; set; }
    public decimal Salary { get; set; }
}
