using BooksBackend.Models.Employees;
using BooksBackend.Models.Status;
using BooksBackend.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksBackend.Controllers
{
    public class StatusController : ControllerBase
    {
        private ISystemTime _systemTime;

        public StatusController(ISystemTime systemTime)
        {
            _systemTime = systemTime;
        }


        // GET / status
        [HttpGet("status")]
        public ActionResult GetTheStatus()
        {
            var response = new GetStatusResponse
            {
                CheckedBy = "Joes",
                Message = "Looking good bruv",
                LastChecked = _systemTime.GetCurrent()
            };
            return Ok(response);
        }

        // http://localhost:1337/products/catName/123
        // URL - Route Parameters
        [HttpGet("/products/{category}/{productid:int}")]
        public ActionResult GetProduct(string category, int productid)
        {
            return Ok($"This {category} has this {productid}");
        }

        // http://localhost:1337/employees?department=dev
        [HttpGet("/employees")]
        public ActionResult GetEmployeesInDepartment([FromQuery] string department)
        {
            return Ok($"Giving you all the employees from {department}");
        }

        // http://localhost:1337/whoami
        [HttpGet("/whoami")]
        public ActionResult WhoAmI([FromHeader(Name ="User-Agent")]string userAgent)
        {
            return Ok($"You are running {userAgent}");
        }

        [HttpPost("/employees")]
        public ActionResult Hire([FromBody] PostEmployeeCreate employee)
        {
            return Ok($"Hiring {employee.Name} for {employee.Department} with {employee.StartingSalary}");
        }
    }
}
