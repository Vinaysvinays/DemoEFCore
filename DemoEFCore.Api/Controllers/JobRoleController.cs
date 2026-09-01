using DemoEFCore.DataLayer.Interfaces;
using DemoEFCore.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DemoEFCore.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobRoleController : Controller
{
    private readonly IJobRoleRepo _jobRoleRepo;
    public JobRoleController(IJobRoleRepo jobRoleRepo)
    {
        _jobRoleRepo = jobRoleRepo;
    }

    [HttpPost]
    public async Task<bool> AddJoRoleAsync(Guid EmployeeId, JobRolesDto jobrole)
    {
        var result = await _jobRoleRepo.AddJobRoleAsync(EmployeeId, jobrole);
        return result;
    }

    [HttpGet]
    public async Task<List<JobRolesDto>> GetAllJoRolesAsync(Guid EmployeeId)
    {
        var result = await _jobRoleRepo.GetAllJobRolesAsync(EmployeeId);
        return result;
    }

    [HttpPut]
    public async Task<bool> UpdateJobRoleAsync(Guid EmployeeId, JobRolesDto jobrole)
    {
        var result = await _jobRoleRepo.UpdateJobRoleAsync(EmployeeId, jobrole);
        return result;
    }

    [HttpDelete]
    public async Task<bool> DeleteJobRoleAsync(Guid EmployeeId, Guid jobroleId)
    {
        var result = await _jobRoleRepo.DeleteJobRoleAsync(EmployeeId, jobroleId);
        return result;
    }
    [HttpGet("{employeeId}/jobrole/{jobRoleId}")]
    public async Task<JobRolesDto> GetJoroleById(Guid employeeId, Guid jobRoleId)
    {
        var result = await _jobRoleRepo.GetJobRoleByIdAsync(employeeId, jobRoleId);
        return result;
    }

}
