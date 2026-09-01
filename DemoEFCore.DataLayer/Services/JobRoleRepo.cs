using DemoEFCore.DataLayer.Interfaces;
using DemoEFCore.DataLayer.Model;
using DemoEFCore.Shared.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoEFCore.DataLayer.Services
{
    public class JobRoleRepo : IJobRoleRepo
    {
        private readonly AppDbContext _context;
        public JobRoleRepo(AppDbContext context) 
        { 
            _context = context;
        }

        public async Task<bool> AddJobRoleAsync(Guid EmployeeId, JobRolesDto jobRoleDto)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.EmpId == EmployeeId);
            if (employee == null)
            {
                return false;
            }
            var jobRole = new JobRole
            {
                JobRoleId = Guid.NewGuid(),
                EmpNo = employee.EmpNo,
                JobRoleName = jobRoleDto.JobRoleName
            };

            await _context.JobRoles.AddAsync(jobRole);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteJobRoleAsync(Guid EmployeeId, Guid JobRoleId)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.EmpId == EmployeeId); 
            if (employee == null)
            {
                return false;
            }

            var jobRole = await _context.JobRoles.FirstOrDefaultAsync(j => j.JobRoleId == JobRoleId && j.EmpNo == employee.EmpNo);
            if (jobRole == null)
            {
                return false;
            }

            _context.JobRoles.Remove(jobRole);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<JobRolesDto>> GetAllJobRolesAsync(Guid EmployeeId)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.EmpId == EmployeeId);
            if (employee == null)
            {
                return new List<JobRolesDto>();
            }
            var jobRoles = await _context.JobRoles
                .Where(j => j.EmpNo == employee.EmpNo)
                .Select(j => new JobRolesDto
                {
                    Id = j.JobRoleId,
                    JobRoleName = j.JobRoleName
                })
                .ToListAsync();
            return jobRoles;
        }

        public async Task<JobRolesDto> GetJobRoleByIdAsync(Guid EmployeeId, Guid JobRoleId)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.EmpId == EmployeeId);
            if (employee == null)
            {
                return null!;
            }

            var jobRole = await _context.JobRoles
                .Where(j => j.JobRoleId == JobRoleId && j.EmpNo == employee.EmpNo)
                .Select(j => new JobRolesDto
                {
                    Id = j.JobRoleId,
                    JobRoleName = j.JobRoleName
                })
                .FirstOrDefaultAsync();

            return jobRole!;
        }

        public async Task<bool> UpdateJobRoleAsync(Guid EmployeeId, JobRolesDto jobRoleDto)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.EmpId == EmployeeId);
            if (employee == null)
            {
                return false;
            }

            var jobRole = await _context.JobRoles.FirstOrDefaultAsync(j => j.JobRoleId == jobRoleDto.Id && j.EmpNo == employee.EmpNo);
            if (jobRole == null)
            {
                return false;
            }

            jobRole.JobRoleName = jobRoleDto.JobRoleName;

            _context.JobRoles.Update(jobRole);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
