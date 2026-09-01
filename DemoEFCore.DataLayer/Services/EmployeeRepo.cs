using DemoEFCore.DataLayer.Interfaces;
using DemoEFCore.DataLayer.Model;
using DemoEFCore.Shared.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoEFCore.DataLayer.Services;

public class EmployeeRepo : IEmployeeRepo
{
    private readonly AppDbContext _context;

    public EmployeeRepo(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AddEmployeeAsync(EmployeeDto employeeDto)
    {
        if (employeeDto == null)
        {
            return false;
        }
        var employee = new Employee
        {
            EmpId = Guid.NewGuid(),
            FirstName = employeeDto.FirstName,
            LastName = employeeDto.LastName,
            Email = employeeDto.Email,
            Department = employeeDto.Department,
            Salary = employeeDto.Salary
        };
        await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteEmployeeAsync(Guid EmployeeId)
    {
        if (EmployeeId == Guid.Empty)
        {
            return false;
        }
        var employee = await _context.Employees.FirstOrDefaultAsync(e => e.EmpId == EmployeeId);
        if (employee == null)
        {
            return false;
        }
        _context.Employees.Remove(employee);
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<List<EmployeeDto>> GetAllEmployeesAsync()
    {
        return await _context.Employees
            .Select(e => new EmployeeDto
            {
                Id = e.EmpId,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
                Department = e.Department,
                Salary = e.Salary
            }).ToListAsync();
    }

    public async Task<EmployeeDto> GetEmployeeByIdAsync(Guid EmployeeId)
    {
        var employee = await _context.Employees.FirstOrDefaultAsync(e => e.EmpId == EmployeeId);
        if (employee == null) return null!;

        return new EmployeeDto
        {
            Id = employee.EmpId,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Email = employee.Email,
            Department = employee.Department,
            Salary = employee.Salary
        };
    }

    public async Task<bool> UpdateEmployeeAsync(EmployeeDto employeeDto)
    {
        if (employeeDto == null || employeeDto.Id == Guid.Empty)
        {
            return false;
        }
        var existingEmployee = await _context.Employees.FirstOrDefaultAsync(e => e.EmpId == employeeDto.Id);
        if (existingEmployee == null)
        {
            return false;
        }
        existingEmployee.FirstName = employeeDto.FirstName;
        existingEmployee.LastName = employeeDto.LastName;
        existingEmployee.Email = employeeDto.Email;
        existingEmployee.Department = employeeDto.Department;
        existingEmployee.Salary = employeeDto.Salary;

        await _context.SaveChangesAsync();

        return true;

    }
}
