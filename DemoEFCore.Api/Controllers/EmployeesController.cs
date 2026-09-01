using DemoEFCore.DataLayer.Interfaces;
using DemoEFCore.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DemoEFCore.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : Controller
{
    private readonly IEmployeeRepo _employeeService;

    public EmployeesController(IEmployeeRepo employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    public async Task<List<EmployeeDto>> GetAllEmployees()
    {
        var employees = await _employeeService.GetAllEmployeesAsync();
        return employees;
    }
    [HttpPost]
    public async Task<bool> AddEmployee(EmployeeDto employeeDto)
    {
        var result = await _employeeService.AddEmployeeAsync(employeeDto);
        return result;
    }
    [HttpDelete("{id}")]
    public async Task<bool> DeleteEmployee(Guid id)
    {
        var result = await _employeeService.DeleteEmployeeAsync(id);
        return result;
    }

    [HttpGet("{id}")]
    public async Task<EmployeeDto> GetEmployeeById(Guid id)
    {
        var employee = await _employeeService.GetEmployeeByIdAsync(id);
        return employee;
    }

    [HttpPut]
    public async Task<bool> UpdateEmployeeAsync(EmployeeDto employeeDto)
    {
        var result = await _employeeService.UpdateEmployeeAsync(employeeDto);
        return result;
    }

}
