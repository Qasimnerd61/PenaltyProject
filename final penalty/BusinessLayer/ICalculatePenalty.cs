
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;
using WebApplication1.DataLayer;
using WebApplication1.Models;

namespace WebApplication1.BusinessLayer
{
    public interface ICalculatePenalty
    {
        public int GetBusinessDays(Countries Countries, PageInput input);
        public double CalculatePenalt(Countries country, PageInput input);
        public PageOutput DispPenalty(Countries country, PageInput input);
        public List<Countries> ShowCountries();
    }
}
