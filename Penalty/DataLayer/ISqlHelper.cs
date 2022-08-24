using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using WebApplication1.Models;


namespace WebApplication1.DataLayer
{
    public interface ISqlHelper
    {
        public string GetConnectionString(IConfiguration configuration);
        public List<Countries> GetCountries();
        public List<Holidays> GetHolidays(int CountryID);
    }
}
