using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Formatting;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using HotelBooking.Models;
using HotelBooking.DataLayer;
using System.Web.Script.Serialization;
using System.Web.Helpers;

namespace HotelBooking.Controllers
{
    public class HotelController : Controller
    {
        HttpClient client;
        string baseUrl = "http://api.jbspl.com/Staging/";
        public HttpClient HotelInfoController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("x-username", "BIS199");
            client.DefaultRequestHeaders.Add("x-password", "123456");
            return client;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Index(UserAuthenticateRequest userReq)
        {
            HotelInfoController();
            string url =  "api/UpdatedHotel/Authenticate";
            HttpResponseMessage responseMessage = client.PostAsJsonAsync(url, userReq).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                UserAuthenticateResponse userResp = new UserAuthenticateResponse();
                var jsonString = responseMessage.Content.ReadAsStringAsync();
                jsonString.Wait();
                //model = JsonConvert.DeserializeObject<List<UserAuthenticateResponse>>(jsonString.Result);
               
                userResp = JsonConvert.DeserializeObject<UserAuthenticateResponse>(jsonString.Result);
                var tokanId = userResp.TokenId;
                if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("Token_Id"))
                {
                    HttpCookie cookie = this.ControllerContext.HttpContext.Request.Cookies["Token_Id"];
                    cookie.Expires = DateTime.Now.AddDays(-1);
                    this.ControllerContext.HttpContext.Response.Cookies.Add(cookie);
                }
                else
                {
                    HttpCookie cookie = new HttpCookie("Token_Id");
                    cookie.Value = tokanId;
                    this.ControllerContext.HttpContext.Response.Cookies.Add(cookie);
                }
                return View("Index", userResp);
            }
            return View("index");
        }
        [HttpPost]
        public ActionResult GetCountry()
        {
            List<BindCountryResponse> objGetCountry = new List<BindCountryResponse>();
            ContryList_Db objCountryDal = new ContryList_Db();
            objGetCountry = objCountryDal.GetCountryList();
            var result = objGetCountry.ToList();
            var json = new JavaScriptSerializer();
            return Json(result, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public ActionResult GetAllCity(string CountryName)
        {
            List<BindCityResponse> objGetCity = new List<BindCityResponse>();
            ContryList_Db objCountryDal = new ContryList_Db();
            objGetCity = objCountryDal.GetAllCity(CountryName);
            var result = objGetCity.ToList();
            var json = new JavaScriptSerializer();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ListView(HotelSearchRequest hotelsearchReq)
        {
            HotelInfoController();
            string url = "api/UpdatedHotel/GetHotelResult";
            HttpResponseMessage responseMessage = client.PostAsJsonAsync(url, hotelsearchReq).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                HotelSearchResponse hotelsearchResp = new HotelSearchResponse();
                var jsonString = responseMessage.Content.ReadAsStringAsync();
                jsonString.Wait();

                hotelsearchResp = JsonConvert.DeserializeObject<HotelSearchResponse>(jsonString.Result);
                return View("ListView", hotelsearchResp);
            }
            return View("ListView");
        }
    }
}