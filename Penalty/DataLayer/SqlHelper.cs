using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using WebApplication1.Models;


namespace WebApplication1.DataLayer
{
    public class SqlHelper : ISqlHelper //using interface
    {
        public readonly IConfiguration configuration;
        public SqlHelper(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string GetConnectionString(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnectionString"); //establishing connection with sql
            return connectionString;
        }

        public List<Countries> GetCountries() //Method used to get Countries List from sql database
        {
        
            SqlConnection cnn = new SqlConnection(GetConnectionString(configuration));
            cnn.Open();
            SqlCommand command;
            SqlDataReader dataReader;
            string sql = "select * from dbo.CountryTbl";
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();
            List<Countries> countryList = new List<Countries>();
            while (dataReader.Read())
            {
                //fetching data from sql 
                int counID = Convert.ToInt32(dataReader.GetValue(0));
                string counName = dataReader.GetValue(1).ToString();
                string counCurrency = dataReader.GetValue(2).ToString();
                double counTax = Convert.ToDouble(dataReader.GetValue(3));
                double CountryExchange = Convert.ToDouble(dataReader.GetValue(4));

                List<Holidays> HolidayList = GetHolidays(counID);  //calling holiiday list
                List<Weekends> WeekendList = GetWeekends(counID);  //calling weekends list

                Countries country = new Countries(counID, counName,counCurrency,counTax, CountryExchange, HolidayList,WeekendList);
                // adding all the attributes of countries to get all data from database to api
                countryList.Add(country);
            }
            dataReader.Close();
            command.Dispose();
            cnn.Close();
            return countryList;
        }

        public List<Holidays> GetHolidays(int CountryID)
        {
            SqlConnection cnn = new SqlConnection(GetConnectionString(configuration));
            cnn.Open();
            SqlCommand command;
            SqlDataReader dataReader;
            string sql = "select * from holidy where CountryID=@CountryID";
            command = new SqlCommand(sql, cnn);
            command.Parameters.AddWithValue("@CountryID", CountryID);
            dataReader = command.ExecuteReader();
            List<Holidays> holidaysList = new List<Holidays>();
            while (dataReader.Read())
            {
                string HolidayName = dataReader.GetValue(0).ToString();
                DateTime HolidayDate = Convert.ToDateTime(dataReader.GetValue(1));
                Holidays holidays = new Holidays();
                holidays.holidayName = HolidayName;
                holidays.holidayDate = HolidayDate;
                holidaysList.Add(holidays);
            }
            dataReader.Close();
            command.Dispose();
            cnn.Close();
            return holidaysList;
        }

        public List<Weekends> GetWeekends(int CountryID)
        {
            SqlConnection cnn = new SqlConnection(GetConnectionString(configuration));
            cnn.Open();
            SqlCommand command;
            SqlDataReader dataReader;
            string sql = "select * from Weekends where CountryID=@CountryID";
            command = new SqlCommand(sql, cnn);
            command.Parameters.AddWithValue("@CountryID", CountryID);
            dataReader = command.ExecuteReader();
            List<Weekends> weekendsList = new List<Weekends>();
            while (dataReader.Read())
            {
                string WeekendDays = dataReader.GetValue(0).ToString();

                Weekends weekends = new Weekends();
                weekends.WeekendDay = WeekendDays;
                weekendsList.Add(weekends);
            }
            dataReader.Close();
            command.Dispose();
            cnn.Close();
            return weekendsList;
        }

        }       
    
    
}
