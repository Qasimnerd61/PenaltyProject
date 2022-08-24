using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Models
{
    public class PageOutput
    {
        public double penalty { get; set; }
        public string currencySymbol { get; set; }

        public PageOutput(double penalty, string currencySymbol)
        {
            this.penalty = penalty;
            this.currencySymbol = currencySymbol;
        }
    }
}
