using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DataLayer;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PenaltyCalculatorController : ControllerBase
    {
        // GET: api/PenaltyCalculator

        public readonly ISqlHelper _ISqlHelper;  //here using interface
        public PenaltyCalculatorController(ISqlHelper ISqlHelper)
        {
            this._ISqlHelper = ISqlHelper;
        }
        //[Route("GetCountries")]
        [HttpGet]
        public List<Countries> Get()
        {
            List<Countries> countryList = _ISqlHelper.GetCountries();
            return countryList;
        }
       

        // GET: api/PenaltyCalculator/5  i.e for Pakistan "1" and for UAE "2".
        [HttpGet("{CountryID}", Name = "Get")]
        public List<Holidays> Get(int CountryID)
        {
            List<Holidays> holidaysList = _ISqlHelper.GetHolidays(CountryID);
            return holidaysList;
        }

        // POST: api/PenaltyCalculator
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/PenaltyCalculator/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
