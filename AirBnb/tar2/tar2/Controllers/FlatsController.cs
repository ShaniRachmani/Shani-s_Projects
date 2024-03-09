using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace tar1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class FlatsController : ControllerBase
    {
        // GET: api/<FlatsController>
        [HttpGet]
        public IEnumerable<Flat> Get()
        {
            return Flat.Read();
        }
        [HttpGet("city")] // this uses the QueryString
        //public IEnumerable<Flat> GetByCity(string city,double price)
        //{
        //    Flat flat = new Flat();
        //    return flat.ReadByCity(city, price);

        //}

        // GET api/<FlatsController>/5
        [HttpGet("{id}")]
        
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FlatsController>
        [HttpPost]
        public int Post([FromBody] Flat flat)
        {
            return flat.Insert();
        }

        // PUT api/<FlatsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FlatsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
