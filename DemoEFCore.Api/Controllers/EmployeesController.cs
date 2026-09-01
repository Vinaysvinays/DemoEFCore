using DemoEFCore.DataLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DemoEFCore.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : Controller
{
    private readonly IEmployeeService _employeeService;

    public EmployeesController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllEmployees()
    {
        var employees = await _employeeService.GetAllEmployeesAsync();
        return Ok(employees);
    }

}
