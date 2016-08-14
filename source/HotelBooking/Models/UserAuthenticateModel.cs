using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace HotelBooking.Models
{
    public class UserAuthenticateModel
    {
    }

    public class UserAuthenticateRequest
    {
        private string m_endUserIp = HttpContext.Current.Request.UserHostAddress;
        [Required]
        public string EndUserIp
        {
            get
            {
                return "192.168.0.100";
            }
            set
            {
                value = m_endUserIp;
            }
        }


        private static string m_memberMobileNo = "7405007979";
        [Required]
        public string MemberMobileNo
        {
            get { return m_memberMobileNo; }
            set { value = m_memberMobileNo; }
        }

        private static string m_memberMobilePin = "1021";
        [Required]
        public string MemberMobilePin
        {
            get { return m_memberMobilePin; }
            set { value = m_memberMobilePin; }
        }
    }

    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class UserAuthenticateResponse
    {
        [JsonProperty(PropertyName = "Status")]
        public int Status { get; set; }

        [JsonProperty(PropertyName = "TokenId")]
        public string TokenId { get; set; }

        [JsonProperty(PropertyName = "Error")]
        public Error Error { get; set; }

    }

    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class BindCountryRequest
    {

        [JsonProperty(PropertyName = "TokenId")]
        public string TokenId { get; set; }

        private string m_endUserIp = HttpContext.Current.Request.UserHostAddress;
        [Required]
        public string EndUserIp
        {
            get
            {
                return "192.168.0.100";
            }
            set
            {
                value = m_endUserIp;
            }
        }


        private static string m_memberMobileNo = "7405007979";
        [Required]
        public string MemberMobileNo
        {
            get { return m_memberMobileNo; }
            set { value = m_memberMobileNo; }
        }

        private static string m_memberMobilePin = "1021";
        [Required]
        public string MemberMobilePin
        {
            get { return m_memberMobilePin; }
            set { value = m_memberMobilePin; }
        }
    }


    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class  BindCountryResponse
    {
        [JsonProperty(PropertyName = "CountryList")]
        public string CountryList { get; set; }

        [JsonProperty(PropertyName = "Status")]
        public int Status { get; set; }

        [JsonProperty(PropertyName = "TokenId")]
        public string TokenId { get; set; }

        [JsonProperty(PropertyName = "Error")]
        public Error Error { get; set; }

    }

    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class Error
    {
        [JsonProperty(PropertyName = "ErrorCode")]
        public int ErrorCode { get; set; }

        [JsonProperty(PropertyName = "ErrorMessage")]
        public string ErrorMessage { get; set; }
    }
}