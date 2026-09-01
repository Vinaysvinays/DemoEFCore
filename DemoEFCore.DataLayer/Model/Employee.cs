using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DemoEFCore.DataLayer.Model;

public partial class Employee
{
    [Key]
    public int EmpNo { get; set; }

    public Guid EmpId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Department { get; set; }

    public decimal Salary { get; set; }

    public virtual ICollection<JobRole> JobRoles { get; set; } = new List<JobRole>();
}
