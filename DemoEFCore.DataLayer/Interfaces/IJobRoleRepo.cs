using DemoEFCore.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoEFCore.DataLayer.Interfaces;

public interface IJobRoleRepo
{
    Task<List<JobRolesDto>> GetAllJobRolesAsync(Guid EmployeeId);
    Task<bool> AddJobRoleAsync(Guid EmployeeId,JobRolesDto jobRoleDto);
    Task<bool> DeleteJobRoleAsync(Guid EmployeeId,Guid JobRoleId);
    Task<JobRolesDto> GetJobRoleByIdAsync(Guid EmployeeId,Guid JobRoleId);
    Task<bool> UpdateJobRoleAsync(Guid EmployeeId,JobRolesDto jobRoleDto);
}
