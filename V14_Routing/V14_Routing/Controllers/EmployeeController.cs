using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using V14_Routing.Models;

namespace V14_Routing.Controllers
{
    [RoutePrefix("api/Employee")]
    [EnableCors("*", "*", "*")]
    public class EmployeeController : ApiController
    {
        static List<Employee> allEmployees = new List<Employee>
        {
            new Employee() {Id=1, Name="Nilay", DepartmentName="Developement" },
            new Employee() {Id=2, Name="Shubham", DepartmentName="Developement" },
            new Employee() {Id=3, Name="Priyank", DepartmentName="Testing" },
            new Employee() {Id=4, Name="Dhaval", DepartmentName="Testing" },
            new Employee() {Id=5, Name="Ravi", DepartmentName="Developement" }
        };

        
        //[Route("{id:int?}", Name ="GetEmployeeById")]
        //public string GetEmployee(int id=1)
        //{
        //    Employee emp = allEmployees.FirstOrDefault(e => e.Id == id);
        //    if (emp != null)
        //        return emp.Name;
        //    return string.Empty;
        //}

        //public IHttpActionResult GetEmployee(int id)
        //{
        //    Employee emp = allEmployees.FirstOrDefault(e => e.Id == id);
        //    if (emp == null)
        //        return Content(HttpStatusCode.NotFound, "Employee Not Found");
        //    return Ok(emp);
        //}


        [Route("{name:alpha:length(3,5)}")]
        public Employee GetEmployeeByName(string name)
        {
            return allEmployees.FirstOrDefault(e => e.Name.ToLower() == name.ToLower());
        }


        [Route("{id}/department")]
        public string GetDepartmentName(int id)
        {
            Employee emp = allEmployees.FirstOrDefault(e => e.Id == id);
            if (emp != null)
                return emp.DepartmentName;
            return string.Empty;
        }


        [Route("")]
        [DisableCors]
        public IEnumerable<Employee> GetEmployee()
        {
            return allEmployees.ToList();
        }


        [HttpPost]
        [Route("")]
        public HttpResponseMessage AddEmployee(Employee emp)
        {
            allEmployees.Add(emp);
            var response = Request.CreateResponse(HttpStatusCode.Created, emp);
            string uri = Url.Link("GetEmployeeById", new { id = emp.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }


        [Route("~/api/Department/{departmentName}/employees")]
        public IEnumerable<Employee> GetByDepartment(string departmentName)
        {
            return allEmployees.Where(e => e.DepartmentName.ToLower() == departmentName.ToLower());
        }
    }
}
