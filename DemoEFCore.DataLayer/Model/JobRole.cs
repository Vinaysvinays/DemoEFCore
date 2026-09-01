using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DemoEFCore.DataLayer.Model;

public partial class JobRole
{
    [Key]
    public int JobRoleNo { get; set; }

    public Guid JobRoleId { get; set; }

    public int EmpNo { get; set; }

    public string JobRoleName { get; set; } = null!;

    public virtual Employee EmpNoNavigation { get; set; } = null!;
}
