using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class PageInput
    {
        public DateTime startDate{get; set; } 
        public DateTime endDate { get; set; }
        public Countries Countries { get; set; }
    }
}
