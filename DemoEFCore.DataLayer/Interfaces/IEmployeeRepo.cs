using DemoEFCore.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoEFCore.DataLayer.Interfaces;

public interface IEmployeeRepo
{
    Task<List<EmployeeDto>> GetAllEmployeesAsync();

    Task<bool> AddEmployeeAsync(EmployeeDto employeeDto);

    Task<bool> DeleteEmployeeAsync(Guid EmployeeId);
    Task<EmployeeDto> GetEmployeeByIdAsync(Guid EmployeeId);
    Task<bool> UpdateEmployeeAsync(EmployeeDto employeeDto);
}
