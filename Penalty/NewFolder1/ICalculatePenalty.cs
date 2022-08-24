using Project1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DataLayer;
using WebApplication1.Models;

namespace Project1.NewFolder1
{
    interface ICalculatePenalty
    {
        public int GetBusinessDays(Countries Countries, PageInput input);
        public double CalculatePenalty(Countries country, PageInput input);
        public PageOutput DispPenalty(PageInput input);
        public List<Countries> ShowCountries();
    }
}
