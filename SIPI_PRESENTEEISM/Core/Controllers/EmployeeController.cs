﻿namespace SIPI_PRESENTEEISM.Core.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SIPI_PRESENTEEISM.Core.DataTransferObjects.Employee;
    using SIPI_PRESENTEEISM.Core.Domain.Services.Interfaces;

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeCreateDTO info)
        {
            var result = await _employeeService.CreateEmployee(info);
            return Ok(result);
        }

        [HttpGet]
        [Route("employee-validation")]
        public async Task<IActionResult> GetEmployee([FromQuery] int validationCode)
        {
            var result = await _employeeService.GetEmployee(validationCode);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployee(string userId)
        {
            var result = await _employeeService.GetEmployee(Guid.Parse(userId));
            return Ok(result);
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetEmployees()
        {
            var result = await _employeeService.GetAllEmployees();
            return Ok(result);
        }
    }
}