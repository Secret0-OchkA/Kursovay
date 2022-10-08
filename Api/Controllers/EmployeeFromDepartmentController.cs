﻿using Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace DockerTestBD.Api.Controllers
{
    [Route(ApiRoutes.FromDepartment)]
    [ApiController]
    public class EmployeeFromDepartmentController : ControllerBase
    {
        readonly IService<Employee> service;
        public EmployeeFromDepartmentController(IService<Employee> service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult GetEmployee(int companyId, int departmentId)
            => Ok(service.GetAll().Where(e => e.Department?.CompanyId == companyId && e.DepartmentId == departmentId));
        [HttpGet("{employeeId}")]
        public IActionResult GetEmployee(int companyId, int departmentId, int employeeId)
        {
            Employee? employee = service.Get(employeeId);
            if (employee == null || employee.Department?.CompanyId != companyId || employee.DepartmentId != departmentId)
                return BadRequest(new Employee());

            return Ok(employee);
        }

        [HttpDelete("{employeeId}")]
        public IActionResult Remove(int companyId, int departmentId, int employeeId)
        {
            Employee? employee = service.Get(employeeId);
            if (employee == null || employee.Department?.CompanyId != companyId || employee.DepartmentId != departmentId)
                return BadRequest(new Employee());

            employee.Department = null;
            service.Update(employee);
            return Ok(employee);
        }
        [HttpPost("{employeeId}")]
        public IActionResult Add(int departmentId, int employeeId)
        {
            Employee? employee = service.Get(employeeId);
            if (employee == null)
                return BadRequest(new Employee());

            employee.DepartmentId = departmentId;
            service.Update(employee);
            return Ok(service.Get(employeeId));
        }
    }
}