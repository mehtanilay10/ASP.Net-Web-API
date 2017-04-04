using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace V4_HttpMethods.Controllers
{
    //[Authorize]
    public class ValuesController : ApiController
    {
        static List<string> records = new List<string>() { "Record1", "Record2" };

        // GET api/values
        public IEnumerable<string> Get()
        {
            return records;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return records[id];
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
            records.Add(value);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
            records[id] = value;
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            records.RemoveAt(id);
        }
    }
}
