using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Countries
    {
        //attributes of country
        private int counID;                
        private string counName;
        private string counCurrency;
        private double counTax;
        private List<Holidays> holidayList;
        private List<Weekends> weekendList;

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

        public Countries(int counID, string counName, string counCurrency, double counTax, List<Holidays> holidayList, List<Weekends> weekendList)
        {
            this.counID = counID;
            this.counName = counName;
            this.counCurrency = counCurrency;
            this.counTax = counTax;
            this.holidayList = holidayList;
            this.weekendList = weekendList;
        }
    }
}
