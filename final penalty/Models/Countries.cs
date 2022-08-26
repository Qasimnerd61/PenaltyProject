using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Countries
    {
        //attributes of country


        public int CountryID { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
        public double Tax { get; set; }
        public double CountryExchange { get; set; }

        public List<Holidays> Holidays { get; set; }
        public List<Weekends> Weekends { get; set; }


        public Countries(int CountryID, string name, string Currency, double Tax, double CountryExchange, List<Holidays> Holidays, List<Weekends> Weekends)
        {
            this.CountryID = CountryID;
            this.Name = name;
            this.Currency = Currency;
            this.Holidays = Holidays;
            this.Weekends = Weekends;
            this.Tax = Tax;
            this.CountryExchange = CountryExchange;


        }
    }
}