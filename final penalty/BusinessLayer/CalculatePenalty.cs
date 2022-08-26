
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;
using WebApplication1.DataLayer;
using WebApplication1.Models;

namespace WebApplication1.BusinessLayer
{
   
    public class CalculatePenalty: ICalculatePenalty
    {
        public readonly ISqlHelper _SQL;
        public CalculatePenalty(ISqlHelper SQLDataHelper)
        {
            this._SQL = SQLDataHelper;
        }

        public int GetBusinessDays(Countries Countries, PageInput input) //Method to get Business Days
        {
            int days = 0;
            DateTime startDate = input.startDate;
            DateTime endDate = input.endDate;

            for (var date = startDate; date<=endDate; date=date.AddDays(1)) //starting a loop from start date to end date
            {
                bool checkWeekend = false;   //using weekend and holiday check and setting them to false
                bool checkHoliday = false;

                for (int i = 0; i <Countries.Weekends.Count; i++) //Another nested loop for checking weekends
                {
                    if (date.DayOfWeek.ToString() == (Countries.Weekends[i].WeekendDay))
                    {
                        checkWeekend = true;  //as date goes equal to respective country weekend check goes true
                    }
                }
                for (int i=0; i<Countries.Holidays.Count; i++)
                {
                    if (date.DayOfYear == (Countries.Holidays[i].holidayDate).DayOfYear)
                    {
                        checkHoliday = true;  //as date goes equal to respective country holiday check goes true
                    }
                }
                if (checkWeekend != true && checkHoliday != true) 
                {
                    days++; //days (business days will only be added when there is no weekend and no holiday
                }
            }
            return days;
        }


        public double CalculatePenalt(Countries Countries, PageInput input)
        {
            int workDays = GetBusinessDays(Countries, input); //Getting businessdays and storing in workdays
            double penalty;
            if (workDays > 10)
            {
                penalty = (workDays - 10) * (50 * Countries.CountryExchange) * (1 + (Countries.Tax / 100)); //calculating penalty using exchange rate for respective coutries
            }
            else
            {
                penalty = 0;
            }
            return penalty;
        }

        public PageOutput DispPenalty(Countries country,PageInput input)
        {
            double penalty = CalculatePenalt(country, input);
            PageOutput output = new PageOutput(penalty, country.Currency);// Showing Penalties WRT countries currency
            return output;
        }

        public List<Countries> ShowCountries()
        {
            List<Countries> countryList = _SQL.GetCountries();
            return countryList;
        }

    }
}
