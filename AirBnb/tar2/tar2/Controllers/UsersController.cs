using Microsoft.AspNetCore.Mvc;
using tar2.BL;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace tar2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            User user = new User();
            return user.ReadUser();
        }

        // GET api/<UsersController>/5
        [HttpGet("{email}")]
        public string Get(string email)
        {
            return "value";
        }

        // POST api/<UsersController>
        [HttpPost("Register")]
        public int Post([FromBody] User user)
        {
            return user.Insert(); 

        }

        // PUT api/<UsersController>/5
        [HttpPut()]
        public int Put([FromBody] User user)
        {
            return user.UpdateDetails(user.Email);
        }

        [HttpPost("Login")]
        public User GetUserNameandPassword([FromBody] User user)
        {
            User u = user.Login();
            return u;
        }


        // DELETE api/<UsersController>/5
        [HttpDelete("{email}")]
        public IActionResult Delete(string email)
        {
            User u= new User();
            u.Delete(email);
            return Ok(email);
        }
    }
}
