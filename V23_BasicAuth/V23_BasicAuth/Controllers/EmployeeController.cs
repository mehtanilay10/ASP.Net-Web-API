using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using EmployeeDataAccess;

namespace V23_BasicAuth.Controllers
{
    public class EmployeeController : ApiController
    {
        [BasicAuth]
        public HttpResponseMessage Get()
        {
            using (EmployeeEntities entities = new EmployeeEntities())
            {
                string username = Thread.CurrentPrincipal.Identity.Name;

                IEnumerable<Employee> listOfEmployees = null;
                if (username.Equals("developer"))
                    listOfEmployees = entities.Employees.Where(emp => emp.Department.Equals("Development")).ToList();
                else if (username.Equals("tester"))
                    listOfEmployees = entities.Employees.Where(emp => emp.Department.Equals("Testing")).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, listOfEmployees);
            }
        }
    }
}
