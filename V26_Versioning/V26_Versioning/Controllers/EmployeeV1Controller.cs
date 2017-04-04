using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using V26_Versioning.Models;

namespace V26_Versioning.Controllers
{
    //[RoutePrefix("api/v1/employee")]
    public class EmployeeV1Controller : ApiController
    {
        static List<EmployeeV1> allEmployees = new List<EmployeeV1>
        {
            new EmployeeV1 {Id = 1, Name = "Nilay" },
            new EmployeeV1 { Id = 2, Name="Ravi" },
            new EmployeeV1 {Id=3, Name="Shubham" }
        };

        //[Route("")]
        public IEnumerable<EmployeeV1> Get()
        {
            return allEmployees;
        }

        //[Route("{id}")]
        public EmployeeV1 Get(int id)
        {
            return allEmployees.FirstOrDefault(emp => emp.Id == id);
        }
    }
}
