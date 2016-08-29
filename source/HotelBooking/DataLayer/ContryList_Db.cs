using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelBooking.Models;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace HotelBooking.DataLayer
{
    public class ContryList_Db
    {
        private readonly IDbConnection _db;
        public ContryList_Db()
        {
            _db = new SqlConnection(ConfigurationManager.ConnectionStrings["Hotel_Booking"].ConnectionString);
        }
       public List<BindCountryResponse> GetCountryList()
        {
            try
            {
                return this._db.Query<BindCountryResponse>("select [Country],[Countrycode] From HotelCityCode Group By [Country],[Countrycode] order by [Country] asc").ToList();
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public List<BindCityResponse> GetAllCity(string countryName)
        {
            try
            {
                return this._db.Query<BindCityResponse>("Select [Cityid],[Destination] From HotelCityCode  where [Countrycode]='" + countryName+ "' order by [Destination] asc").ToList();
            }
            catch(Exception e)
            {
                throw e;
            }
        } 
    }
}