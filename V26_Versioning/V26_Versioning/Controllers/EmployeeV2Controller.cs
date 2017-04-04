using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using V26_Versioning.Models;

namespace V26_Versioning.Controllers
{
    //[RoutePrefix("api/v2/employee")]
    public class EmployeeV2Controller : ApiController
    {
        static List<EmployeeV2> allEmployees = new List<EmployeeV2>
        {
            new EmployeeV2() {Id=1, Name="Nilay", DepartmentName="Developement" },
            new EmployeeV2() {Id=2, Name="Shubham", DepartmentName="Developement" },
            new EmployeeV2() {Id=3, Name="Priyank", DepartmentName="Testing" },
            new EmployeeV2() {Id=4, Name="Dhaval", DepartmentName="Testing" },
            new EmployeeV2() {Id=5, Name="Ravi", DepartmentName="Developement" }
        };

        //[Route("")]
        public IEnumerable<EmployeeV2> Get()
        {
            return allEmployees;
        }

        //[Route("{id}")]
        public EmployeeV2 Get(int id)
        {
            return allEmployees.FirstOrDefault(emp => emp.Id == id);
        }
    }
}
