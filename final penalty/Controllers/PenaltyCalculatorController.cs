using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using WebApplication1.BusinessLayer;
using WebApplication1.DataLayer;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PenaltyCalculatorController : ControllerBase
    {
        // GET: api/PenaltyCalculator

        public readonly ICalculatePenalty CalculatePenalty;
        public PenaltyCalculatorController(ICalculatePenalty _penaltyCalculator)
        {
            this.CalculatePenalty = _penaltyCalculator;
        }

        [Route("GetCountry")]
        [HttpGet]
        public List<Countries> Get()
        {
            List<Countries> countryList = this.CalculatePenalty.ShowCountries();
            return countryList;
        }

        [Route("GetPenalty")]
        [HttpPost]
        public PageOutput Get([FromBody] PageInput input)
        {
            List<Countries> countryList = this.CalculatePenalty.ShowCountries(); /*ShowCountries() exists in the PenCalculator in business layer*/
            Countries country = new Countries(0, "", "", 0, 00, null, null);
            for (int i = 0; i < countryList.Count; i++)
            {
                if (input.id == countryList[i].CountryID)
                {
                    country = countryList[i];
                }
            }
            PageOutput output = this.CalculatePenalty.DispPenalty(country, input);
            return output;
        }


    }
}
