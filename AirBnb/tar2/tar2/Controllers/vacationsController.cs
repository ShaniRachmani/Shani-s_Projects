using Microsoft.AspNetCore.Mvc;
using tar2.BL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace tar2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class vacationsController : ControllerBase
    {
        // GET: api/<vacationsController>
        [HttpGet]
        public IEnumerable<Vacation> Get()
        {
            //return new string[] { "value1", "value2" };
            Vacation vaca=new Vacation();
            return vaca.Read();
        }
        [HttpGet("averagePrice")]
        public object GetAvgPriceByCityAndMonth(int month)
        {
            DBservices dbs = new DBservices();

            List<object> avgPrices = dbs.ReadAvgPricePerNight(month);

            return avgPrices;
        }
        //[HttpGet("startDate/{startDate}/endDate/{endDate}")]
        //public IEnumerable<Vacation> GetByDates(DateTime startDate, DateTime endDate)
        //{
        //    Vacation vacation = new Vacation();
        //    return vacation.ReadByDates(startDate, endDate);
        //}

        // GET api/<vacationsController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<vacationsController>
        [HttpPost]
        public int Post([FromBody] Vacation vacation)
        {
            return vacation.Insert();
        }
        // GET api/<VacationsController>/
        [HttpGet("{email}")]
        public IEnumerable<Vacation> Get(string email)
        {
            Vacation vacation = new Vacation();

            return vacation.ReadByUserEmail(email);
        }

        // PUT api/<vacationsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<vacationsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
