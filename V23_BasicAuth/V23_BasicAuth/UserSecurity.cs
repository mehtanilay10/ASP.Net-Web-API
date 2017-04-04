using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeDataAccess;

namespace V23_BasicAuth
{
    public class UserSecurity
    {
        public static bool Login(string username, string password)
        {
            using (EmployeeEntities entities = new EmployeeEntities())
            {
                return entities.Users.Any(user => user.Username.Equals(username, 
                        StringComparison.OrdinalIgnoreCase)
                    && user.Password.Equals(password));
            }
        }
    }
}