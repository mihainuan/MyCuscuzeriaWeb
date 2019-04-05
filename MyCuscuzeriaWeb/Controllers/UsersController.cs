using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Collections.Generic;

namespace MyCuscuzeriaWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET api/users/getuser
        [HttpGet]
        [Route("getuser")]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/users/getuser/5
        [HttpGet("{id}")]
        [Route("getuser/{id}")]
        public ActionResult<string> GetUser(int id)
        {
            return "Get: " + id;
        }

        // POST api/users/postuser
        [HttpPost]
        [Route("postuser")]
        public string PostUser([FromBody] string value)
        {
            return "Post: " + value;
        }

        // PUT api/users/putuser/5
        [HttpPut("{id}")]
        [Route("putuser/{id}")]
        public string PutUser(int id, [FromBody] string value)
        {
            return "Put: " + id + " | " + value;
        }

        // DELETE api/users/deleteuser/5
        [HttpDelete("{id}")]
        [Route("deleteuser/{id}")]
        public string DeleteUser(int id)
        {
            return "Delete: " + id;
        }
    }
}
