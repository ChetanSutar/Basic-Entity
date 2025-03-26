using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public EmployeesController(ApplicationDbContext dbContext)
        {
        
                this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllEmp()
        {
          var AllEmp=  dbContext.Employees.ToList();

            return Ok(AllEmp);
        }

        [HttpGet("{Id:guid}")]
        public IActionResult GetEmp(Guid Id) 
        {
         var emp=   dbContext.Employees.Find(Id);
            if (emp == null) {  return NotFound(); }
            return Ok(emp);
        }

        [HttpPost]
        public IActionResult AddEmp(AddEmpDTO addEmpDTO)
        {
            var empEntity = new Employee()
            {
                Name = addEmpDTO.Name,
                Email = addEmpDTO.Email,
                Phone = addEmpDTO.Phone,
                Salary = addEmpDTO.Salary

            };


            dbContext.Employees.Add(empEntity);
            dbContext.SaveChanges();
            return Ok(empEntity);
        }

        [HttpPut ("{ID:guid}")]
        public IActionResult UpdateEmp(Guid ID , AddEmpDTO UpEmp)
        {
            var Emp = dbContext.Employees.Find( ID);
            if(Emp == null) { return NotFound(); }

            Emp.Name = UpEmp.Name;
            Emp.Email = UpEmp.Email;
            Emp.Phone = UpEmp.Phone;
            Emp.Salary= UpEmp.Salary;

            dbContext.SaveChanges ();
            return Ok(Emp);
        }


        [HttpDelete("{ID}")]
        public IActionResult DeleteEmp(Guid ID)
        {
            var emp=dbContext.Employees.Find(ID);
            if(emp == null) { return NotFound(); }
            dbContext.Employees.Remove(emp);
            dbContext.SaveChanges();
            return Ok(emp);

        }
    }

}
