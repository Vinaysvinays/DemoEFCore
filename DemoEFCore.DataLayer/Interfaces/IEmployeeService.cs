using DemoEFCore.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoEFCore.DataLayer.Interfaces;

public interface IEmployeeService
{
    Task<List<EmployeeDto>> GetAllEmployeesAsync();
}
