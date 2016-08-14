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

        //public IEnumerable<BindCountryRequest> BindCountry( string tokenId)
        //{
        //    HotelInfoController();
        //    BindCountryRequest contryReq = new BindCountryRequest();
        //    List<BindCountryResponse> contryResp = new List<BindCountryResponse>();
        //    contryReq.TokenId = tokenId;
        //    string url = "api/UpdatedHotel/Authenticate";
        //    HttpResponseMessage responseMessage = client.PostAsJsonAsync(url, contryReq).Result;
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        var jsonString = responseMessage.Content.ReadAsStringAsync();
        //        jsonString.Wait();
        //        contryResp = JsonConvert.DeserializeObject<List<UserAuthenticateResponse>>(jsonString.Result);
        //    }
        //    return contryResp;
        //}
    }
}