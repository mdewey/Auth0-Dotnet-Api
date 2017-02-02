using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Auth0SystemWeb.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [Authorize]
        // GET api/values/5
        public string Get(int id)
        {

            var test = User.Identity as System.Security.Claims.ClaimsIdentity;
            var usersname = test.Name;

            // claims has a bunch of properties, this is where the meta data from Auth0 will live
            foreach (var claim in test.Claims)
            {
                var key = claim.Type;
                var value = claim.Value; 
            }

            
            return test.Name;

        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
