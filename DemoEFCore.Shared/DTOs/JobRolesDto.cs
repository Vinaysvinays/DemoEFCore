using System;
using System.Collections.Generic;
using System.Text;

namespace DemoEFCore.Shared.DTOs;

public  class JobRolesDto
{
    public Guid Id { get; set; }
    public string JobRoleName { get; set; } = string.Empty;
}
